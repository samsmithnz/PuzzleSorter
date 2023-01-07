using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PuzzleSolver;

public class ImageProcessing
{
    public List<Rgb24> ColorGroups { get; set; }

    public ImageProcessing()//List<Rgb24> colorGroups)
    {
        //Add the primary and secondary colors, with black and white for initial buckets
        ColorGroups = new List<Rgb24> {
            Color.Red.ToPixel<Rgb24>(),
            Color.Purple.ToPixel<Rgb24>(),
            Color.Blue.ToPixel<Rgb24>(),
            Color.Green.ToPixel<Rgb24>(),
            Color.Yellow.ToPixel<Rgb24>(),
            Color.Orange.ToPixel<Rgb24>(),
            Color.White.ToPixel<Rgb24>(),
            Color.Black.ToPixel<Rgb24>() };
    }

    private Rgb24 ConvertColorToRGB(Color color)
    {
        return color.ToPixel<Rgb24>();
    }

    public Dictionary<Rgb24, Rgb24> ProcessImageIntoColorGroups(string srcFilename)
    {
        Dictionary<Rgb24, Rgb24> groupedColors = new();
        FileInfo srcFile = new(srcFilename);
        string destFilename = Path.GetFileNameWithoutExtension(srcFile.Name) + "_sorted.jpg";

        using Image<Rgb24> srcImg = Image.Load<Rgb24>(srcFile.FullName);

        int srcWidth = srcImg.Size().Width;
        int srcHeight = srcImg.Size().Height;

        //using var destImg = new Image<Rgb24>(srcWidth, srcHeight);
        Dictionary<Rgb24, int> pixels = new();
        srcImg.ProcessPixelRows(accessor =>
        {
            for (var row = 0; row < srcHeight; row++)
            {
                //var pixels = srcImg.GetPixelRowSpan(row).ToArray();
                Span<Rgb24> pixelSpan = accessor.GetRowSpan(row);
                //var orderedPixels = pixels.OrderBy(p => p.R + p.G + p.B).ToArray();

                for (var col = 0; col < pixelSpan.Length; col++)
                {
                    //destImg[col, row] = orderedPixels[col];
                    if (pixels.ContainsKey(pixelSpan[col]))
                    {
                        pixels[pixelSpan[col]]++;
                    }
                    else
                    {
                        pixels.Add(pixelSpan[col], 1);
                    }
                }
            }
        });

        //Count the final values
        int total = 0;
        foreach (KeyValuePair<Rgb24, int> item in pixels)
        {
            if (item.Key.R == 255 && item.Key.G == 0 && item.Key.B == 0)
            {
                total += item.Value;
            }
        }

        return groupedColors;
    }

    //Group RGB colors into multiple groups
    private Rgb24? FindClosestColorGroup(Rgb24 colorToTest)
    {
        Rgb24? closestColorGroup = null;
        List<KeyValuePair<Rgb24, int>> results = new();
        foreach (Rgb24 color in ColorGroups)
        {
            int colorDifference = GetColorDifference(color, colorToTest);
            if (colorDifference < 0 )
            {
                colorDifference = colorDifference * -1;
            }
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

    private int GetColorDifference(Rgb24 color1, Rgb24 color2)
    {
        return (int)Math.Sqrt(Math.Pow(color1.R - color2.R, 2) + Math.Pow(color1.G - color2.G, 2) + Math.Pow(color1.B - color2.B, 2));
    }

}
