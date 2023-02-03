using PuzzleSolver.Color;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleSolver.Image
{
    public class ImageStats
    {
        public ImageStats(Image<Rgb24> image)
        {
            Image = image;
        }

        public Image<Rgb24> Image { get; set; }
        public Dictionary<Rgb24, List<Rgb24>> ColorGroups { get; set; }
        public SortedList<int, Rgb24> PriorityColorPalette { get; set; }
        public List<ColorStats> NamedColorsAndPercentList { get; set; }

        public Rgb24 TopColorGroupColor
        {
            get
            {
                return ColorGroups.FirstOrDefault().Key;
            }
        }

        public string TopNamedColor
        {
            get
            {
                if (NamedColorsAndPercentList != null &&
                    NamedColorsAndPercentList.Count > 0)
                {
                    return NamedColorsAndPercentList[0].Name;
                }
                else
                {
                    return "No named colors found";
                }
            }
        }

        public string NamesToString
        {
            get
            {
                //Return the string ordered by percent
                StringBuilder sb = new StringBuilder();
                if (NamedColorsAndPercentList != null)
                {
                    foreach (ColorStats item in NamedColorsAndPercentList)
                    {
                        sb.AppendLine($"{item.Name}: {item.Percent:0.00%}");
                    }
                }
                return sb.ToString();
            }
        }

    }
}
