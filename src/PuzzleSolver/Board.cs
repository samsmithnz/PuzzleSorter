using PuzzleSolver.Images;
using PuzzleSolver.Map;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace PuzzleSolver
{
    public class Board
    {
        private Vector2 PickUpLocation = new Vector2(2, 1);
        public string[,] Map { get; set; }

        //Pieces
        public Vector2 UnsortedPiecesLocation { get; set; }
        public Queue<Rgb24> UnsortedPieces { get; set; }
        public Dictionary<Rgb24, Vector2> SortedPiecesLocations { get; set; }
        public int SortedPiecesCount { get; set; }
        public int UnsortedPiecesCount
        {
            get
            {
                return UnsortedPieces.Count;
            }
        }

        //Characters
        public Robot Robot { get; set; }


        public Board() { }

        //public Board(int width, int height, Vector2 unsortedPileLocation, List<Rgb24> colorPalette)
        //{
        //    Map = new string[width, height];
        //    UnsortedPiecesLocation = unsortedPileLocation;
        //    SortedPiecesLocations = new Dictionary<Vector2, Rgb24>();
        //    //int i = 0;
        //    //foreach (Rgb24 color in colorPalette)
        //    //{
        //    //    SortedPileLocations.Add(new Vector2(i, 0), color);
        //    //    i++;
        //    //}
        //}

        public void RunRobot()
        {
            ImageColorGroups imageProcessing = new ImageColorGroups(ColorPalettes.Get3ColorPalette());

            while (UnsortedPiecesCount > 0)
            {
                // Move to unsorted pile
                if (Robot.Location != PickUpLocation)
                {
                    PathFindingResult pathFindingResultForPickup = PathFinding.FindPath(Map, Robot.Location, PickUpLocation);
                    if (pathFindingResultForPickup != null && pathFindingResultForPickup.Path.Any())
                    {
                        //Move robot
                    }
                }

                // Pickup an unsorted piece
                Robot.Piece = UnsortedPieces.Dequeue();

                // Process the unsorted piece to work out where it goes
                Image<Rgb24> image = ImageCropping.CreateImage(Robot.Piece);
                ImageStats imageStats = imageProcessing.ProcessStatsForImage(null, image);
                Vector2? destinationLocation = null;
                foreach (KeyValuePair<Rgb24, Vector2> sortedPiece in SortedPiecesLocations)
                {
                    if (sortedPiece.Key == imageStats.TopColorGroupColor)
                    {
                        destinationLocation = sortedPiece.Value;
                    }
                }

                // Move the sorted piece to the correct pile
                if (destinationLocation != null)
                {
                    PathFindingResult pathFindingResultForDropoff = PathFinding.FindPath(Map, Robot.Location, (Vector2)destinationLocation);
                    if (pathFindingResultForDropoff != null && pathFindingResultForDropoff.Path.Any())
                    {
                        //Move robot
                    }
                }

                // Repeat
            }
        }
    }
}
