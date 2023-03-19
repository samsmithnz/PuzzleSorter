using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleSolver.Actions;
using PuzzleSolver.Entities;
using PuzzleSolver.Images;
using PuzzleSolver.Map;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace PuzzleSolver.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    [TestCategory("L0")]
    public class BoardL0Tests
    {

        [TestMethod]
        public void BoardNoRobotInitializationTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get3ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            Robot robot = new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>(){
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                new List<Robot>() { robot });

            //Act

            //Assert
            Assert.AreEqual(new Rgb24(255, 0, 0), Color.Red.ToPixel<Rgb24>());
            Assert.AreEqual(new Rgb24(0, 0, 255), Color.Blue.ToPixel<Rgb24>());
            Assert.AreEqual(new Rgb24(255, 255, 0), Color.Yellow.ToPixel<Rgb24>());
            Assert.IsNotNull(board);
            Assert.IsNotNull(board.Map);
            Assert.IsNotNull(board.Robots[0]);
            Assert.AreEqual(new(2, 2), board.UnsortedPiecesLocation);
            Assert.AreEqual(3, board.SortedDropZones.Count);
            Assert.AreEqual(new(0, 1), board.SortedDropZones[0].Location);
            Assert.AreEqual(0, board.SortedPieces.Count);
            Assert.AreEqual(4, board.UnsortedPieces.Count);
            Assert.AreEqual(new Vector2(2, 1), board.Robots[0].Location);
        }

        [TestMethod]
        public void BoardNoRobotInitializationWith7WidthTest()
        {
            //Arrange
            int width = 7;
            int height = 7;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get3ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            Robot robot = new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>(){
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                new List<Robot>() { robot });

            //Act

            //Assert
            Assert.AreEqual(new Rgb24(255, 0, 0), Color.Red.ToPixel<Rgb24>());
            Assert.AreEqual(new Rgb24(0, 0, 255), Color.Blue.ToPixel<Rgb24>());
            Assert.AreEqual(new Rgb24(255, 255, 0), Color.Yellow.ToPixel<Rgb24>());
            Assert.IsNotNull(board);
            Assert.IsNotNull(board.Map);
            Assert.IsNotNull(board.Robots[0]);
            Assert.AreEqual(new(3, 3), board.UnsortedPiecesLocation);
            Assert.AreEqual(3, board.SortedDropZones.Count);
            Assert.AreEqual(new(0, 1), board.SortedDropZones[0].Location);
            Assert.AreEqual(0, board.SortedPieces.Count);
            Assert.AreEqual(4, board.UnsortedPieces.Count);
            Assert.AreEqual(new Vector2(3, 2), board.Robots[0].Location);
        }

        [TestMethod]
        public void BoardOneRobot3ColorsRunTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get3ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            Robot robot = new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>() {
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Yellow.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                new List<Robot>() { robot });

            //Act
            TimeLine results = board.RunRobotsMk2();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(4, board.SortedPieces.Count);
            Assert.IsTrue(board.UnsortedPieces.Count == 0);
            Assert.IsNotNull(results);
            Assert.AreEqual(22, results.Turns.Count);

            //Complete the first action
            Turn turn1 = results.Turns[0];
            Assert.IsNotNull(turn1);
            Assert.AreEqual(1, turn1.RobotActions.Count);
            Assert.IsNotNull(turn1.RobotActions[0].PieceId);
            Assert.IsNull(turn1.RobotActions[0].Movement); //This is null because we start in the right location
            Assert.IsNotNull(turn1.RobotActions[0].PickupAction);
            Assert.AreEqual(RobotStatus.RobotStatusEnum.PickingUpPackage, turn1.RobotActions[0].RobotStatus);


            //Assert.AreEqual(new(2, 1), turn1.RobotActions[0].RobotDropoffStartingLocation);
            //Assert.AreEqual(new(1, 1), turn1.RobotActions[0].PathToDropoff.Path[0]);
            //Assert.AreEqual(new(1, 1), turn1.RobotActions[0].RobotDropoffEndingLocation);
            //Assert.AreEqual(1, turn1.RobotActions[0].DropoffPieceCount);
            //Assert.IsNotNull(turn1.RobotActions[0].DropoffAction);
            //Assert.AreEqual(new(0, 1), board.SortedPieces[0].Location);

            ////Complete the second action
            //Turn turn2 = results.Turns[1];
            //Assert.IsNotNull(turn2);
            //Assert.AreEqual(1, turn2.RobotActions.Count);
            //Assert.IsNotNull(turn2.RobotActions[0].RobotActionsPieceId);
            //Assert.IsNotNull(turn2.RobotActions[0].PathToPickup);
            //Assert.AreEqual(new(1, 1), turn2.RobotActions[0].RobotPickupStartingLocation);
            //Assert.AreEqual(new(2, 1), turn2.RobotActions[0].PathToPickup.Path[0]);
            //Assert.AreEqual(new(2, 1), turn2.RobotActions[0].RobotPickupEndingLocation);
            //Assert.IsNotNull(turn2.RobotActions[0].PickupAction);
            //Assert.IsNotNull(turn2.RobotActions[0].PathToDropoff);
            //Assert.AreEqual(new(2, 1), turn2.RobotActions[0].RobotDropoffStartingLocation);
            //Assert.AreEqual(new(1, 1), turn2.RobotActions[0].PathToDropoff.Path[0]);
            //Assert.AreEqual(new(1, 2), turn2.RobotActions[0].PathToDropoff.Path[1]);
            //Assert.AreEqual(new(1, 2), turn2.RobotActions[0].RobotDropoffEndingLocation);
            //Assert.AreEqual(1, turn2.RobotActions[0].DropoffPieceCount);
            //Assert.IsNotNull(turn2.RobotActions[0].DropoffAction);

            ////Complete the third action
            //Turn turn3 = results.Turns[2];
            //Assert.IsNotNull(turn3);
            //Assert.AreEqual(1, turn3.RobotActions.Count);
            //Assert.IsNotNull(turn3.RobotActions[0].PieceId);
            //Assert.IsNotNull(turn3.RobotActions[0].PathToPickup);
            //Assert.AreEqual(new(1, 2), turn3.RobotActions[0].RobotPickupStartingLocation);
            //Assert.AreEqual(new(1, 1), turn3.RobotActions[0].PathToPickup.Path[0]);
            //Assert.AreEqual(new(2, 1), turn3.RobotActions[0].PathToPickup.Path[1]);
            //Assert.AreEqual(new(2, 1), turn3.RobotActions[0].RobotPickupEndingLocation);
            //Assert.IsNotNull(turn3.RobotActions[0].PickupAction);
            //Assert.IsNotNull(turn3.RobotActions[0].PathToDropoff);
            //Assert.AreEqual(new(2, 1), turn3.RobotActions[0].RobotDropoffStartingLocation);
            //Assert.AreEqual(new(1, 1), turn3.RobotActions[0].PathToDropoff.Path[0]);
            //Assert.AreEqual(new(1, 1), turn3.RobotActions[0].RobotDropoffEndingLocation);
            //Assert.AreEqual(2, turn3.RobotActions[0].DropoffPieceCount);
            //Assert.IsNotNull(turn3.RobotActions[0].DropoffAction);

            Assert.AreEqual(Color.Red.ToPixel<Rgb24>(), board.SortedPieces[0].TopColorGroup);
            Assert.AreEqual(2, board.SortedDropZones[0].Count);
            Assert.AreEqual(1, board.SortedDropZones[1].Count);
            Assert.AreEqual(1, board.SortedDropZones[2].Count);
            Assert.AreEqual(2, board.GetPieceCount(board.SortedDropZones[0].Location));
        }

        [TestMethod]
        public void BoardOneRobot6ColorsRunTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get6ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            Robot robot = new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>() {
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 5,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 6,
                        Image = ImageCropping.CreateImage(Color.Purple.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 7,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 8,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 9,
                        Image = ImageCropping.CreateImage(Color.Yellow.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 10,
                        Image = ImageCropping.CreateImage(Color.Orange.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                new List<Robot>() { robot });

            //Act
            TimeLine results = board.RunRobotsMk2();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(10, board.SortedPieces.Count);
            Assert.IsTrue(board.UnsortedPieces.Count == 0);
            Assert.IsNotNull(results);
            Assert.AreEqual(53, results.Turns.Count);

            //Complete the first action
            Turn turn1 = results.Turns[0];
            Assert.IsNotNull(turn1);
            Assert.AreEqual(1, turn1.RobotActions.Count);
            Assert.IsNotNull(turn1.RobotActions[0].PieceId);
            Assert.IsNull(turn1.RobotActions[0].Movement); //This is null because we start in the right location
            Assert.IsNotNull(turn1.RobotActions[0].PickupAction);
            Assert.IsNull(turn1.RobotActions[0].DropoffAction);
            Assert.AreEqual(new(0, 1), board.SortedPieces[0].Location);
            Assert.AreEqual(RobotStatus.RobotStatusEnum.PickingUpPackage, turn1.RobotActions[0].RobotStatus);

            ////Complete the second action
            //RobotAction turn2 = results.Dequeue();
            //Assert.IsNotNull(turn2);
            //Assert.IsNotNull(turn2.PieceId);
            //Assert.IsNotNull(turn2.PathToPickup);
            //Assert.AreEqual(new(1, 1), turn2.RobotPickupStartingLocation);
            //Assert.AreEqual(new(2, 1), turn2.PathToPickup.Path[0]);
            //Assert.AreEqual(new(2, 1), turn2.RobotPickupEndingLocation);
            //Assert.IsNotNull(turn2.PickupAction);
            //Assert.IsNotNull(turn2.PathToDropoff);
            //Assert.AreEqual(new(2, 1), turn2.RobotDropoffStartingLocation);
            //Assert.AreEqual(new(1, 1), turn2.PathToDropoff.Path[0]);
            //Assert.AreEqual(new(1, 2), turn2.PathToDropoff.Path[1]);
            //Assert.AreEqual(new(1, 3), turn2.PathToDropoff.Path[2]);
            //Assert.AreEqual(new(1, 3), turn2.RobotDropoffEndingLocation);
            //Assert.AreEqual(1, turn2.DropoffPieceCount);
            //Assert.IsNotNull(turn2.DropoffAction);
            //Assert.AreEqual(9, results.Count);

            ////Complete the third action
            //RobotAction turn3 = results.Dequeue();
            //Assert.IsNotNull(turn3);
            //Assert.IsNotNull(turn3.PieceId);
            //Assert.IsNotNull(turn3.PathToPickup);
            //Assert.AreEqual(new(1, 3), turn3.RobotPickupStartingLocation);
            //Assert.AreEqual(new(1, 2), turn3.PathToPickup.Path[0]);
            //Assert.AreEqual(new(1, 1), turn3.PathToPickup.Path[1]);
            //Assert.AreEqual(new(2, 1), turn3.PathToPickup.Path[2]);
            //Assert.AreEqual(new(2, 1), turn3.RobotPickupEndingLocation);
            //Assert.IsNotNull(turn3.PickupAction);
            //Assert.IsNotNull(turn3.PathToDropoff);
            //Assert.AreEqual(new(2, 1), turn3.RobotDropoffStartingLocation);
            //Assert.AreEqual(new(1, 1), turn3.PathToDropoff.Path[0]);
            //Assert.AreEqual(new(1, 1), turn3.RobotDropoffEndingLocation);
            //Assert.AreEqual(2, turn3.DropoffPieceCount);
            //Assert.IsNotNull(turn3.DropoffAction);
            //Assert.AreEqual(8, results.Count);

            ////Complete the fourth action
            //RobotAction robotAction4 = results.Dequeue();
            //Assert.IsNotNull(robotAction4);
            //Assert.IsNotNull(robotAction4.PieceId);
            //Assert.IsNotNull(robotAction4.PathToPickup);
            //Assert.IsNotNull(robotAction4.PickupAction);
            //Assert.IsNotNull(robotAction4.PathToDropoff);
            //Assert.AreEqual(1, robotAction4.DropoffPieceCount);
            //Assert.IsNotNull(robotAction4.DropoffAction);
            //Assert.AreEqual(7, results.Count);

            Assert.AreEqual(Color.Red.ToPixel<Rgb24>(), board.SortedPieces[0].TopColorGroup);
            Assert.AreEqual(4, board.SortedDropZones[0].Count);
            Assert.AreEqual(1, board.SortedDropZones[1].Count);
            Assert.AreEqual(2, board.SortedDropZones[2].Count);
            Assert.AreEqual(1, board.SortedDropZones[3].Count);
            Assert.AreEqual(1, board.SortedDropZones[4].Count);
            Assert.AreEqual(1, board.SortedDropZones[5].Count);
            Assert.AreEqual(4, board.GetPieceCount(board.SortedDropZones[0].Location));
        }

        [TestMethod]
        public void BoardOneRobot6ColorsTest()
        {
            //Arrange
            int width = 7;
            int height = 7;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get6ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            List<Robot> robots = new() {
                new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1))
            };
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>() {
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 5,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 6,
                        Image = ImageCropping.CreateImage(Color.Purple.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 7,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 8,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 9,
                        Image = ImageCropping.CreateImage(Color.Yellow.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 10,
                        Image = ImageCropping.CreateImage(Color.Orange.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                robots);

            //Act
            TimeLine results = board.RunRobotsMk2();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(10, board.SortedPieces.Count);
            Assert.IsNotNull(results);
            Assert.AreEqual(84, results.Turns.Count);

            //Turns
            Turn turn1 = results.Turns[0];
            Assert.AreEqual(1, turn1.TurnNumber);
            Assert.AreEqual(1, turn1.RobotActions.Count);
            Assert.AreEqual(1, turn1.RobotActions[0].PieceId);
            Assert.IsNull(turn1.RobotActions[0].Movement);
            Assert.AreEqual(RobotStatus.RobotStatusEnum.PickingUpPackage, turn1.RobotActions[0].RobotStatus);

            //Move piece 1 from 3,2 to 2,2
            Turn turn2 = results.Turns[1];
            Assert.AreEqual(2, turn2.TurnNumber);
            Assert.AreEqual(1, turn2.RobotActions.Count);
            Assert.AreEqual(1, turn2.RobotActions[0].PieceId);
            Assert.AreEqual(2, turn2.RobotActions[0].Movement.Count);
            Assert.AreEqual(new Vector2(3, 2), turn2.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(2, 2), turn2.RobotActions[0].Movement[1]);
            Assert.AreEqual(RobotStatus.RobotStatusEnum.MovingToDeliveryLocation, turn2.RobotActions[0].RobotStatus);

            //Move piece 1 from 2,2 to 1,2
            Turn turn3 = results.Turns[2];
            Assert.AreEqual(3, turn3.TurnNumber);
            Assert.AreEqual(1, turn3.RobotActions.Count);
            Assert.AreEqual(1, turn3.RobotActions[0].PieceId); ;
            Assert.AreEqual(new Vector2(2, 2), turn3.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 2), turn3.RobotActions[0].Movement[1]);
            Assert.AreEqual(RobotStatus.RobotStatusEnum.MovingToDeliveryLocation, turn3.RobotActions[0].RobotStatus);

            //Move piece 1 from 1,2 to 1,1
            Turn turn4 = results.Turns[3];
            Assert.AreEqual(4, turn4.TurnNumber);
            Assert.AreEqual(1, turn4.RobotActions.Count);
            Assert.AreEqual(1, turn4.RobotActions[0].PieceId); ;
            Assert.AreEqual(new Vector2(1, 2), turn4.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 1), turn4.RobotActions[index: 0].Movement[1]);
            Assert.AreEqual(RobotStatus.RobotStatusEnum.MovingToDeliveryLocation, turn4.RobotActions[0].RobotStatus);

            //Dropoff piece 1 to 0,1
            Turn turn5 = results.Turns[4];
            Assert.AreEqual(5, turn5.TurnNumber);
            Assert.AreEqual(1, turn5.RobotActions.Count);
            Assert.AreEqual(1, turn5.RobotActions[0].PieceId);
            Assert.IsNull(turn5.RobotActions[0].Movement);
            Assert.AreEqual(new Vector2(0, 1), turn5.RobotActions[0].DropoffAction.Location);
            Assert.AreEqual(1, turn5.RobotActions[0].DropoffAction.DestinationPieceCount);

            ////Dropoff piece 1 to 0,1
            //Turn turn3 = results.Turns[2];
            //Assert.AreEqual(3, turn3.TurnNumber);
            //Assert.AreEqual(1, turn3.RobotActions.Count);
            //Assert.AreEqual(1, turn3.RobotActions[0].PieceId); ;
            //Assert.AreEqual(new Vector2(2, 2), turn3.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(1, 2), turn3.RobotActions[0].Movement[1]);
            ////Assert.AreEqual(new Vector2(0, 1), turn3.RobotActions[0].DropoffAction.Location);
            ////Assert.AreEqual(1, turn3.RobotActions[0].DropoffAction.DestinationPieceCount);
            ////Assert.IsNull(turn3.RobotActions[0].Movement);


            ////Move from 1,1 to 2,1 to pickup new piece
            //Turn turn4 = results.Turns[3];
            //Assert.AreEqual(4, turn4.TurnNumber);
            //Assert.AreEqual(1, turn4.RobotActions.Count);
            //Assert.AreEqual(null, turn4.RobotActions[0].PieceId);
            //Assert.AreEqual(2, turn4.RobotActions[0].Movement.Count);
            //Assert.AreEqual(new Vector2(1, 1), turn4.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(2, 1), turn4.RobotActions[0].Movement[1]);

            ////Pickup piece 2 from 2,2
            //Turn turn5 = results.Turns[4];
            //Assert.AreEqual(5, turn5.TurnNumber);
            //Assert.AreEqual(1, turn5.RobotActions.Count);
            //Assert.AreEqual(2, turn5.RobotActions[0].PieceId);
            //Assert.IsNull(turn5.RobotActions[0].Movement);

            ////Move piece 2 from 2,1 to 1,1
            //Turn turn6 = results.Turns[5];
            //Assert.AreEqual(6, turn6.TurnNumber);
            //Assert.AreEqual(1, turn6.RobotActions.Count);
            //Assert.AreEqual(2, turn6.RobotActions[0].PieceId);
            //Assert.AreEqual(2, turn6.RobotActions[0].Movement.Count);
            //Assert.AreEqual(new Vector2(2, 1), turn6.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(1, 1), turn6.RobotActions[0].Movement[1]);

            ////Move piece 2 from 1,1 to 1,2
            //Turn turn7 = results.Turns[6];
            //Assert.AreEqual(7, turn7.TurnNumber);
            //Assert.AreEqual(1, turn7.RobotActions.Count);
            //Assert.AreEqual(2, turn7.RobotActions[0].PieceId);
            //Assert.AreEqual(2, turn7.RobotActions[0].Movement.Count);
            //Assert.AreEqual(new Vector2(1, 1), turn7.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(1, 2), turn7.RobotActions[0].Movement[1]);

            ////Move piece 2 from 1,2 to 1,3
            //Turn turn8 = results.Turns[7];
            //Assert.AreEqual(8, turn8.TurnNumber);
            //Assert.AreEqual(1, turn8.RobotActions.Count);
            //Assert.AreEqual(2, turn8.RobotActions[0].PieceId);
            //Assert.AreEqual(2, turn8.RobotActions[0].Movement.Count);
            //Assert.AreEqual(new Vector2(1, 2), turn8.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(1, 3), turn8.RobotActions[0].Movement[1]);

            ////Dropoff piece 2 to 0,3
            //Turn turn9 = results.Turns[8];
            //Assert.AreEqual(9, turn9.TurnNumber);
            //Assert.AreEqual(1, turn9.RobotActions.Count);
            //Assert.AreEqual(2, turn9.RobotActions[0].PieceId); ;
            //Assert.AreEqual(new Vector2(0, 3), turn9.RobotActions[0].DropoffAction.Location);
            //Assert.AreEqual(1, turn9.RobotActions[0].DropoffAction.DestinationPieceCount);
            //Assert.IsNull(turn9.RobotActions[0].Movement);


            ////Move from 1,3 to 1,2 to pickup new piece
            //Turn turn10 = results.Turns[9];
            //Assert.AreEqual(10, turn10.TurnNumber);
            //Assert.AreEqual(1, turn10.RobotActions.Count);
            //Assert.AreEqual(null, turn10.RobotActions[0].PieceId);
            //Assert.AreEqual(2, turn10.RobotActions[0].Movement.Count);
            //Assert.AreEqual(new Vector2(1, 3), turn10.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(1, 2), turn10.RobotActions[0].Movement[1]);



            ////check the second to last turn
            //Assert.AreEqual(43, results.turns[results.turns.Count - 2].turnNumber);
            //Assert.AreEqual(1, results.turns[results.turns.Count - 2].RobotActions.Count);
            //Assert.AreEqual(10, results.turns[results.turns.Count - 2].RobotActions[0].PieceId);

            //check the last turn
            Turn turnLast = results.Turns[83];
            Assert.AreEqual(84, turnLast.TurnNumber);
            Assert.AreEqual(1, turnLast.RobotActions.Count);
            Assert.IsNull(turnLast.RobotActions[0].PieceId);
            Assert.AreEqual(2, turnLast.RobotActions[0].Movement.Count);
            Assert.AreEqual(new Vector2(2, 2), turnLast.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(3, 2), turnLast.RobotActions[0].Movement[1]);

        }

        [TestMethod]
        public void BoardTwoRobots6ColorsTest()
        {
            //Arrange
            int width = 7;
            int height = 7;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get6ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            List<Robot> robots = new() {
                new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1)),
                new Robot(2, new Vector2(centerPointLocation.X - 1, centerPointLocation.Y), new Vector2(centerPointLocation.X - 1, centerPointLocation.Y))
            };
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>() {
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 5,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 6,
                        Image = ImageCropping.CreateImage(Color.Purple.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 7,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 8,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 9,
                        Image = ImageCropping.CreateImage(Color.Yellow.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 10,
                        Image = ImageCropping.CreateImage(Color.Orange.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                robots);

            //Act
            TimeLine results = board.RunRobotsMk2();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(10, board.SortedPieces.Count);
            Assert.IsNotNull(results);
            Assert.AreEqual(54, results.Turns.Count);

            //check the first turn
            Turn turn1 = results.Turns[0];
            Assert.AreEqual(1, turn1.TurnNumber);
            Assert.AreEqual(2, turn1.RobotActions.Count);
            Assert.AreEqual(1, turn1.RobotActions[0].PieceId);
            Assert.AreEqual(2, turn1.RobotActions[1].PieceId);
            Assert.IsNull(turn1.RobotActions[0].Movement);
            Assert.IsNull(turn1.RobotActions[1].Movement);

            Turn turn2 = results.Turns[1];
            Assert.AreEqual(2, turn2.TurnNumber);
            Assert.AreEqual(2, turn2.RobotActions.Count);
            Assert.AreEqual(1, turn2.RobotActions[0].PieceId);
            Assert.AreEqual(2, turn2.RobotActions[1].PieceId);
            Assert.AreEqual(2, turn2.RobotActions[0].Movement.Count);
            Assert.AreEqual(2, turn2.RobotActions[1].Movement.Count);
            Assert.AreEqual(new Vector2(3, 2), turn2.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(2, 2), turn2.RobotActions[0].Movement[1]);
            Assert.AreEqual(new Vector2(2, 3), turn2.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(1, 3), turn2.RobotActions[1].Movement[1]);

            Turn turn3 = results.Turns[2];
            Assert.AreEqual(3, turn3.TurnNumber);
            Assert.AreEqual(2, turn3.RobotActions.Count);
            Assert.AreEqual(1, turn3.RobotActions[0].PieceId);
            Assert.AreEqual(2, turn3.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(2, 2), turn3.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 2), turn3.RobotActions[0].Movement[1]);
            Assert.AreEqual(1, turn3.RobotActions[1].DropoffAction.DestinationPieceCount);
            Assert.AreEqual(new Vector2(0, 3), turn3.RobotActions[1].DropoffAction.Location);

            //Assert.AreEqual(new Vector2(0, 1), turn3.RobotActions[0].DropoffAction.Location);
            //Assert.AreEqual(new Vector2(0, 3), turn3.RobotActions[1].DropoffAction.Location);
            //Assert.AreEqual(1, turn3.RobotActions[0].DropoffAction.DestinationPieceCount);
            //Assert.AreEqual(1, turn3.RobotActions[1].DropoffAction.DestinationPieceCount);
            //Assert.IsNull(turn3.RobotActions[0].Movement);
            //Assert.IsNull(turn3.RobotActions[1].Movement);

            Turn turn4 = results.Turns[3];
            Assert.AreEqual(4, turn4.TurnNumber);
            Assert.AreEqual(2, turn4.RobotActions.Count);
            Assert.AreEqual(1, turn4.RobotActions[0].PieceId);
            Assert.AreEqual(null, turn4.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(1, 2), turn4.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 1), turn4.RobotActions[0].Movement[1]);
            Assert.AreEqual(new Vector2(1, 3), turn4.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(2, 3), turn4.RobotActions[1].Movement[1]);

            //Turn 5: (fixed) BUG: Robot 2 should pick up piece 3
            Turn turn5 = results.Turns[4];
            Assert.AreEqual(5, turn5.TurnNumber);
            Assert.AreEqual(2, turn5.RobotActions.Count);
            Assert.AreEqual(1, turn5.RobotActions[0].PieceId);
            Assert.AreEqual(3, turn5.RobotActions[1].PieceId);
            Assert.IsNotNull(turn5.RobotActions[1].PickupAction);

            //Turn 11: BUG: Robot 2 picks up an item then waits from turn 12 on...

            //Turn 11 check for bugs
            Turn turn11 = results.Turns[10];
            Assert.AreEqual(11, turn11.TurnNumber);
            Assert.AreEqual(2, turn11.RobotActions.Count);
            Assert.AreEqual(4, turn11.RobotActions[0].PieceId);
            Assert.AreEqual(null, turn11.RobotActions[1].PieceId);

            //Turn 12, the bots previously crossed paths, but shouldn't anymore
            Turn turn12 = results.Turns[11];
            Assert.AreEqual(12, turn12.TurnNumber);
            Assert.AreEqual(2, turn12.RobotActions.Count);
            Assert.AreEqual(new Vector2(1, 2), turn12.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 1), turn12.RobotActions[0].Movement[1]);
            Assert.AreEqual(new Vector2(2, 3), turn12.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(2, 3), turn12.RobotActions[1].Movement[1]);

            //Turn 15, the bots previously crossed paths, but shouldn't anymore
            Turn turn15 = results.Turns[14];
            Assert.AreEqual(15, turn15.TurnNumber);
            Assert.AreEqual(2, turn15.RobotActions.Count);
            Assert.AreEqual(new Vector2(2, 1), turn15.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(2, 2), turn15.RobotActions[0].Movement[1]);
            Assert.AreEqual(new Vector2(2, 3), turn15.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(2, 3), turn15.RobotActions[1].Movement[1]);


            ////Turn 13, the bots cross paths, but shouldn't
            //Turn turn13 = results.Turns[12];
            //Assert.AreEqual(13, turn13.TurnNumber);
            //Assert.AreEqual(2, turn13.RobotActions.Count);
            //Assert.AreEqual(new Vector2(2, 3), turn13.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(1 ,3), turn13.RobotActions[0].Movement[1]);
            //Assert.AreEqual(2, turn13.RobotActions[1].RobotId);
            //Assert.AreEqual(new Vector2(1, 3), turn13.RobotActions[1].Movement[0]);
            //Assert.AreEqual(new Vector2(2, 3), turn13.RobotActions[1].Movement[1]);

            ////check the fourth to last turn
            //Assert.AreEqual(17, results.Turns[results.Turns.Count - 4].TurnNumber);
            //Assert.AreEqual(2, results.Turns[results.Turns.Count - 4].RobotActions.Count);
            //Assert.AreEqual(9, results.Turns[results.Turns.Count - 4].RobotActions[0].PieceId);
            //Assert.AreEqual(10, results.Turns[results.Turns.Count - 4].RobotActions[1].PieceId);

            ////check the third to last turn
            //Assert.AreEqual(18, results.Turns[results.Turns.Count - 3].TurnNumber);
            //Assert.AreEqual(2, results.Turns[results.Turns.Count - 3].RobotActions.Count);
            //Assert.AreEqual(9, results.Turns[results.Turns.Count - 3].RobotActions[0].PieceId);

            ////check the second to last turn
            //Assert.AreEqual(19, results.Turns[results.Turns.Count - 2].TurnNumber);
            //Assert.AreEqual(2, results.Turns[results.Turns.Count - 2].RobotActions.Count);
            //Assert.AreEqual(10, results.Turns[results.Turns.Count - 2].RobotActions[0].PieceId);

            ////check the last turn
            //Assert.AreEqual(20, results.Turns[results.Turns.Count - 1].TurnNumber);
            //Assert.AreEqual(2, results.Turns[results.Turns.Count - 1].RobotActions.Count);
            //Assert.AreEqual(null, results.Turns[results.Turns.Count - 1].RobotActions[0].PieceId);

        }



        [TestMethod]
        public void BoardTwoRobots16ColorsTest()
        {
            //Arrange
            int width = 7;
            int height = 7;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get16ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            List<Robot> robots = new() {
                new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1)),
                new Robot(2, new Vector2(centerPointLocation.X - 1, centerPointLocation.Y), new Vector2(centerPointLocation.X - 1, centerPointLocation.Y))
            };
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>() {
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 5,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 6,
                        Image = ImageCropping.CreateImage(Color.Purple.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 7,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 8,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 9,
                        Image = ImageCropping.CreateImage(Color.Yellow.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 10,
                        Image = ImageCropping.CreateImage(Color.Orange.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                robots);

            //Act
            TimeLine results = board.RunRobotsMk2();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(10, board.SortedPieces.Count);
            Assert.IsNotNull(results);
            Assert.AreEqual(58, results.Turns.Count);

            ////Turn 25, robot 2 picks up piece 6, and then loses it
            //Turn turn25 = results.Turns[24];
            //Assert.AreEqual(25, turn25.TurnNumber);
            //Assert.AreEqual(2, turn25.RobotActions.Count);
            //Assert.AreEqual(6, turn25.RobotActions[1].PieceId);
            //Assert.IsNotNull(turn25.RobotActions[1].PickupAction);

            ////Turn 26, robot 2 picks up piece 6, and then loses it
            //Turn turn26 = results.Turns[25];
            //Assert.AreEqual(26, turn26.TurnNumber);
            //Assert.AreEqual(2, turn26.RobotActions.Count);
            //Assert.AreEqual(7, turn26.RobotActions[1].PieceId);
            //Assert.IsNotNull( turn26.RobotActions[1].PickupAction);

        }

        [TestMethod]
        public void BoardTwoRobots6ColorsSmallMapTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get6ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            List<Robot> robots = new() {
                new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1)),
                new Robot(2, new Vector2(centerPointLocation.X - 1, centerPointLocation.Y), new Vector2(centerPointLocation.X - 1, centerPointLocation.Y))
            };
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>() {
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    //new Piece() {
                    //    Id = 5,
                    //    Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 6,
                    //    Image = ImageCropping.CreateImage(Color.Purple.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 7,
                    //    Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 8,
                    //    Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 9,
                    //    Image = ImageCropping.CreateImage(Color.Yellow.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 10,
                    //    Image = ImageCropping.CreateImage(Color.Orange.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //}
                },
                sortedDropZones,
                robots);

            //Act
            TimeLine results = board.RunRobotsMk2();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(4, board.SortedPieces.Count);
            Assert.IsNotNull(results);
            Assert.AreEqual(10, results.Turns.Count);

            //check the first turn
            Turn turn1 = results.Turns[0];
            Assert.AreEqual(1, turn1.TurnNumber);
            Assert.AreEqual(2, turn1.RobotActions.Count);
            Assert.AreEqual(1, turn1.RobotActions[0].PieceId);
            Assert.AreEqual(2, turn1.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(2, 2), turn1.RobotActions[0].PickupAction.Location);
            Assert.AreEqual(new Vector2(2, 2), turn1.RobotActions[1].PickupAction.Location);
            Assert.IsNull(turn1.RobotActions[0].Movement);
            Assert.IsNull(turn1.RobotActions[1].Movement);

            Turn turn2 = results.Turns[1];
            Assert.AreEqual(2, turn2.TurnNumber);
            Assert.AreEqual(2, turn2.RobotActions.Count);
            Assert.AreEqual(1, turn2.RobotActions[0].PieceId);
            Assert.AreEqual(2, turn2.RobotActions[1].PieceId);
            Assert.AreEqual(2, turn2.RobotActions[0].Movement.Count);
            Assert.AreEqual(2, turn2.RobotActions[1].Movement.Count);
            Assert.AreEqual(new Vector2(2, 1), turn2.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 1), turn2.RobotActions[0].Movement[1]);
            Assert.AreEqual(new Vector2(1, 2), turn2.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(1, 3), turn2.RobotActions[1].Movement[1]);

            Turn turn3 = results.Turns[2];
            Assert.AreEqual(3, turn3.TurnNumber);
            Assert.AreEqual(2, turn3.RobotActions.Count);
            Assert.AreEqual(1, turn3.RobotActions[0].PieceId);
            Assert.AreEqual(2, turn3.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(0, 1), turn3.RobotActions[0].DropoffAction.Location);
            Assert.AreEqual(new Vector2(0, 3), turn3.RobotActions[1].DropoffAction.Location);
            Assert.AreEqual(1, turn3.RobotActions[0].DropoffAction.DestinationPieceCount);
            Assert.AreEqual(1, turn3.RobotActions[1].DropoffAction.DestinationPieceCount);

            Turn turn4 = results.Turns[3];
            Assert.AreEqual(4, turn4.TurnNumber);
            Assert.AreEqual(2, turn4.RobotActions.Count);
            Assert.AreEqual(null, turn4.RobotActions[0].PieceId);
            Assert.AreEqual(null, turn4.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(1, 1), turn4.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(2, 1), turn4.RobotActions[0].Movement[1]);
            Assert.AreEqual(new Vector2(1, 3), turn4.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(1, 2), turn4.RobotActions[1].Movement[1]);

            Turn turn5 = results.Turns[4];
            Assert.AreEqual(5, turn5.TurnNumber);
            Assert.AreEqual(2, turn5.RobotActions.Count);
            Assert.AreEqual(3, turn5.RobotActions[0].PieceId);
            Assert.AreEqual(4, turn5.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(2, 2), turn5.RobotActions[0].PickupAction.Location);
            Assert.AreEqual(new Vector2(2, 2), turn5.RobotActions[1].PickupAction.Location);
            Assert.IsNull(turn5.RobotActions[0].Movement);
            Assert.IsNull(turn5.RobotActions[1].Movement);

            //this turn is problematic
            Turn turn6 = results.Turns[5];
            Assert.AreEqual(6, turn6.TurnNumber);
            Assert.AreEqual(2, turn6.RobotActions.Count);
            Assert.AreEqual(3, turn6.RobotActions[0].PieceId);
            Assert.AreEqual(4, turn6.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(2, 1), turn6.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 1), turn6.RobotActions[0].Movement[1]);
            Assert.AreEqual(new Vector2(1, 2), turn6.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(1, 2), turn6.RobotActions[1].Movement[1]);

            Turn turn7 = results.Turns[6];
            Assert.AreEqual(7, turn7.TurnNumber);
            Assert.AreEqual(2, turn7.RobotActions.Count);
            Assert.AreEqual(3, turn7.RobotActions[0].PieceId);
            Assert.AreEqual(4, turn7.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(0, 1), turn7.RobotActions[0].DropoffAction.Location);
            //Assert.AreEqual(new Vector2(1, 0), turn7.RobotActions[1].DropoffAction.Location);
            Assert.AreEqual(2, turn7.RobotActions[0].DropoffAction.DestinationPieceCount);
            //Assert.AreEqual(1, turn7.RobotActions[1].DropoffAction.DestinationPieceCount);
            Assert.AreEqual(new Vector2(1, 2), turn7.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(1, 2), turn7.RobotActions[1].Movement[1]);

            Turn turn8 = results.Turns[7];
            Assert.AreEqual(8, turn8.TurnNumber);
            Assert.AreEqual(2, turn8.RobotActions.Count);
            Assert.AreEqual(null, turn8.RobotActions[0].PieceId);
            Assert.AreEqual(null, turn8.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(1, 2), turn8.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 2), turn8.RobotActions[0].Movement[1]);
            Assert.AreEqual(new Vector2(1, 1), turn8.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(2, 1), turn8.RobotActions[1].Movement[1]);

        }

        [TestMethod]
        public void BoardTwoRobots6ColorsTinyMapTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get6ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            List<Robot> robots = new() {
                new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1)),
                new Robot(2, new Vector2(centerPointLocation.X - 1, centerPointLocation.Y), new Vector2(centerPointLocation.X - 1, centerPointLocation.Y))
            };
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>() {
                    //new Piece() {
                    //    Id = 1,
                    //    Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 2,
                    //    Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    //new Piece() {
                    //    Id = 5,
                    //    Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 6,
                    //    Image = ImageCropping.CreateImage(Color.Purple.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 7,
                    //    Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 8,
                    //    Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 9,
                    //    Image = ImageCropping.CreateImage(Color.Yellow.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 10,
                    //    Image = ImageCropping.CreateImage(Color.Orange.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //}
                },
                sortedDropZones,
                robots);

            //Act
            TimeLine results = board.RunRobotsMk2();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            //Assert.AreEqual(2, board.SortedPieces.Count);
            Assert.IsNotNull(results);
            Assert.AreEqual(6, results.Turns.Count);

            //Robot 1 + 2 Pickup
            Turn turn1 = results.Turns[0];
            Assert.AreEqual(1, turn1.TurnNumber);
            Assert.AreEqual(2, turn1.RobotActions.Count);
            Assert.AreEqual(3, turn1.RobotActions[0].PieceId);
            Assert.AreEqual(4, turn1.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(2, 2), turn1.RobotActions[0].PickupAction.Location);
            Assert.AreEqual(new Vector2(2, 2), turn1.RobotActions[1].PickupAction.Location);
            Assert.IsNull(turn1.RobotActions[0].Movement);
            Assert.IsNull(turn1.RobotActions[1].Movement);

            //this turn is problematic
            //Robot 1 move to dropoff, Robot 2 waiting
            Turn turn2 = results.Turns[1];
            Assert.AreEqual(2, turn2.TurnNumber);
            Assert.AreEqual(2, turn2.RobotActions.Count);
            Assert.AreEqual(3, turn2.RobotActions[0].PieceId);
            Assert.AreEqual(4, turn2.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(2, 1), turn2.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 1), turn2.RobotActions[0].Movement[1]);
            Assert.AreEqual(new Vector2(1, 2), turn2.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(1, 2), turn2.RobotActions[1].Movement[1]);

            //Robot 1 Dropoff, Robot 2 waiting
            Turn turn3 = results.Turns[2];
            Assert.AreEqual(3, turn3.TurnNumber);
            Assert.AreEqual(2, turn3.RobotActions.Count);
            Assert.AreEqual(3, turn3.RobotActions[0].PieceId);
            Assert.AreEqual(4, turn3.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(0, 1), turn3.RobotActions[0].DropoffAction.Location);
            Assert.AreEqual(1, turn3.RobotActions[0].DropoffAction.DestinationPieceCount);
            Assert.AreEqual(new Vector2(1, 2), turn3.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(1, 2), turn3.RobotActions[1].Movement[1]);

            //Move Robot 1 back to pickup, Robot 2 moving to dropoff
            Turn turn4 = results.Turns[3];
            Assert.AreEqual(4, turn4.TurnNumber);
            Assert.AreEqual(2, turn4.RobotActions.Count);
            Assert.AreEqual(4, turn4.RobotActions[0].PieceId);
            Assert.AreEqual(null, turn4.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(1, 2), turn4.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 2), turn4.RobotActions[0].Movement[1]);
            Assert.AreEqual(new Vector2(1, 1), turn4.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(2, 1), turn4.RobotActions[1].Movement[1]);

            //Move Robot 1 is idle, Robot 2 moving back to pickup
            Turn turn5 = results.Turns[4];
            Assert.AreEqual(5, turn5.TurnNumber);
            Assert.AreEqual(1, turn5.RobotActions.Count);
            Assert.AreEqual(4, turn5.RobotActions[0].PieceId);
            Assert.AreEqual(new Vector2(1, 2), turn5.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 1), turn5.RobotActions[0].Movement[1]);
            //Assert.AreEqual(new Vector2(1, 1), turn5.RobotActions[1].Movement[0]);
            //Assert.AreEqual(new Vector2(1, 2), turn5.RobotActions[1].Movement[1]);
            //Assert.AreEqual(new Vector2(1, 0), turn5.RobotActions[1].DropoffAction.Location);
            //Assert.AreEqual(1, turn5.RobotActions[1].DropoffAction.DestinationPieceCount);

            //Move Robot 1 is idle, Robot 2 moving back to pickup
            Turn turn6 = results.Turns[5];
            Assert.AreEqual(6, turn6.TurnNumber);
            Assert.AreEqual(1, turn6.RobotActions.Count);
            Assert.AreEqual(4, turn6.RobotActions[0].PieceId);
            Assert.AreEqual(new Vector2(1, 0), turn6.RobotActions[0].DropoffAction.Location);
            Assert.AreEqual(1, turn6.RobotActions[0].DropoffAction.DestinationPieceCount);

        }

        [TestMethod]
        public void BoardTwoRobotsMk26ColorsTinyMapTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get6ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            List<Robot> robots = new() {
                new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1)),
                new Robot(2, new Vector2(centerPointLocation.X - 1, centerPointLocation.Y), new Vector2(centerPointLocation.X - 1, centerPointLocation.Y))
            };
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>() {
                    //new Piece() {
                    //    Id = 1,
                    //    Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 2,
                    //    Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    //new Piece() {
                    //    Id = 5,
                    //    Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 6,
                    //    Image = ImageCropping.CreateImage(Color.Purple.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 7,
                    //    Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 8,
                    //    Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 9,
                    //    Image = ImageCropping.CreateImage(Color.Yellow.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //},
                    //new Piece() {
                    //    Id = 10,
                    //    Image = ImageCropping.CreateImage(Color.Orange.ToPixel<Rgb24>()),
                    //    Location = centerPointLocation
                    //}
                },
                sortedDropZones,
                robots);

            //Act
            TimeLine results = board.RunRobotsMk2();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(2, board.SortedPieces.Count);
            Assert.IsNotNull(results);
            Assert.AreEqual(6, results.Turns.Count);

            //Robot 1 + 2 Pickup
            Turn turn1 = results.Turns[0];
            Assert.AreEqual(1, turn1.TurnNumber);
            Assert.AreEqual(2, turn1.RobotActions.Count);
            Assert.AreEqual(3, turn1.RobotActions[0].PieceId);
            Assert.AreEqual(4, turn1.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(2, 2), turn1.RobotActions[0].PickupAction.Location);
            Assert.AreEqual(new Vector2(2, 2), turn1.RobotActions[1].PickupAction.Location);
            Assert.IsNull(turn1.RobotActions[0].Movement);
            Assert.IsNull(turn1.RobotActions[1].Movement);

            //this turn is problematic
            //Robot 1 move to dropoff, Robot 2 waiting
            Turn turn2 = results.Turns[1];
            Assert.AreEqual(2, turn2.TurnNumber);
            Assert.AreEqual(2, turn2.RobotActions.Count);
            Assert.AreEqual(3, turn2.RobotActions[0].PieceId);
            Assert.AreEqual(4, turn2.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(2, 1), turn2.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 1), turn2.RobotActions[0].Movement[1]);
            Assert.AreEqual(new Vector2(1, 2), turn2.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(1, 2), turn2.RobotActions[1].Movement[1]);

            //Robot 1 Dropoff, Robot 2 waiting
            Turn turn3 = results.Turns[2];
            Assert.AreEqual(3, turn3.TurnNumber);
            Assert.AreEqual(2, turn3.RobotActions.Count);
            Assert.AreEqual(3, turn3.RobotActions[0].PieceId);
            Assert.AreEqual(4, turn3.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(0, 1), turn3.RobotActions[0].DropoffAction.Location);
            Assert.AreEqual(1, turn3.RobotActions[0].DropoffAction.DestinationPieceCount);
            Assert.AreEqual(new Vector2(1, 2), turn3.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(1, 2), turn3.RobotActions[1].Movement[1]);


            //Move Robot 1 back to pickup, Robot 2 waiting
            Turn turn4 = results.Turns[3];
            Assert.AreEqual(4, turn4.TurnNumber);
            Assert.AreEqual(2, turn4.RobotActions.Count);
            Assert.AreEqual(2, turn4.RobotActions[0].RobotId);
            Assert.AreEqual(1, turn4.RobotActions[1].RobotId);
            Assert.AreEqual(4, turn4.RobotActions[0].PieceId);
            Assert.AreEqual(null, turn4.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(1, 1), turn4.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(2, 1), turn4.RobotActions[1].Movement[1]);

            //Robot 1 is idle, Robot 2 moving to dropoff
            Turn turn5 = results.Turns[4];
            Assert.AreEqual(5, turn5.TurnNumber);
            Assert.AreEqual(1, turn5.RobotActions.Count);
            Assert.AreEqual(2, turn5.RobotActions[0].RobotId);
            Assert.AreEqual(4, turn5.RobotActions[0].PieceId);
            Assert.AreEqual(new Vector2(1, 2), turn5.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 1), turn5.RobotActions[0].Movement[1]);

            //Robot 1 is idle, Robot 2 dropping off
            Turn turn6 = results.Turns[5];
            Assert.AreEqual(6, turn6.TurnNumber);
            Assert.AreEqual(1, turn6.RobotActions.Count);
            Assert.AreEqual(2, turn6.RobotActions[0].RobotId);
            Assert.AreEqual(4, turn6.RobotActions[0].PieceId);
            Assert.AreEqual(new Vector2(1, 0), turn6.RobotActions[0].DropoffAction.Location);
            Assert.AreEqual(1, turn6.RobotActions[0].DropoffAction.DestinationPieceCount);


            //Robot 1 is idle, Robot 2 moving back to pickup
            Turn turn7 = results.Turns[6];
            Assert.AreEqual(7, turn7.TurnNumber);
            Assert.AreEqual(1, turn7.RobotActions.Count);
            Assert.AreEqual(2, turn7.RobotActions[0].RobotId);
            Assert.AreEqual(null, turn7.RobotActions[0].PieceId);
            Assert.AreEqual(new Vector2(1, 1), turn7.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1, 2), turn7.RobotActions[0].Movement[1]);

        }

        [TestMethod]
        public void BoardFourRobots6ColorsTest()
        {
            //Arrange
            int width = 7;
            int height = 7;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get6ColorPalette();
            Dictionary<int, Vector2> robotStartingLocations = new()
            {
                { 1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1) },
                { 2, new Vector2(centerPointLocation.X - 1, centerPointLocation.Y) },
                { 3, new Vector2(centerPointLocation.X + 1, centerPointLocation.Y) },
                { 4, new Vector2(centerPointLocation.X, centerPointLocation.Y + 1) }
            };
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            List<Robot> robots = new() {
                new Robot(1, robotStartingLocations[1], robotStartingLocations[1]),
                new Robot(2, robotStartingLocations[2], robotStartingLocations[2]),
                new Robot(3, robotStartingLocations[3], robotStartingLocations[3]),
                new Robot(4, robotStartingLocations[4], robotStartingLocations[4])
            };
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>() {
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 5,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 6,
                        Image = ImageCropping.CreateImage(Color.Purple.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 7,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 8,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 9,
                        Image = ImageCropping.CreateImage(Color.Yellow.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 10,
                        Image = ImageCropping.CreateImage(Color.Orange.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                robots);

            //Act
            TimeLine results = board.RunRobotsMk2();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(10, board.SortedPieces.Count);
            Assert.IsNotNull(results);
            Assert.AreEqual(48, results.Turns.Count);

            ////check the first turn
            //Turn turn1 = results.Turns[0];
            //Assert.AreEqual(1, turn1.TurnNumber);
            //Assert.AreEqual(2, turn1.RobotActions.Count);
            //Assert.AreEqual(1, turn1.RobotActions[0].PieceId);
            //Assert.AreEqual(2, turn1.RobotActions[1].PieceId);
            //Assert.IsNull(turn1.RobotActions[0].Movement);
            //Assert.IsNull(turn1.RobotActions[1].Movement);

            //Turn turn2 = results.Turns[1];
            //Assert.AreEqual(2, turn2.TurnNumber);
            //Assert.AreEqual(2, turn2.RobotActions.Count);
            //Assert.AreEqual(1, turn2.RobotActions[0].PieceId);
            //Assert.AreEqual(2, turn2.RobotActions[1].PieceId);
            //Assert.AreEqual(2, turn2.RobotActions[0].Movement.Count);
            //Assert.AreEqual(2, turn2.RobotActions[1].Movement.Count);
            //Assert.AreEqual(new Vector2(3, 2), turn2.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(2, 2), turn2.RobotActions[0].Movement[1]);
            //Assert.AreEqual(new Vector2(2, 3), turn2.RobotActions[1].Movement[0]);
            //Assert.AreEqual(new Vector2(1, 3), turn2.RobotActions[1].Movement[1]);

            //Turn turn3 = results.Turns[2];
            //Assert.AreEqual(3, turn3.TurnNumber);
            //Assert.AreEqual(2, turn3.RobotActions.Count);
            //Assert.AreEqual(1, turn3.RobotActions[0].PieceId);
            //Assert.AreEqual(2, turn3.RobotActions[1].PieceId);
            //Assert.AreEqual(new Vector2(2, 2), turn3.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(1, 2), turn3.RobotActions[0].Movement[1]);
            //Assert.AreEqual(1, turn3.RobotActions[1].DropoffAction.DestinationPieceCount);
            //Assert.AreEqual(new Vector2(0, 3), turn3.RobotActions[1].DropoffAction.Location);

            ////Assert.AreEqual(new Vector2(0, 1), turn3.RobotActions[0].DropoffAction.Location);
            ////Assert.AreEqual(new Vector2(0, 3), turn3.RobotActions[1].DropoffAction.Location);
            ////Assert.AreEqual(1, turn3.RobotActions[0].DropoffAction.DestinationPieceCount);
            ////Assert.AreEqual(1, turn3.RobotActions[1].DropoffAction.DestinationPieceCount);
            ////Assert.IsNull(turn3.RobotActions[0].Movement);
            ////Assert.IsNull(turn3.RobotActions[1].Movement);

            //Turn turn4 = results.Turns[3];
            //Assert.AreEqual(4, turn4.TurnNumber);
            //Assert.AreEqual(2, turn4.RobotActions.Count);
            //Assert.AreEqual(1, turn4.RobotActions[0].PieceId);
            //Assert.AreEqual(null, turn4.RobotActions[1].PieceId);
            //Assert.AreEqual(new Vector2(1, 2), turn4.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(1, 1), turn4.RobotActions[0].Movement[1]);
            //Assert.AreEqual(new Vector2(1, 3), turn4.RobotActions[1].Movement[0]);
            //Assert.AreEqual(new Vector2(2, 3), turn4.RobotActions[1].Movement[1]);

            Turn turn5 = results.Turns[4];
            Assert.AreEqual(5, turn5.TurnNumber);
            Assert.AreEqual(4, turn5.RobotActions.Count);
            Assert.AreEqual(2, turn5.RobotActions[3].RobotId);
            Assert.AreEqual(6, turn5.RobotActions[3].PieceId);
            //Assert.AreEqual(new Vector2(1, 2), turn4.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(1, 1), turn4.RobotActions[0].Movement[1]);
            //Assert.AreEqual(new Vector2(1, 3), turn4.RobotActions[1].Movement[0]);
            //Assert.AreEqual(new Vector2(2, 3), turn4.RobotActions[1].Movement[1]);


            ////Turn 11 check for bugs
            //Turn turn11 = results.Turns[10];
            //Assert.AreEqual(11, turn11.TurnNumber);
            //Assert.AreEqual(2, turn11.RobotActions.Count);
            //Assert.AreEqual(3, turn11.RobotActions[0].PieceId);
            //Assert.AreEqual(6, turn11.RobotActions[1].PieceId);

            ////Turn 12, the bots previously crossed paths, but shouldn't anymore
            //Turn turn12 = results.Turns[11];
            //Assert.AreEqual(12, turn12.TurnNumber);
            //Assert.AreEqual(2, turn12.RobotActions.Count);
            //Assert.AreEqual(new Vector2(1, 2), turn12.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(1, 1), turn12.RobotActions[0].Movement[1]);
            //Assert.AreEqual(new Vector2(2, 3), turn12.RobotActions[1].Movement[0]);
            //Assert.AreEqual(new Vector2(2, 3), turn12.RobotActions[1].Movement[1]);

            ////Turn 15, the bots previously crossed paths, but shouldn't anymore
            //Turn turn15 = results.Turns[14];
            //Assert.AreEqual(15, turn15.TurnNumber);
            //Assert.AreEqual(2, turn15.RobotActions.Count);
            //Assert.AreEqual(new Vector2(2, 1), turn15.RobotActions[0].Movement[0]);
            //Assert.AreEqual(new Vector2(2, 2), turn15.RobotActions[0].Movement[1]);
            //Assert.AreEqual(new Vector2(2, 3), turn15.RobotActions[1].Movement[0]);
            //Assert.AreEqual(new Vector2(2, 3), turn15.RobotActions[1].Movement[1]);


            //////Turn 13, the bots cross paths, but shouldn't
            ////Turn turn13 = results.Turns[12];
            ////Assert.AreEqual(13, turn13.TurnNumber);
            ////Assert.AreEqual(2, turn13.RobotActions.Count);
            ////Assert.AreEqual(new Vector2(2, 3), turn13.RobotActions[0].Movement[0]);
            ////Assert.AreEqual(new Vector2(1 ,3), turn13.RobotActions[0].Movement[1]);
            ////Assert.AreEqual(2, turn13.RobotActions[1].RobotId);
            ////Assert.AreEqual(new Vector2(1, 3), turn13.RobotActions[1].Movement[0]);
            ////Assert.AreEqual(new Vector2(2, 3), turn13.RobotActions[1].Movement[1]);

            //////check the fourth to last turn
            ////Assert.AreEqual(17, results.Turns[results.Turns.Count - 4].TurnNumber);
            ////Assert.AreEqual(2, results.Turns[results.Turns.Count - 4].RobotActions.Count);
            ////Assert.AreEqual(9, results.Turns[results.Turns.Count - 4].RobotActions[0].PieceId);
            ////Assert.AreEqual(10, results.Turns[results.Turns.Count - 4].RobotActions[1].PieceId);

            //////check the third to last turn
            ////Assert.AreEqual(18, results.Turns[results.Turns.Count - 3].TurnNumber);
            ////Assert.AreEqual(2, results.Turns[results.Turns.Count - 3].RobotActions.Count);
            ////Assert.AreEqual(9, results.Turns[results.Turns.Count - 3].RobotActions[0].PieceId);

            //////check the second to last turn
            ////Assert.AreEqual(19, results.Turns[results.Turns.Count - 2].TurnNumber);
            ////Assert.AreEqual(2, results.Turns[results.Turns.Count - 2].RobotActions.Count);
            ////Assert.AreEqual(10, results.Turns[results.Turns.Count - 2].RobotActions[0].PieceId);

            //////check the last turn
            ////Assert.AreEqual(20, results.Turns[results.Turns.Count - 1].TurnNumber);
            ////Assert.AreEqual(2, results.Turns[results.Turns.Count - 1].RobotActions.Count);
            ////Assert.AreEqual(null, results.Turns[results.Turns.Count - 1].RobotActions[0].PieceId);

        }
    }
}
