using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;
using System.Numerics;

namespace PuzzleSolver
{
    public class Board
    {
        public string[,] Map { get; set; }
        public Vector2 UnsortedPileLocation { get; set; }
        public Dictionary<Vector2, Rgb24> SortedPileLocations { get; set; }
    }
}
