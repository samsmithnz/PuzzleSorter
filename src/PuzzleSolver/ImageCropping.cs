using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;

namespace PuzzleSolver;

public class ImageCropping
{
    /// <summary>
    /// Crop/cut out a small piece of a larger image
    /// </summary>
    /// <param name="sourceImage"></param>
    /// <param name="areaToExtract"></param>
    /// <returns>Image<Rgb24></returns>
    public static Image<Rgb24> CropImage(Image<Rgb24> sourceImage, Rectangle areaToExtract)
    {
        //from https://docs.sixlabors.com/articles/imagesharp/pixelbuffers.html#efficient-pixel-manipulation
        Image<Rgb24> targetImage = new Image<Rgb24>(areaToExtract.Width, areaToExtract.Height);
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
        List<Image<Rgb24>> images = new List<Image<Rgb24>>();
        for (int y = 0; y < (sourceImage.Height / height); y++)
        {
            for (int x = 0; x < (sourceImage.Width / width); x++)
            {
                Rectangle rectangle = new Rectangle(x * width, y * height, width, height);
                images.Add(CropImage(sourceImage, rectangle));
            }
        }
        return images;
    }

}
