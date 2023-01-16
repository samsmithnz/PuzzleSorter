﻿using SixLabors.ImageSharp;
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

    public Dictionary<Rgb24, List<Rgb24>> ProcessImageIntoColorGroups(string sourceFilename)
    {
        Dictionary<Rgb24, List<Rgb24>> groupedColors = new();
        FileInfo srcFile = new(sourceFilename);
        //string destFilename = Path.GetFileNameWithoutExtension(srcFile.Name) + "_sorted.jpg";

        using Image<Rgb24> sourceImg = Image.Load<Rgb24>(srcFile.FullName);

        //int srcWidth = sourceImg.Size().Width;
        int srcHeight = sourceImg.Size().Height;

        //using var destImg = new Image<Rgb24>(srcWidth, srcHeight);
        //Dictionary<Rgb24, int> pixels = new();
        sourceImg.ProcessPixelRows(accessor =>
        {
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

    public static string BuildNamedColorsAndPercentsString(Dictionary<Rgb24, List<Rgb24>> colorGroups)
    {
        //loop through dictionary and calculate percents for each key
        StringBuilder sb = new();
        List<KeyValuePair<string, double>> namePercents = new();
        //Calculate the name and percent and add it into a list
        foreach (KeyValuePair<Rgb24, List<Rgb24>> colorGroup in colorGroups)
        {
            double percent = (double)colorGroup.Value.Count / (double)colorGroups.Sum(t => t.Value.Count);
            namePercents.Add(new KeyValuePair<string, double>(ColorPalettes.ToName(colorGroup.Key), percent));
        }
        //Return the string ordered by percent
        foreach (KeyValuePair<string, double> item in namePercents.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            sb.AppendLine($"{item.Key}: {item.Value:0.00%}");
        }
        return sb.ToString();
    }

    public static Image<Rgba32> Extract(Image<Rgba32> sourceImage, Rectangle sourceArea)
    {
        Image<Rgba32> targetImage = new(sourceArea.Width, sourceArea.Height);

        int height = sourceArea.Height;

        sourceImage.ProcessPixelRows(accessor =>
        {
            for (int row = 0; row < height; row++)
            {
                Span<Rgba32> sourceRow = accessor.GetRowSpan(sourceArea.Y + row);
                Span<Rgba32> targetRow = accessor.GetRowSpan(row);

                //Span<Rgba32> sourceRow = sourceImage.GetPixelRowSpan(sourceArea.Y + row);
                //Span<Rgba32> targetRow = targetImage.GetPixelRowSpan(row);

                sourceRow.Slice(sourceArea.X, sourceArea.Width).CopyTo(targetRow);
            }
        });

        return targetImage;
    }

}
