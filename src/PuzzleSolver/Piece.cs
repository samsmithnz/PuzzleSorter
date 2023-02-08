using PuzzleSolver.Images;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Numerics;

namespace PuzzleSolver
{
    public class Piece
    {
        public int Id { get; set; }
        public Image<Rgb24> Image { get; set; }
        public ImageStats ImageStats { get; set; }
        public Vector2 Location { get; set; }
        public Rgb24 TopColorGroup
        {
            get
            {
                return ImageStats.TopColorGroupColor;
            }
        }
    }
}
