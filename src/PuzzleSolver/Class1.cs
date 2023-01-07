using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Dynamic;

namespace PuzzleSolver;

public class Class1
{
    public int ProcessImage(string srcFilename)
    {
        var srcFile = new FileInfo(srcFilename);
        var destFilename = Path.GetFileNameWithoutExtension(srcFile.Name) + "_sorted.jpg";

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

        return total;
    }

    //Group RGB colors into 3 groups
    private static int GetColorGroup(Rgb24 color)
    {
        int r = color.R;
        int g = color.G;
        int b = color.B;

        if (r > 200 && g < 50 && b < 50)
        {
            return 1;
        }
        else if (r < 50 && g > 200 && b < 50)
        {
            return 2;
        }
        else if (r < 50 && g < 50 && b > 200)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }

    //Group RGB colors into multiple groups
    private void GetColorGroups()
    {

    }

    private int GetColorDifference(Rgb24 color1, Rgb24 color2)
    {
        return (int)Math.Sqrt(Math.Pow(color1.R - color2.R, 2) + Math.Pow(color1.G - color2.G, 2) + Math.Pow(color1.B - color2.B, 2));
    }

}
