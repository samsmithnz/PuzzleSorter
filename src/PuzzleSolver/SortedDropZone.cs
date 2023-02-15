using SixLabors.ImageSharp.PixelFormats;
using System.Numerics;

namespace PuzzleSolver
{
    public class SortedDropZone
    {
        public Rgb24 Color { get; set; }
        public Vector2 Location { get; set; }
        public int Count { get; set; }

        public SortedDropZone(Rgb24 color, Vector2 location)
        {
            Color = color;
            Location = location;
            Count = 0;
        }
    }
}
