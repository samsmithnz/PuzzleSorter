using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics;
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

    public Dictionary<Rgb24, List<Rgb24>> ProcessImageIntoColorGroups(string srcFilename)
    {
        Dictionary<Rgb24, List<Rgb24>> groupedColors = new();
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
                    //else
                    //{
                    //    Debug.WriteLine("FindClosestColorGroup::Shouldn't get here");
                    //}
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
    private int GetColorDifference(Rgb24 color1, Rgb24 color2)
    {
        return (int)Math.Sqrt(Math.Pow(color1.R - color2.R, 2) + Math.Pow(color1.G - color2.G, 2) + Math.Pow(color1.B - color2.B, 2));
    }

    public static string BuildNamedColorsAndPercentsString(Dictionary<Rgb24, List<Rgb24>> colorGroups)
    {
        //loop through dictionary and calculate percents for each key
        StringBuilder sb = new();
        foreach (KeyValuePair<Rgb24, List<Rgb24>> colorGroup in colorGroups)
        {
            double percent = (double)colorGroup.Value.Count / (double)colorGroups.Sum(t => t.Value.Count);
            sb.AppendLine($"{ColorPalettes.ToName(colorGroup.Key)}: {percent:P}");
        }
        return sb.ToString();
    }

}
