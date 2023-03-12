using PuzzleSolver.Actions;
using PuzzleSolver.Entities;
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
        public List<Robot> Robots { get; set; }

        private Dictionary<int, int> _RobotProgress = new Dictionary<int, int>();

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

        public TimeLine RunRobots2()
        {
            TimeLine timeline = new TimeLine();
            //Create a dictonary to track robot turn progress over time
            Dictionary<int, int> robotProgress = new Dictionary<int, int>();
            foreach (Robot robot in Robots)
            {
                robotProgress.Add(robot.RobotId, 0);
            }

            //Need to loop through all unsorted pieces until they are sorted
            while (UnsortedPieces.Count > 0)
            {
                //Sort the progress list to find the robot with the least number of turns - this is the robot who should pick up next
                List<KeyValuePair<int, int>> orderedRobotProgress = robotProgress.OrderBy(x => x.Value).ToList();
                //For each robot
                foreach (Robot robot in Robots)
                {
                    switch (robot.RobotStatus)
                    {
                        case RobotStatus.RobotStatusEnum.LookingForJob:
                            robot.RobotStatus = RobotStatus.RobotStatusEnum.MovingToPickupLocation;
                            break;
                        case RobotStatus.RobotStatusEnum.MovingToPickupLocation:
                            //If there are unsorted pieces, move to pickup
                            RobotAction robotActionPickup = new RobotAction();
                            robotActionPickup.RobotPickupStartingLocation = robot.Location;
                            PathFindingResult pathFindingResultForPickup = FindPickupPathToLocation(robot, robot.PickupLocation, timeline);
                            robotActionPickup.RobotPickupEndingLocation = pathFindingResultForPickup.Path.Last();
                            robot.Location = pathFindingResultForPickup.Path.Last();
                            if (robot.Location == robot.PickupLocation)
                            {
                                robot.RobotStatus = RobotStatus.RobotStatusEnum.PickingUpPackage;
                            }
                            break;
                        case RobotStatus.RobotStatusEnum.PickingUpPackage:
                            //If we are at the pickup location, and there are pieces, pick up the piece
                            RobotAction robotActionDropoff = new RobotAction();

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
                            if (destinationLocation == null)
                            {
                                throw new System.Exception("Destination not found for piece " + robot.Piece.Id);
                            }

                            //Get the best adjacent location to the destination
                            Vector2? pathDestinationLocation = destinationLocation;
                            if (destinationLocation != null)
                            {
                                Vector2? adjacentLocation = GetAdjacentLocation((Vector2)destinationLocation, Map, SortedDropZones);
                                if (adjacentLocation != null)
                                {
                                    pathDestinationLocation = (Vector2)adjacentLocation;
                                    robotActionDropoff.RobotDropoffStartingLocation = robot.Location;

                                    PathFindingResult pathFindingResultForDropoff = FindPickupPathToLocation(robot, (Vector2)pathDestinationLocation, timeline);
                                    robot.RobotStatus = RobotStatus.RobotStatusEnum.MovingToPickupLocation;
                                    robotActionDropoff.RobotDropoffEndingLocation = pathFindingResultForDropoff.Path.Last();
                                    robot.Location = pathFindingResultForDropoff.Path.Last();
                                }
                            }
                            if (robot.Location == pathDestinationLocation)
                            {
                                robot.RobotStatus = RobotStatus.RobotStatusEnum.MovingToDeliveryLocation;
                            }
                            break;
                        case RobotStatus.RobotStatusEnum.MovingToDeliveryLocation:
                            //If the piece is picked up, move to dropoff
                            break;
                        case RobotStatus.RobotStatusEnum.DeliveringPackage:
                            //If we are at the dropoff location, drop off the piece


                            //If the piece is dropped off, move to pickup
                            break;
                    }
                }
            }

            return timeline;
        }

        public PathFindingResult FindPathFindingWithTimeline(string[,] map, Vector2 startLocation, Vector2 endLocation, int robotId, List<Robot> robots, TimeLine timeline)
        {
            //Get the path
            PathFindingResult pathFindingResult = PathFinding.FindPath(map, startLocation, endLocation);

            //Get the robot turn
            int turn = _RobotProgress[robotId];

            //Check the timeline to see if there are conflicts
            int j = 0;
            for (int i = turn - 1; i <= timeline.Turns.Count - 1; i++)
            {
                foreach (RobotTurnAction robotTurnAction in timeline.Turns[i].RobotActions)
                {
                    if (robotTurnAction.RobotId != robotId)
                    {
                        if (pathFindingResult.Path.Count - 1 > j &&
                            robotTurnAction.Movement.Count > 0 &&
                            pathFindingResult.Path[j].X == robotTurnAction.Movement[0].X &&
                            pathFindingResult.Path[j].Y == robotTurnAction.Movement[0].Y)
                        {
                            //Add a wait action to the path
                            pathFindingResult.Path.Insert(j, new Vector2(pathFindingResult.Path[j - 1].X, pathFindingResult.Path[j - 1].Y));
                        }
                    }
                }
            }

            return pathFindingResult;
        }

        public PathFindingResult FindPickupPathToLocation(Robot robot, Vector2 destination, TimeLine timeline)
        {
            PathFindingResult pathFindingResult = null;
            if (robot.Location != destination)
            {
                robot.RobotStatus = RobotStatus.RobotStatusEnum.MovingToPickupLocation;
                //Move the robot to the pickup zone - By doing this first we ensure we don't pick up a piece until we are there.
                //Vector2 currentRobotLocation = robot.Location;
                //Vector2 pickupLocation = robot.PickupLocation;

                // Move to unsorted pile
                //robotAction.RobotPickupStartingLocation = currentRobotLocation;
                PathFindingResult pathFindingResultForPickup = FindPathFindingWithTimeline(Map, robot.Location, robot.PickupLocation, robot.RobotId, Robots, timeline);
                if (pathFindingResultForPickup != null && pathFindingResultForPickup.Path.Any())
                {
                    //Move robot
                    pathFindingResult = pathFindingResultForPickup;
                    //currentRobotLocation = pathFindingResultForPickup.Path.Last();
                }
                //robotAction.RobotPickupEndingLocation = currentRobotLocation;
                //robot.Location = currentRobotLocation;
            }
            return pathFindingResult;
        }

        public TimeLine RunRobots()
        {
            TimeLine timeline = new TimeLine();

            //Create a dictonary to track robot turn progress over time
            foreach (Robot robot in Robots)
            {
                _RobotProgress.Add(robot.RobotId, 0);
            }

            //Need to loop through all unsorted pieces until they are sorted
            while (UnsortedPieces.Count > 0)
            {
                //Sort the progress list to find the robot with the least number of turns - this is the robot who should pick up next
                List<KeyValuePair<int, int>> orderedRobotProgress = _RobotProgress.OrderBy(x => x.Value).ToList();
                //For each robot
                foreach (Robot robot in Robots)
                {
                    //Find the robot with the least progress, and then break
                    if (robot.Piece == null && orderedRobotProgress[0].Key == robot.RobotId)
                    {
                        RobotAction robotAction = new RobotAction();
                        Piece piece = null;
                        //See if the robot needs to move to the pickup zone
                        if (robot.Location != robot.PickupLocation)
                        {
                            robot.RobotStatus = RobotStatus.RobotStatusEnum.MovingToPickupLocation;
                            //Move the robot to the pickup zone - By doing this first we ensure we don't pick up a piece until we are there.
                            Vector2 currentRobotLocation = robot.Location;
                            Vector2 pickupLocation = robot.PickupLocation;

                            // Move to unsorted pile
                            robotAction.RobotPickupStartingLocation = currentRobotLocation;
                            if (currentRobotLocation != pickupLocation)
                            {
                                PathFindingResult pathFindingResultForPickup = FindPathFindingWithTimeline(Map, currentRobotLocation, pickupLocation, robot.RobotId, Robots, timeline);
                                if (pathFindingResultForPickup != null && pathFindingResultForPickup.Path.Any())
                                {
                                    //Move robot
                                    robotAction.PathToPickup = pathFindingResultForPickup;
                                    currentRobotLocation = pathFindingResultForPickup.Path.Last();
                                }
                            }
                            robotAction.RobotPickupEndingLocation = currentRobotLocation;
                            robot.Location = currentRobotLocation;
                        }
                        //Else do the pickup, dropoff and delivery
                        else if (robot.Piece == null && UnsortedPieces.Count > 0)
                        {
                            piece = UnsortedPieces.Dequeue();
                            robotAction = GetRobotAction(robot, piece, timeline);
                        }
                        ////Robot is holding the piece
                        //else if (robot.Piece != null)
                        //{
                        //    robotAction = GetRobotAction(robot, robot.Piece);
                        //    if (robot.Location != robotAction.RobotDropoffEndingLocation)
                        //    {
                        //        //need to find a dropoff path
                        //    }
                        //    else
                        //    {
                        //        //is at the dropoff point
                        //    }
                        //}

                        //process the robot action
                        if (robotAction != null)
                        {
                            int turn = _RobotProgress[robot.RobotId];
                            int turnsNeeded = 0;

                            //move to pickup
                            if (robotAction.PathToPickup != null)
                            {
                                turnsNeeded += robotAction.PathToPickup.Path.Count;
                            }
                            //pickup piece
                            if (robotAction.PickupAction != null)
                            {
                                turnsNeeded++;
                            }
                            //move to drop off
                            if (robotAction.PathToDropoff != null)
                            {
                                turnsNeeded += robotAction.PathToDropoff.Path.Count;
                            }
                            //drop off piece
                            if (robotAction.DropoffAction != null)
                            {
                                turnsNeeded++;
                            }
                            //Initialize the turns needed for this robot to complete it's turn
                            for (int j = turn; j < turn + turnsNeeded; j++)
                            {
                                if (timeline.Turns.Any(t => t.TurnNumber == j + 1) == false)
                                {
                                    timeline.Turns.Add(new Turn(j + 1));
                                }
                            }

                            //Now populate the turns with the pickup path
                            int pickupCounter = 0;
                            if (robotAction.PathToPickup != null &&
                                robotAction.PathToPickup.Path != null &&
                                robotAction.PathToPickup.Path.Count > 0)
                            {
                                pickupCounter++;
                                timeline.Turns[turn].RobotActions.Add(new RobotTurnAction(robot.RobotId, RobotStatus.RobotStatusEnum.MovingToPickupLocation, null)
                                {
                                    Movement = new List<Vector2>() { robotAction.RobotPickupStartingLocation, robotAction.PathToPickup.Path[0] }
                                });
                                for (int j = 1; j <= robotAction.PathToPickup.Path.Count - 1; j++)
                                {
                                    pickupCounter++;
                                    timeline.Turns[turn + j].RobotActions.Add(new RobotTurnAction(robot.RobotId, RobotStatus.RobotStatusEnum.MovingToPickupLocation, null)
                                    {
                                        Movement = new List<Vector2>() { robotAction.PathToPickup.Path[j - 1], robotAction.PathToPickup.Path[j] }
                                    });
                                }
                            }

                            if (robotAction.PickupAction != null)
                            {
                                timeline.Turns[pickupCounter + turn].RobotActions.Add(new RobotTurnAction(robot.RobotId, RobotStatus.RobotStatusEnum.PickingUpPackage, piece.Id)
                                {
                                    PickupAction = robotAction.PickupAction
                                });
                                pickupCounter++;
                                robot.Location = robotAction.RobotPickupEndingLocation;
                            }

                            //Now populate the turns with the dropoff path
                            int dropoffCounter = 0;
                            if (robotAction.PathToDropoff != null &&
                                robotAction.PathToDropoff.Path != null &&
                                robotAction.PathToDropoff.Path.Count > 0)
                            {
                                dropoffCounter++;
                                timeline.Turns[pickupCounter + turn].RobotActions.Add(new RobotTurnAction(robot.RobotId, RobotStatus.RobotStatusEnum.MovingToDeliveryLocation, piece.Id)
                                {
                                    Movement = new List<Vector2>() { robotAction.RobotDropoffStartingLocation, robotAction.PathToDropoff.Path[0] }
                                });
                                for (int j = 1; j <= robotAction.PathToDropoff.Path.Count - 1; j++)
                                {
                                    dropoffCounter++;
                                    timeline.Turns[pickupCounter + turn + j].RobotActions.Add(new RobotTurnAction(robot.RobotId, RobotStatus.RobotStatusEnum.MovingToDeliveryLocation, piece.Id)
                                    {
                                        Movement = new List<Vector2>() { robotAction.PathToDropoff.Path[j - 1], robotAction.PathToDropoff.Path[j] }
                                    });
                                }
                            }

                            if (robotAction.DropoffAction != null)
                            {
                                robotAction.DropoffAction.DestinationPieceCount = GetPieceCount(robotAction.DropoffAction.Location);
                                timeline.Turns[pickupCounter + dropoffCounter + turn].RobotActions.Add(new RobotTurnAction(robot.RobotId, RobotStatus.RobotStatusEnum.DeliveringPackage, piece.Id)
                                {
                                    DropoffAction = robotAction.DropoffAction
                                });
                                dropoffCounter++;
                                robot.Location = robotAction.RobotDropoffEndingLocation;
                            }
                            _RobotProgress[robot.RobotId] += pickupCounter + dropoffCounter;
                        }
                        break;
                    }
                }
            }

            //Move the robots back to the start location
            foreach (Robot robot in Robots)
            {
                if (robot.Location != robot.PickupLocation)
                {
                    RobotAction robotAction = new RobotAction();
                    //Move the robot to the pickup zone - By doing this first we ensure we don't pick up a piece until we are there.
                    Vector2 currentRobotLocation = robot.Location;
                    Vector2 pickupLocation = robot.PickupLocation;

                    // Move to unsorted pile
                    robotAction.RobotPickupStartingLocation = currentRobotLocation;
                    if (currentRobotLocation != pickupLocation)
                    {
                        PathFindingResult pathFindingResultForPickup = FindPathFindingWithTimeline(Map, currentRobotLocation, pickupLocation, robot.RobotId, Robots, timeline);
                        if (pathFindingResultForPickup != null && pathFindingResultForPickup.Path.Any())
                        {
                            //Move robot
                            robotAction.PathToPickup = pathFindingResultForPickup;
                            currentRobotLocation = pathFindingResultForPickup.Path.Last();
                        }
                    }
                    robotAction.RobotPickupEndingLocation = currentRobotLocation;
                    robot.Location = currentRobotLocation;

                    //process the robot action
                    if (robotAction != null)
                    {
                        int turn = _RobotProgress[robot.RobotId];
                        int turnsNeeded = 0;

                        //move to pickup
                        if (robotAction.PathToPickup != null)
                        {
                            turnsNeeded += robotAction.PathToPickup.Path.Count;
                        }
                        //Initialize the turns needed for this robot to complete it's turn
                        for (int j = turn; j < turn + turnsNeeded; j++)
                        {
                            if (timeline.Turns.Any(t => t.TurnNumber == j + 1) == false)
                            {
                                timeline.Turns.Add(new Turn(j + 1));
                            }
                        }

                        //Now populate the turns with the pickup path
                        int pickupCounter = 0;
                        if (robotAction.PathToPickup != null &&
                            robotAction.PathToPickup.Path != null &&
                            robotAction.PathToPickup.Path.Count > 0)
                        {
                            pickupCounter++;
                            timeline.Turns[turn].RobotActions.Add(new RobotTurnAction(robot.RobotId, RobotStatus.RobotStatusEnum.MovingToPickupLocation, null)
                            {
                                Movement = new List<Vector2>() { robotAction.RobotPickupStartingLocation, robotAction.PathToPickup.Path[0] }
                            });
                            for (int j = 1; j <= robotAction.PathToPickup.Path.Count - 1; j++)
                            {
                                pickupCounter++;
                                timeline.Turns[turn + j].RobotActions.Add(new RobotTurnAction(robot.RobotId, RobotStatus.RobotStatusEnum.MovingToPickupLocation, null)
                                {
                                    Movement = new List<Vector2>() { robotAction.PathToPickup.Path[j - 1], robotAction.PathToPickup.Path[j] }
                                });
                            }
                        }
                        _RobotProgress[robot.RobotId] += pickupCounter;
                    }
                }
            }

            return timeline;
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
                    adjacentLocation = new Vector2((int)destinationLocation.X, (int)destinationLocation.Y - 1);
                }
            }
            return adjacentLocation;
        }

        private RobotAction GetRobotAction(Robot robot, Piece piece, TimeLine timeline)
        {
            RobotAction robotAction = new RobotAction();

            Vector2 currentRobotLocation = robot.Location;
            Vector2 pickupLocation = robot.PickupLocation;

            // Move to unsorted pile
            robotAction.RobotPickupStartingLocation = currentRobotLocation;
            if (currentRobotLocation != pickupLocation)
            {
                robot.RobotStatus = RobotStatus.RobotStatusEnum.MovingToPickupLocation;
                PathFindingResult pathFindingResultForPickup = FindPathFindingWithTimeline(Map, currentRobotLocation, pickupLocation, robot.RobotId, Robots, timeline);
                if (pathFindingResultForPickup != null && pathFindingResultForPickup.Path.Any())
                {
                    //Move robot
                    robotAction.PathToPickup = pathFindingResultForPickup;
                    currentRobotLocation = pathFindingResultForPickup.Path.Last();
                }
            }
            robotAction.RobotPickupEndingLocation = currentRobotLocation;

            // Pickup an unsorted piece from the unsorted pile
            if (robot.Piece != null)
            {
                throw new System.Exception("Piece " + robot.Piece.Id + " was not delivered");
            }
            robot.RobotStatus = RobotStatus.RobotStatusEnum.PickingUpPackage;
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
            if (destinationLocation == null)
            {
                throw new System.Exception("Destination not found for piece " + piece.Id);
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
                robot.RobotStatus = RobotStatus.RobotStatusEnum.MovingToDeliveryLocation;
                //now find the path
                PathFindingResult pathFindingResultForDropoff = FindPathFindingWithTimeline(Map, currentRobotLocation, (Vector2)pathDestinationLocation, robot.RobotId, Robots, timeline);
                if (pathFindingResultForDropoff != null && pathFindingResultForDropoff.Path.Count >= 0)
                {
                    //Move robot
                    robotAction.PathToDropoff = pathFindingResultForDropoff;
                    robotAction.DropoffAction = new ObjectInteraction()
                    {
                        Location = (Vector2)destinationLocation
                    };
                    //Move the piece from the robot to the sorted pile
                    robot.RobotStatus = RobotStatus.RobotStatusEnum.DeliveringPackage;
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
            robot.RobotStatus = RobotStatus.RobotStatusEnum.LookingForJob;
            robotAction.RobotDropoffEndingLocation = currentRobotLocation;

            return robotAction;
        }
    }
}
