using SixLabors.ImageSharp.PixelFormats;

namespace PuzzleSolver
{
    public class ColorStats
    {
        public int Order { get; set; }
        public Rgb24? Rgb { get; set; }
        public string Name { get; set; }
        public double Percent { get; set; }

        public ColorStats(Rgb24? rgb, string name, double percent, int order = 100)
        {
            Rgb = rgb;
            Name = name;
            Percent = percent;
            Order = order;
        }
    }
}
