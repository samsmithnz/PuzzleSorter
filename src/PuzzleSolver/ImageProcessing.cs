using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PuzzleSolver;

public class ImageProcessing
{
    public List<Rgb24> ColorPalette { get; set; }

    public ImageProcessing(List<Rgb24> colorPalette)
    {
        //Add the primary and secondary colors, with black and white for initial buckets
        ColorPalette = colorPalette;
    }

    public ImageStats? ProcessStatsForImage(string? sourceFilename = null, Image<Rgb24>? image = null, bool onlyShowTop3 = true)
    {
        ImageStats? imageStats = null;
        Image<Rgb24>? sourceImage = null;
        if (sourceFilename != null)
        {
            FileInfo srcFile = new(sourceFilename);
            sourceImage = Image.Load<Rgb24>(srcFile.FullName);
        }
        else if (image != null)
        {
            sourceImage = image;
        }

        if (sourceImage != null)
        {
            imageStats = new(sourceImage)
            {
                ColorGroups = ProcessImageIntoColorGroups(sourceImage)
            };
            imageStats.NamedColorsAndPercentList = BuildNamedColorsAndPercentList(imageStats.ColorGroups, onlyShowTop3);
        }
        return imageStats;
    }

    private Dictionary<Rgb24, List<Rgb24>> ProcessImageIntoColorGroups(Image<Rgb24>? image)
    {
        Dictionary<Rgb24, List<Rgb24>> groupedColors = new();

        //using var destImg = new Image<Rgb24>(srcWidth, srcHeight);
        //Dictionary<Rgb24, int> pixels = new();
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

        //Check if the largest postive or negative value is closer
        if (results.Count > 0)
        {
            closestColorGroup = results[0].Key;
        }
        return closestColorGroup;
    }

    //Since it uses Sqrt, it always returns a postive number
    private static int GetColorDifference(Rgb24 color1, Rgb24 color2)
    {
        return (int)Math.Sqrt(Math.Pow(color1.R - color2.R, 2) + Math.Pow(color1.G - color2.G, 2) + Math.Pow(color1.B - color2.B, 2));
    }

    private static List<KeyValuePair<string, double>> BuildNamedColorsAndPercentList(Dictionary<Rgb24, List<Rgb24>> colorGroups, bool onlyShowTop3)
    {
        List<KeyValuePair<string, double>> namePercents = new();
        //Calculate the name and percent and add it into a list
        int count = 0;
        double totalOtherPercent = 0;
        foreach (KeyValuePair<Rgb24, List<Rgb24>> colorGroup in colorGroups)
        {
            count++;
            double percent = (double)colorGroup.Value.Count / (double)colorGroups.Sum(t => t.Value.Count);
            if (onlyShowTop3 == true && count > 2)
            {
                totalOtherPercent += percent;
            }
            else
            {
                namePercents.Add(new KeyValuePair<string, double>(ColorPalettes.ToName(colorGroup.Key), percent));
            }
        }
        //Order the percents
        namePercents = namePercents.OrderByDescending(t => t.Value).ThenBy(x => x.Key).ToList();
        //Add the other percent if needed
        if (onlyShowTop3 == true && Math.Round(totalOtherPercent, 2) > 0)
        {
            namePercents.Add(new KeyValuePair<string, double>("Other", totalOtherPercent));
        }
        return namePercents;
    }

    /// <summary>
    /// Crop/cut out a small piece of a larger image
    /// </summary>
    /// <param name="sourceImage"></param>
    /// <param name="areaToExtract"></param>
    /// <returns>Image<Rgb24></returns>
    public static Image<Rgb24> CropImage(Image<Rgb24> sourceImage, Rectangle areaToExtract)
    {
        //from https://docs.sixlabors.com/articles/imagesharp/pixelbuffers.html#efficient-pixel-manipulation
        Image<Rgb24> targetImage = new(areaToExtract.Width, areaToExtract.Height);
        int height = areaToExtract.Height;
        sourceImage.ProcessPixelRows(targetImage, (sourceAccessor, targetAccessor) =>
        {
            for (int row = 0; row < height; row++)
            {
                //get the row from the Y + row index
                Span<Rgb24> sourceRow = sourceAccessor.GetRowSpan(areaToExtract.Y + row);
                //Setup the target row
                Span<Rgb24> targetRow = targetAccessor.GetRowSpan(row);
                //Copy the source to the target
                //Copy the source to the target
                sourceRow.Slice(areaToExtract.X, areaToExtract.Width).CopyTo(targetRow);
            }
        });

        return targetImage;
    }

    /// <summary>
    /// Split a larger image into equal sized smaller pieces
    /// </summary>
    /// <param name="sourceImage"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns>List<Image<Rgb24>></returns>
    public static List<Image<Rgb24>> SplitImageIntoMultiplePieces(Image<Rgb24> sourceImage, int width, int height)
    {
        List<Image<Rgb24>> images = new();
        for (int y = 0; y < (sourceImage.Height / height); y++)
        {
            for (int x = 0; x < (sourceImage.Width / width); x++)
            {
                Rectangle rectangle = new(x * width, y * height, width, height);
                images.Add(CropImage(sourceImage, rectangle));
            }
        }
        return images;
    }

}
