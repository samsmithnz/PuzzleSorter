using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;

namespace PuzzleSolver;

public class Class1
{
    public int ProcessImage(string srcFilename)
    {
        var srcFile = new FileInfo(srcFilename);
        var destFilename = Path.GetFileNameWithoutExtension(srcFile.Name) + "_sorted.jpg";

        using var srcImg = Image.Load<Rgb24>(srcFile.FullName);

        var srcWidth = srcImg.Size().Width;
        var srcHeight = srcImg.Size().Height;

        //using var destImg = new Image<Rgb24>(srcWidth, srcHeight);

        //for (var row = 0; row < srcHeight; row++)
        //{
        //    var pixels = srcImg.GetPixelRowSpan(row).ToArray();
        //    var orderedPixels = pixels.OrderBy(p => p.R + p.G + p.B).ToArray();

        //    for (var col = 0; col < orderedPixels.Length; col++)
        //    {
        //        destImg[col, row] = orderedPixels[col];
        //    }
        //}

        //destImg.SaveAsJpeg(destFilename, new JpegEncoder() { Quality = 95 });

        return srcWidth* srcHeight;
    }
}
