using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;
using System.Numerics;

namespace PuzzleSolver
{
    public class SortedPiece
    {
        public Rgb24 Color { get; set; }
        public Vector2 Location { get; set; }
        public List<Image<Rgb24>> Images { get; set; }
    }
}
