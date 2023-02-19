using PuzzleSolver.Images;
using PuzzleSolver.Map;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;
using System.Diagnostics;
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

        //Constructor
        public Board(string[,] map,
            Vector2 unsortedPiecesLocation,
            List<Rgb24> colorPalette,
            List<Piece> unsortedPieceList,
            List<SortedDropZone> sortedDropZones,
            Robot robot)
        {
            Map = map;
            UnsortedPiecesLocation = unsortedPiecesLocation;
            ColorPalette = colorPalette;
            UnsortedPieces = new Queue<Piece>();
            ImageColorGroups imageProcessing = new ImageColorGroups(ColorPalette);
            for (int i = 0; i < unsortedPieceList.Count; i++)
            {
                Piece piece = unsortedPieceList[i];
                piece.ImageStats = imageProcessing.ProcessStatsForImage(null, piece.Image);
                UnsortedPieces.Enqueue(piece);
            }
            SortedDropZones = sortedDropZones;
            SortedPieces = new List<Piece>();
            Robot = robot;
        }

        //Function to calculate the robot moves
        public Queue<RobotAction> RunRobot()
        {
            Queue<RobotAction> results = new Queue<RobotAction>();

            //Get the pickup location
            Vector2 PickUpLocation = UnsortedPiecesLocation;
            if (UnsortedPiecesLocation.Y > 0)
            {
                PickUpLocation = new Vector2(UnsortedPiecesLocation.X, UnsortedPiecesLocation.Y - 1);
            }
            Vector2 currentRobotLocation = Robot.Location;

            //Loop through the queue of unsorted pieces
            while (UnsortedPieces.Count > 0)
            {
                RobotAction robotAction = new RobotAction();

                // Move to unsorted pile
                robotAction.RobotPickupStartingLocation = currentRobotLocation;
                if (currentRobotLocation != PickUpLocation)
                {
                    PathFindingResult pathFindingResultForPickup = PathFinding.FindPath(Map, currentRobotLocation, PickUpLocation);
                    if (pathFindingResultForPickup != null && pathFindingResultForPickup.Path.Any())
                    {
                        //Move robot
                        robotAction.PathToPickup = pathFindingResultForPickup;
                        currentRobotLocation = pathFindingResultForPickup.Path.Last();
                    }
                }
                robotAction.RobotPickupEndingLocation = currentRobotLocation;

                // Pickup an unsorted piece from the unsorted pile
                Robot.Piece = UnsortedPieces.Dequeue();
                robotAction.PieceId = Robot.Piece.Id;
                robotAction.PickupAction = new ObjectInteraction()
                {
                    Location = PickUpLocation
                };

                // Process the unsorted piece to work out where it goes
                Vector2? destinationLocation = null;
                foreach (SortedDropZone sortedDropZone in SortedDropZones)
                {
                    if (sortedDropZone.Color == Robot.Piece.ImageStats.TopColorGroupColor)
                    {
                        destinationLocation = sortedDropZone.Location;
                    }
                }

                //Get the best adjacent location to the destination
                Vector2? pathDestinationLocation = destinationLocation;
                if (destinationLocation != null)
                {
                    Vector2? adjacentLocation = GetAdjacentLocation((Vector2)destinationLocation, Map, SortedDropZones);
                    if (adjacentLocation != null)
                    {
                        pathDestinationLocation = (Vector2)adjacentLocation;
                    }
                }

                // Move the sorted piece to the correct pile
                robotAction.RobotDropoffStartingLocation = currentRobotLocation;
                if (destinationLocation != null && pathDestinationLocation != null)
                {

                    //now find the path
                    PathFindingResult pathFindingResultForDropoff = PathFinding.FindPath(Map, currentRobotLocation, (Vector2)pathDestinationLocation);
                    if (pathFindingResultForDropoff != null && pathFindingResultForDropoff.Path.Any())
                    {
                        //Move robot
                        robotAction.PathToDropoff = pathFindingResultForDropoff;
                        robotAction.DropoffAction = new ObjectInteraction()
                        {
                            Location = (Vector2)destinationLocation
                        };
                        //Move the piece from the robot to the sorted pile
                        Robot.Piece.Location = robotAction.DropoffAction.Location;
                        SortedPieces.Add(Robot.Piece);
                        foreach (SortedDropZone sortedDropZone in SortedDropZones)
                        {
                            if (sortedDropZone.Location == destinationLocation)
                            {
                                sortedDropZone.Count++;
                                break;
                            }
                        }
                        Robot.Piece = null;
                        robotAction.DropoffPieceCount = GetPieceCount(robotAction.DropoffAction.Location);
                        currentRobotLocation = pathFindingResultForDropoff.Path.Last();
                    }
                }
                robotAction.RobotDropoffEndingLocation = currentRobotLocation;

                // Add to queue
                results.Enqueue(robotAction);
            }

            //Add last action to return to the starting point
            RobotAction robotActionReset = new RobotAction();
            robotActionReset.RobotPickupStartingLocation = currentRobotLocation;
            if (currentRobotLocation != PickUpLocation)
            {
                PathFindingResult pathFindingResultForPickup = PathFinding.FindPath(Map, currentRobotLocation, PickUpLocation);
                if (pathFindingResultForPickup != null && pathFindingResultForPickup.Path.Any())
                {
                    //Move robot
                    robotActionReset.PathToPickup = pathFindingResultForPickup;
                    currentRobotLocation = pathFindingResultForPickup.Path.Last();
                }
            }
            robotActionReset.RobotPickupEndingLocation = currentRobotLocation;
            results.Enqueue(robotActionReset);

            return results;
        }

        public int GetPieceCount(Vector2 dropOfflocation)
        {
            int pieceCount = 0;

            foreach (SortedDropZone sortedDropZone in SortedDropZones)
            {
                if (sortedDropZone.Location == dropOfflocation)
                {
                    pieceCount = sortedDropZone.Count;
                    break;
                }
            }

            return pieceCount;
        }

        private Vector2? GetAdjacentLocation(Vector2 destinationLocation, string[,] map, List<SortedDropZone> sortedDropZones)
        {
            Vector2? adjacentLocation = null;
            if (destinationLocation != null)
            {
                Vector2 topLocation = new Vector2((int)destinationLocation.X, (int)destinationLocation.Y + 1);
                Vector2 bottomLocation = new Vector2((int)destinationLocation.X, (int)destinationLocation.Y - 1);


                //Check if I can deliver from the top first
                if (CheckLocationIsValid(topLocation, map, sortedDropZones))
                {
                    return topLocation;
                }
                //Then check the bottom
                else if (CheckLocationIsValid(bottomLocation, map, sortedDropZones))
                {
                    return bottomLocation;
                }
                else
                {
                    return destinationLocation;
                }
                //if (topTile.X > 0 && topTile.Y > 0 &&
                //    topTile.X < map.GetUpperBound(0) &&
                //    topTile.Y < map.GetUpperBound(1) &&
                //    map[(int)topTile.X, (int)topTile.Y] == "" &&
                //    sortedDropZones.Find(d => d.Location == topTile) == null)
                //{
                //    return topTile;
                //}
                //else
                //{
                //    return destinationLocation;
                //}

                ////Get the adjacent tiles
                //List<Vector2> adjacentTiles = new List<Vector2>();
                //adjacentTiles.Add(new Vector2(destinationLocation.X - 1, destinationLocation.Y));
                //adjacentTiles.Add(new Vector2(destinationLocation.X + 1, destinationLocation.Y));
                //adjacentTiles.Add(new Vector2(destinationLocation.X, destinationLocation.Y - 1));
                //adjacentTiles.Add(new Vector2(destinationLocation.X, destinationLocation.Y + 1));

                ////Loop through the adjacent tiles and find the first one that is not a wall
                //foreach (Vector2 item in adjacentTiles)
                //{
                //    if ((int)item.X > 0 || (int)item.Y > 0 ||
                //        (int)item.X < map.GetUpperBound(0) ||
                //        (int)item.Y < map.GetUpperBound(1))
                //    {
                //        adjacentTile = item;
                //        break;
                //    }
                //}
            }
            return adjacentLocation;
        }

        private bool CheckLocationIsValid(Vector2 location, string[,] map, List<SortedDropZone> sortedDropZones)
        {
            if (location.X >= 0 && 
                location.Y >= 0 &&
                location.X <= map.GetUpperBound(0) &&
                location.Y <= map.GetUpperBound(1) &&
                map[(int)location.X, (int)location.Y] == "" &&
                sortedDropZones.Find(d => d.Location == location) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
