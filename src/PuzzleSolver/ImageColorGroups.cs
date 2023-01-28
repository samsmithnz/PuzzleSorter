using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleSolver
{
    public class ImageColorGroups
    {
        public SortedList<int, Rgb24> PriorityColorPalette { get; set; }
        public List<Rgb24> ColorPalette { get; set; }

        public ImageColorGroups(List<Rgb24> colorPalette, SortedList<int, Rgb24> priorityColorPalette = null)
        {
            ColorPalette = colorPalette;
            if (priorityColorPalette == null)
            {
                PriorityColorPalette = new SortedList<int, Rgb24>();
            }
            else
            {
                PriorityColorPalette = priorityColorPalette;
            }
        }

        /// <summary>
        /// Get Images Statistics for target image
        /// </summary>
        /// <param name="sourceFilename"></param>
        /// <param name="image"></param>
        /// <param name="onlyShowTop3"></param>
        /// <returns></returns>
        public ImageStats ProcessStatsForImage(string sourceFilename = null, Image<Rgb24> image = null, bool onlyShowTop3 = true)
        {
            ImageStats imageStats = null;
            Image<Rgb24> sourceImage = null;
            if (sourceFilename != null)
            {
                sourceImage = Image.Load<Rgb24>(sourceFilename);
            }
            else if (image != null)
            {
                sourceImage = image;
            }

            if (sourceImage != null)
            {
                imageStats = new ImageStats(sourceImage)
                {
                    ColorGroups = ProcessImageIntoColorGroups(sourceImage),
                    PriorityColorPalette = PriorityColorPalette
                };
                imageStats.NamedColorsAndPercentList = BuildNamedColorsAndPercentList(imageStats.ColorGroups, imageStats.PriorityColorPalette, onlyShowTop3);
            }
            return imageStats;
        }

        private Dictionary<Rgb24, List<Rgb24>> ProcessImageIntoColorGroups(Image<Rgb24> image)
        {
            Dictionary<Rgb24, List<Rgb24>> groupedColors = new Dictionary<Rgb24, List<Rgb24>>();

            image.ProcessPixelRows(accessor =>
            {
                //int srcWidth = sourceImg.Size().Width;
                int srcHeight = image.Size().Height;

                for (var row = 0; row < srcHeight; row++)
                {
                    Span<Rgb24> pixelSpan = accessor.GetRowSpan(row);
                    for (var col = 0; col < pixelSpan.Length; col++)
                    {
                        Rgb24 colorGroup = FindClosestColorGroup(pixelSpan[col]);
                        if (colorGroup != null)
                        {
                            if (!groupedColors.ContainsKey((Rgb24)colorGroup))
                            {
                                List<Rgb24> colorList = new List<Rgb24>()
                                {
                                pixelSpan[col]
                                };
                                groupedColors[(Rgb24)colorGroup] = colorList;
                            }
                            else
                            {
                                List<Rgb24> colorList = groupedColors[(Rgb24)colorGroup];
                                colorList.Add(pixelSpan[col]);
                                groupedColors[(Rgb24)colorGroup] = colorList;
                            }
                        }
                    }
                }
            });

            //Order with the most number of colors rolling up into the parent color first.
            groupedColors = groupedColors.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            return groupedColors;
        }

        //Group RGB colors into multiple groups
        private Rgb24 FindClosestColorGroup(Rgb24 colorToTest)
        {
            Rgb24 closestColorGroup = null;
            List<KeyValuePair<Rgb24, int>> results = new List<KeyValuePair<Rgb24, int>>();
            foreach (Rgb24 color in ColorPalette)
            {
                int colorDifference = GetColorDifference(color, colorToTest);
                results.Add(new KeyValuePair<Rgb24, int>(color, colorDifference));
            }
            //Order the results and save over itself
            results = results.OrderBy(t => t.Value).ToList();

            //Check if the largest positive or negative value is closer
            if (results.Count > 0)
            {
                closestColorGroup = results[0].Key;
            }
            return closestColorGroup;
        }

        //Since it uses Sqrt, it always returns a positive number
        private static int GetColorDifference(Rgb24 color1, Rgb24 color2)
        {
            return (int)Math.Sqrt(Math.Pow(color1.R - color2.R, 2) + Math.Pow(color1.G - color2.G, 2) + Math.Pow(color1.B - color2.B, 2));
        }

        private static List<ColorStats> BuildNamedColorsAndPercentList(
            Dictionary<Rgb24, List<Rgb24>> colorGroups,
            SortedList<int, Rgb24> priorityColorPalette,
            bool onlyShowTop3)
        {
            List<ColorStats> roughNamePercentList = new List<ColorStats>();
            //Calculate the name and percent and add it into a list
            foreach (KeyValuePair<Rgb24, List<Rgb24>> colorGroup in colorGroups)
            {
                double percent = (double)colorGroup.Value.Count / (double)colorGroups.Sum(t => t.Value.Count);
                roughNamePercentList.Add(new ColorStats(colorGroup.Key, ColorPalettes.ToName(colorGroup.Key), percent));
            }
            //If there are priority items, update the order
            if (priorityColorPalette.Count > 0)
            {
                foreach (KeyValuePair<int, Rgb24> priorityItem in priorityColorPalette)
                {
                    ColorStats priorityColorStats = roughNamePercentList.Where(x => x.Rgb == priorityItem.Value).FirstOrDefault();
                    if (priorityColorStats != null)
                    {
                        priorityColorStats.Order = priorityItem.Key;
                    }
                }
            }
            //Order the percent list
            roughNamePercentList = roughNamePercentList.OrderBy(t => t.Order).ThenByDescending(x => x.Percent).ThenBy(x => x.Name).ToList();

            //Add the other percent if needed
            List<ColorStats> finalNamePercentList = new List<ColorStats>();
            if (onlyShowTop3 == true)
            {
                int count = 0;
                double totalOtherPercent = 0;
                foreach (ColorStats item in roughNamePercentList)
                {
                    if (onlyShowTop3 == true && count < 2)
                    {
                        finalNamePercentList.Add(item);
                        count++;
                    }
                    else
                    {
                        totalOtherPercent += item.Percent;
                    }
                }
                //If there is an other percent over 0, add it
                if (Math.Round(totalOtherPercent, 2) > 0)
                {
                    finalNamePercentList.Add(new ColorStats(null, "Other", totalOtherPercent));
                }
            }
            else
            {
                finalNamePercentList = roughNamePercentList;
            }

            return finalNamePercentList;
        }
    }
}