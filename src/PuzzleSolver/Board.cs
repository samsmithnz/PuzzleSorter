using PuzzleSolver.Images;
using PuzzleSolver.Map;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace PuzzleSolver
{
    public class Board
    {
        public string[,] Map { get; set; }

        //Color Palette
        public List<Rgb24> ColorPalette { get; set; }

        //Pieces
        public Vector2 UnsortedPiecesLocation { get; set; }
        public Queue<Piece> UnsortedPieces { get; set; }
        public List<Piece> SortedPieces { get; set; }
        public List<SortedDropZone> SortedDropZones { get; set; }

        //Characters
        public Robot Robot { get; set; }


        public Board(List<Rgb24> colorPalette = null)
        {
            if (colorPalette == null)
            {
                ColorPalette = ColorPalettes.Get3ColorPalette();
            }
            else
            {
                ColorPalette = colorPalette;
            }
            UnsortedPieces = new Queue<Piece>();
            SortedPieces = new List<Piece>();
        }

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

        public void ProcessUnsortedPieces()
        {
            ImageColorGroups imageProcessing = new ImageColorGroups(ColorPalette);
            List<Piece> list = UnsortedPieces.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Piece piece = list[i];
                UnsortedPieces.ToList()[i].ImageStats = imageProcessing.ProcessStatsForImage(null, piece.Image);
            }
        }

        public Queue<RobotAction> RunRobot()
        {
            Queue<RobotAction> results = new Queue<RobotAction>();

            ImageColorGroups imageProcessing = new ImageColorGroups(ColorPalette);

            Vector2 PickUpLocation = UnsortedPiecesLocation;
            if (UnsortedPiecesLocation.Y > 0)
            {
                PickUpLocation = new Vector2(UnsortedPiecesLocation.X, UnsortedPiecesLocation.Y - 1);
            }

            while (UnsortedPieces.Count > 0)
            {
                RobotAction robotAction = new RobotAction();

                // Move to unsorted pile
                if (Robot.Location != PickUpLocation)
                {
                    PathFindingResult pathFindingResultForPickup = PathFinding.FindPath(Map, Robot.Location, PickUpLocation);
                    if (pathFindingResultForPickup != null && pathFindingResultForPickup.Path.Any())
                    {
                        //Move robot
                        robotAction.PathToPickup = pathFindingResultForPickup;
                    }
                }

                // Pickup an unsorted piece from the unsorted pile
                Robot.Piece = UnsortedPieces.Dequeue();
                robotAction.PickupAction = new ObjectInteraction()
                {
                    Location = PickUpLocation
                };

                // Process the unsorted piece to work out where it goes
                Robot.Piece.ImageStats = imageProcessing.ProcessStatsForImage(null, Robot.Piece.Image);
                Vector2? destinationLocation = null;
                foreach (SortedDropZone sortedDropZone in SortedDropZones)
                {
                    if (sortedDropZone.Color == Robot.Piece.ImageStats.TopColorGroupColor)
                    {
                        destinationLocation = sortedDropZone.Location;
                    }
                }

                // Move the sorted piece to the correct pile
                if (destinationLocation != null)
                {
                    PathFindingResult pathFindingResultForDropoff = PathFinding.FindPath(Map, Robot.Location, (Vector2)destinationLocation);
                    if (pathFindingResultForDropoff != null && pathFindingResultForDropoff.Path.Any())
                    {
                        //Move robot
                        robotAction.PathToDropoff = pathFindingResultForDropoff;
                        robotAction.DropoffAction = new ObjectInteraction()
                        {
                            Location = (Vector2)destinationLocation
                        };
                    }
                }

                //Move the piece from the robot to the sorted pile
                Robot.Piece.Location = robotAction.DropoffAction.Location;
                SortedPieces.Add(Robot.Piece);
                Robot.Piece = null;

                // Add to queue
                results.Enqueue(robotAction);
            }

            return results;
        }
    }
}
