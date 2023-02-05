using PuzzleSolver.Robots;
using SixLabors.ImageSharp;
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
        public Queue<Image<Rgb24>> UnsortedPieces { get; set; }
        public Robot Robot { get; set; }

        public Board() { }

        public Board(int width, int height, Vector2 unsortedPileLocation, List<Rgb24> colorPalette)
        {
            Map = new string[width, height];
            UnsortedPileLocation = unsortedPileLocation;
            SortedPileLocations = new Dictionary<Vector2, Rgb24>();
            //int i = 0;
            //foreach (Rgb24 color in colorPalette)
            //{
            //    SortedPileLocations.Add(new Vector2(i, 0), color);
            //    i++;
            //}
        }
    }
}
