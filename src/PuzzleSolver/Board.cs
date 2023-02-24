using PuzzleSolver.Images;
using PuzzleSolver.Map;
using PuzzleSolver.MultipleRobots;
using PuzzleSolver.Processing;
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
        public List<Robot> Robots { get; set; }

        //Constructor
        public Board(string[,] map,
            Vector2 unsortedPiecesLocation,
            List<Rgb24> colorPalette,
            List<Piece> unsortedPieceList,
            List<SortedDropZone> sortedDropZones,
            List<Robot> robots)
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
            Robots = robots;
        }

        //Function to calculate the robot moves
        public Queue<RobotAction> RunRobot()
        {
            Queue<RobotAction> results = new Queue<RobotAction>();

            //Get the pickup location
            Vector2 PickUpLocation = Robots[0].PickupLocation;
            Vector2 currentRobotLocation = Robots[0].Location;

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
                Robots[0].Piece = UnsortedPieces.Dequeue();
                robotAction.PieceId = Robots[0].Piece.Id;
                robotAction.PickupAction = new ObjectInteraction()
                {
                    Location = PickUpLocation
                };

                // Process the unsorted piece to work out where it goes
                Vector2? destinationLocation = null;
                foreach (SortedDropZone sortedDropZone in SortedDropZones)
                {
                    if (sortedDropZone.Color == Robots[0].Piece.ImageStats.TopColorGroupColor)
                    {
                        destinationLocation = sortedDropZone.Location;
                        break;
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
                    if (pathFindingResultForDropoff != null && pathFindingResultForDropoff.Path.Count >= 0)
                    {
                        //Move robot
                        robotAction.PathToDropoff = pathFindingResultForDropoff;
                        robotAction.DropoffAction = new ObjectInteraction()
                        {
                            Location = (Vector2)destinationLocation
                        };
                        //Move the piece from the robot to the sorted pile
                        Robots[0].Piece.Location = robotAction.DropoffAction.Location;
                        SortedPieces.Add(Robots[0].Piece);
                        foreach (SortedDropZone sortedDropZone in SortedDropZones)
                        {
                            if (sortedDropZone.Location == destinationLocation)
                            {
                                sortedDropZone.Count++;
                                break;
                            }
                        }
                        Robots[0].Piece = null;
                        robotAction.DropoffPieceCount = GetPieceCount(robotAction.DropoffAction.Location);
                        if (pathFindingResultForDropoff.Path.Count > 0)
                        {
                            currentRobotLocation = pathFindingResultForDropoff.Path.Last();
                        }
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
                if (destinationLocation.X == 0)
                {
                    //it's a right location drop-off
                    adjacentLocation = new Vector2((int)destinationLocation.X + 1, (int)destinationLocation.Y);
                }
                else if (destinationLocation.X == map.GetUpperBound(0))
                {
                    //it's a left location drop-off
                    adjacentLocation = new Vector2((int)destinationLocation.X - 1, (int)destinationLocation.Y);
                }
                else if (destinationLocation.Y == 0)
                {
                    //it's a top location drop-off
                    adjacentLocation = new Vector2((int)destinationLocation.X, (int)destinationLocation.Y + 1);
                }
                else if (destinationLocation.Y == map.GetUpperBound(1))
                {
                    //it's a bottom location drop-off
                    adjacentLocation = new Vector2((int)destinationLocation.X, (int)destinationLocation.Y - 11);
                }
            }
            return adjacentLocation;
        }

        public TimeLine RunRobots()
        {
            TimeLine timeline = new TimeLine();

            //Create a dictonary to track robot tick progress over time
            Dictionary<int, int> robotProgress = new Dictionary<int, int>();
            foreach (Robot robot in Robots)
            {
                robotProgress.Add(robot.RobotId, 0);
            }

            while (UnsortedPieces.Count > 0)
            {
                foreach (Robot robot in Robots)
                {
                    if (UnsortedPieces.Count > 0)
                    {
                        //retrieve piece from queue/pile and setup robot to take action on the piece
                        Piece piece = UnsortedPieces.Dequeue();
                        RobotAction robotAction = GetRobotAction(robot, piece);
                        int tick = robotProgress[robot.RobotId];
                        int ticksNeeded = 0;

                        //move to pickup
                        if (robotAction.PathToPickup != null)
                        {
                            ticksNeeded += robotAction.PathToPickup.Path.Count;
                        }
                        //pickup piece
                        if (robotAction.PickupAction != null)
                        {
                            ticksNeeded++;
                        }
                        //move to drop off
                        if (robotAction.PathToDropoff != null)
                        {
                            ticksNeeded += robotAction.PathToDropoff.Path.Count;
                        }
                        //drop off piece
                        if (robotAction.DropoffAction != null)
                        {
                            ticksNeeded++;
                        }
                        //Initialize the ticks needed for this robot to complete it's turn
                        for (int j = tick; j < tick + ticksNeeded; j++)
                        {
                            if (timeline.Ticks.Any(t => t.TickNumber == j + 1) == false)
                            {
                                timeline.Ticks.Add(new Tick(j + 1));
                            }
                        }

                        //Now populate the ticks with the pickup path
                        int pickupCounter = 0;
                        if (robotAction.PathToPickup != null &&
                            robotAction.PathToPickup.Path != null &&
                            robotAction.PathToPickup.Path.Count > 0)
                        {
                            pickupCounter++;
                            timeline.Ticks[tick].RobotActions.Add(new RobotTickAction()
                            {
                                Movement = new List<Vector2>() { robotAction.RobotPickupStartingLocation, robotAction.PathToPickup.Path[0] }
                            });
                            for (int j = 1; j < robotAction.PathToPickup.Path.Count - 1; j++)
                            {
                                pickupCounter++;
                                timeline.Ticks[tick + j].RobotActions.Add(new RobotTickAction()
                                {
                                    Movement = new List<Vector2>() { robotAction.PathToPickup.Path[j - 1], robotAction.PathToPickup.Path[j] }
                                });
                            }
                        }

                        if (robotAction.PickupAction != null)
                        {
                            timeline.Ticks[pickupCounter + tick].RobotActions.Add(new RobotTickAction()
                            {
                                Action = robotAction.PickupAction
                            });
                            pickupCounter++;
                        }

                        //Now populate the ticks with the dropoff path
                        int dropoffCounter = 0;
                        if (robotAction.PathToDropoff != null &&
                            robotAction.PathToDropoff.Path != null &&
                            robotAction.PathToDropoff.Path.Count > 0)
                        {
                            dropoffCounter++;
                            timeline.Ticks[pickupCounter + tick].RobotActions.Add(new RobotTickAction()
                            {
                                Movement = new List<Vector2>() { robotAction.RobotPickupStartingLocation, robotAction.PathToDropoff.Path[0] }
                            });
                            for (int j = 1; j < robotAction.PathToDropoff.Path.Count - 1; j++)
                            {
                                dropoffCounter++;
                                timeline.Ticks[pickupCounter + tick + j].RobotActions.Add(new RobotTickAction()
                                {
                                    Movement = new List<Vector2>() { robotAction.PathToDropoff.Path[j - 1], robotAction.PathToDropoff.Path[j] }
                                });
                            }
                        }

                        if (robotAction.DropoffAction != null)
                        {
                            timeline.Ticks[pickupCounter + dropoffCounter + tick].RobotActions.Add(new RobotTickAction()
                            {
                                Action = robotAction.DropoffAction
                            });
                            dropoffCounter++;
                        }
                        robotProgress[robot.RobotId] += pickupCounter + dropoffCounter;
                    }
                }
            }

            return timeline;
        }

        private RobotAction GetRobotAction(Robot robot, Piece piece)
        {
            RobotAction robotAction = new RobotAction();

            Vector2 currentRobotLocation = robot.Location;
            Vector2 pickupLocation = robot.PickupLocation;

            // Move to unsorted pile
            robotAction.RobotPickupStartingLocation = currentRobotLocation;
            if (currentRobotLocation != pickupLocation)
            {
                PathFindingResult pathFindingResultForPickup = PathFinding.FindPath(Map, currentRobotLocation, pickupLocation);
                if (pathFindingResultForPickup != null && pathFindingResultForPickup.Path.Any())
                {
                    //Move robot
                    robotAction.PathToPickup = pathFindingResultForPickup;
                    currentRobotLocation = pathFindingResultForPickup.Path.Last();
                }
            }
            robotAction.RobotPickupEndingLocation = currentRobotLocation;

            // Pickup an unsorted piece from the unsorted pile
            robot.Piece = piece;
            robotAction.PieceId = piece.Id;
            robotAction.PickupAction = new ObjectInteraction()
            {
                Location = piece.Location
            };

            // Process the unsorted piece to work out where it goes
            Vector2? destinationLocation = null;
            foreach (SortedDropZone sortedDropZone in SortedDropZones)
            {
                if (sortedDropZone.Color == robot.Piece.ImageStats.TopColorGroupColor)
                {
                    destinationLocation = sortedDropZone.Location;
                    break;
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
                if (pathFindingResultForDropoff != null && pathFindingResultForDropoff.Path.Count >= 0)
                {
                    //Move robot
                    robotAction.PathToDropoff = pathFindingResultForDropoff;
                    robotAction.DropoffAction = new ObjectInteraction()
                    {
                        Location = (Vector2)destinationLocation
                    };
                    //Move the piece from the robot to the sorted pile
                    robot.Piece.Location = robotAction.DropoffAction.Location;
                    SortedPieces.Add(robot.Piece);
                    foreach (SortedDropZone sortedDropZone in SortedDropZones)
                    {
                        if (sortedDropZone.Location == destinationLocation)
                        {
                            sortedDropZone.Count++;
                            break;
                        }
                    }
                    robot.Piece = null;
                    robotAction.DropoffPieceCount = GetPieceCount(robotAction.DropoffAction.Location);
                    if (pathFindingResultForDropoff.Path.Count > 0)
                    {
                        currentRobotLocation = pathFindingResultForDropoff.Path.Last();
                    }
                }
            }
            robotAction.RobotDropoffEndingLocation = currentRobotLocation;

            return robotAction;
        }
    }
}
