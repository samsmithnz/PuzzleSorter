using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Text;

namespace PuzzleSolver;

public class ImageProcessing
{
    public List<Rgb24> ColorPalette { get; set; }

    public ImageProcessing(List<Rgb24> colorPalette)
    {
        //Add the primary and secondary colors, with black and white for initial buckets
        ColorPalette = colorPalette;
    }

    public Dictionary<Rgb24, List<Rgb24>> ProcessImageIntoColorGroups(string? sourceFilename = null, Image<Rgb24>? image = null)
    {
        Dictionary<Rgb24, List<Rgb24>> groupedColors = new();
        //string destFilename = Path.GetFileNameWithoutExtension(srcFile.Name) + "_sorted.jpg";

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

        //using var destImg = new Image<Rgb24>(srcWidth, srcHeight);
        //Dictionary<Rgb24, int> pixels = new();
        sourceImage?.ProcessPixelRows(accessor =>
        {
            //int srcWidth = sourceImg.Size().Width;
            int srcHeight = sourceImage.Size().Height;

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

    public static List<KeyValuePair<string, double>> BuildNamedColorsAndPercentList(Dictionary<Rgb24, List<Rgb24>> colorGroups)
    {
        List<KeyValuePair<string, double>> namePercents = new();
        //Calculate the name and percent and add it into a list
        foreach (KeyValuePair<Rgb24, List<Rgb24>> colorGroup in colorGroups)
        {
            double percent = (double)colorGroup.Value.Count / (double)colorGroups.Sum(t => t.Value.Count);
            namePercents.Add(new KeyValuePair<string, double>(ColorPalettes.ToName(colorGroup.Key), percent));
        }
        //Order the percents
        namePercents = namePercents.OrderByDescending(t => t.Value).ThenBy(x => x.Key).ToList();
        return namePercents;
    }
    
    public static string BuildNamedColorsAndPercentsString(Dictionary<Rgb24, List<Rgb24>> colorGroups)
    {
        //loop through dictionary and calculate percents for each key
        List<KeyValuePair<string, double>> namePercents = BuildNamedColorsAndPercentList(colorGroups);

        //Return the string ordered by percent
        StringBuilder sb = new();
        foreach (KeyValuePair<string, double> item in namePercents)
        {
            sb.AppendLine($"{item.Key}: {item.Value:0.00%}");
        }
        return sb.ToString();
    }

    //from https://docs.sixlabors.com/articles/imagesharp/pixelbuffers.html#efficient-pixel-manipulation
    public static Image<Rgb24> CropImage(Image<Rgb24> sourceImage, Rectangle areaToExtract)
    {
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

    //public static byte[] ToArray(SixLabors.ImageSharp.Image imageIn)
    //{
    //    using (MemoryStream ms = new MemoryStream())
    //    {
    //        imageIn.Save(ms, JpegFormat.Instance);
    //        return ms.ToArray();
    //    }
    //}

    //public static byte[] ToArray(this SixLabors.ImageSharp.Image imageIn, IImageFormat fmt)
    //{
    //    using (MemoryStream ms = new MemoryStream())
    //    {
    //        imageIn.Save(ms, fmt);
    //        return ms.ToArray();
    //    }
    //}


    //public static System.Drawing.Bitmap ToBitmap<TPixel>(this Image<TPixel> image) where TPixel : unmanaged, IPixel<TPixel>
    //{
    //    using (var memoryStream = new MemoryStream())
    //    {
    //        var imageEncoder = image.GetConfiguration().ImageFormatsManager.FindEncoder(PngFormat.Instance);
    //        image.Save(memoryStream, imageEncoder);

    //        memoryStream.Seek(0, SeekOrigin.Begin);

    //        return new System.Drawing.Bitmap(memoryStream);
    //    }
    //}

    public static List<Image<Rgb24>> SplitImageIntoPieces(Image<Rgb24> sourceImage, int width, int height)
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
