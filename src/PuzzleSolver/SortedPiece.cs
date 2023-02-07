using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;
using System.Numerics;

namespace PuzzleSolver
{
    public class SortedPiece
    {
        public int Id { get; set; }
        public Rgb24 Color { get; set; }
        public Vector2 Location { get; set; }
        public List<Image<Rgb24>> Images { get; set; }

        public SortedPiece(int id, Rgb24 color, Vector2 location, List<Image<Rgb24>> images= null)
        {
            Id = id;
            Color = color;
            Location = location;
            Images = images;
            if (Images == null)
            {
                Images = new List<Image<Rgb24>>();
            }
        }
    }
}
