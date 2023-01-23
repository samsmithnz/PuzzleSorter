using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PuzzleSolver;

public class ImageColorGroups
{
    public SortedList<int, Rgb24> PriorityColorPalette { get; set; }
    public List<Rgb24> ColorPalette { get; set; }

    public ImageColorGroups(List<Rgb24> colorPalette, SortedList<int, Rgb24>? priorityColorPalette = null)
    {
        ColorPalette = colorPalette;
        if (priorityColorPalette == null)
        {
            PriorityColorPalette = new();
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
    public ImageStats? ProcessStatsForImage(string? sourceFilename = null, Image<Rgb24>? image = null, bool onlyShowTop3 = true)
    {
        ImageStats? imageStats = null;
        Image<Rgb24>? sourceImage = null;
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
            imageStats = new(sourceImage)
            {
                ColorGroups = ProcessImageIntoColorGroups(sourceImage),
                PriorityColorPalette = PriorityColorPalette
            };
            imageStats.NamedColorsAndPercentList = BuildNamedColorsAndPercentList(imageStats.ColorGroups, imageStats.PriorityColorPalette, onlyShowTop3);
        }
        return imageStats;
    }

    private Dictionary<Rgb24, List<Rgb24>> ProcessImageIntoColorGroups(Image<Rgb24>? image)
    {
        Dictionary<Rgb24, List<Rgb24>> groupedColors = new();

        image?.ProcessPixelRows(accessor =>
        {
            //int srcWidth = sourceImg.Size().Width;
            int srcHeight = image.Size().Height;

            for (var row = 0; row < srcHeight; row++)
            {
                Span<Rgb24> pixelSpan = accessor.GetRowSpan(row);
                for (var col = 0; col < pixelSpan.Length; col++)
                {
                    Rgb24? colorGroup = FindClosestColorGroup(pixelSpan[col]);
                    if (colorGroup != null)
                    {
                        if (!groupedColors.ContainsKey((Rgb24)colorGroup))
                        {
                            List<Rgb24> colorList = new()
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
    private Rgb24? FindClosestColorGroup(Rgb24 colorToTest)
    {
        Rgb24? closestColorGroup = null;
        List<KeyValuePair<Rgb24, int>> results = new();
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
        List<ColorStats> namePercentList = new();
        //Calculate the name and percent and add it into a list
        int count = 0;
        double totalOtherPercent = 0;
        foreach (KeyValuePair<Rgb24, List<Rgb24>> colorGroup in colorGroups)
        {
            count++;
            double percent = (double)colorGroup.Value.Count / (double)colorGroups.Sum(t => t.Value.Count);
            //if (onlyShowTop3 == true && count > 2)
            //{
            //    totalOtherPercent += percent;
            //}
            //else
            //{
                namePercentList.Add(new(colorGroup.Key, ColorPalettes.ToName(colorGroup.Key), percent));
            //}
        }
        //If there are priority items, update the order
        if (priorityColorPalette.Count > 0)
        {
            foreach (KeyValuePair<int, Rgb24> priorityItem in priorityColorPalette)
            {
                ColorStats? priorityColorStats = namePercentList.Where(x => x.Rgb == priorityItem.Value).FirstOrDefault();
                if (priorityColorStats != null)
                {
                    priorityColorStats.Order = priorityItem.Key;
                }
            }
        }
        //Order the percent list
        namePercentList = namePercentList.OrderBy(t => t.Order).ThenByDescending(x => x.Percent).ThenBy(x => x.Name).ToList();
        //Add the other percent if needed
        if (onlyShowTop3 == true && Math.Round(totalOtherPercent, 2) > 0)
        {
            namePercentList.Add(new(null, "Other", totalOtherPercent));
        }
        return namePercentList;
    }
}
