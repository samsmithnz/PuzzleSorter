using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

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
}
