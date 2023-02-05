using SixLabors.ImageSharp.PixelFormats;
using System.Numerics;

namespace PuzzleSolver
{
    public class Robot
    {
        public Vector2 Location { get; set; }
        public Rgb24? Piece { get; set; }

        public Robot(Vector2 location)
        {
            Location = location;
        }
    }
}
