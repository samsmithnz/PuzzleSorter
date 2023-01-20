using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PuzzleSolver.App
{
    public class GroupedObject
    {
        public Image<Rgb24> Image { get; set; }

        public Dictionary<Rgb24, List<Rgb24>> GroupedColors { get; set; }

        public List<KeyValuePair<string, double>> NamedPercentageStats { get; set; }
    }
}
