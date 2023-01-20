using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Text;

namespace PuzzleSolver
{
    public class ImageStats
    {
        public Image<Rgb24> Image { get; set; }
        public Dictionary<Rgb24, List<Rgb24>> ColorGroups { get; set; }
        public List<KeyValuePair<string, double>> NamedColorsAndPercentList { get; set; }

        public Rgb24? TopColorGroupColor
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
                    return NamedColorsAndPercentList[0].Key;
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
                StringBuilder sb = new();
                foreach (KeyValuePair<string, double> item in NamedColorsAndPercentList)
                {
                    sb.AppendLine($"{item.Key}: {item.Value:0.00%}");
                }
                return sb.ToString();
            }
        }

    }
}
