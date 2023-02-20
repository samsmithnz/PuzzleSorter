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
    public class BoardTests
    {

        [TestMethod]
        public void BoardInitializationTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get3ColorPalette();
            Robot robot = new Robot(new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
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
                robot);

            //Act

            //Assert
            Assert.AreEqual(new Rgb24(255, 0, 0), Color.Red.ToPixel<Rgb24>());
            Assert.AreEqual(new Rgb24(0, 0, 255), Color.Blue.ToPixel<Rgb24>());
            Assert.AreEqual(new Rgb24(255, 255, 0), Color.Yellow.ToPixel<Rgb24>());
            Assert.IsNotNull(board);
            Assert.IsNotNull(board.Map);
            Assert.IsNotNull(board.Robot);
            Assert.AreEqual(new(2, 2), board.UnsortedPiecesLocation);
            Assert.AreEqual(3, board.SortedDropZones.Count);
            Assert.AreEqual(new(0, 1), board.SortedDropZones[0].Location);
            Assert.AreEqual(0, board.SortedPieces.Count);
            Assert.AreEqual(4, board.UnsortedPieces.Count);
            Assert.AreEqual(new Vector2(2, 1), board.Robot.Location);
        }

        [TestMethod]
        public void BoardInitializationWith7WidthTest()
        {
            //Arrange
            int width = 7;
            int height = 7;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get3ColorPalette();
            Robot robot = new Robot(new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
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
                robot);

            //Act

            //Assert
            Assert.AreEqual(new Rgb24(255, 0, 0), Color.Red.ToPixel<Rgb24>());
            Assert.AreEqual(new Rgb24(0, 0, 255), Color.Blue.ToPixel<Rgb24>());
            Assert.AreEqual(new Rgb24(255, 255, 0), Color.Yellow.ToPixel<Rgb24>());
            Assert.IsNotNull(board);
            Assert.IsNotNull(board.Map);
            Assert.IsNotNull(board.Robot);
            Assert.AreEqual(new(3, 3), board.UnsortedPiecesLocation);
            Assert.AreEqual(3, board.SortedDropZones.Count);
            Assert.AreEqual(new(0, 4), board.SortedDropZones[0].Location);
            Assert.AreEqual(0, board.SortedPieces.Count);
            Assert.AreEqual(4, board.UnsortedPieces.Count);
            Assert.AreEqual(new Vector2(3, 2), board.Robot.Location);
        }

        [TestMethod]
        public void Board3ColorsRunTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get3ColorPalette();
            Robot robot = new Robot(new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
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
                robot);

            //Act
            Queue<RobotAction> results = board.RunRobot();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(4, board.SortedPieces.Count);
            Assert.IsTrue(board.UnsortedPieces.Count == 0);
            Assert.IsNotNull(results);
            Assert.AreEqual(5, results.Count);

            //Complete the first action
            RobotAction robotAction1 = results.Dequeue();
            Assert.IsNotNull(robotAction1);
            Assert.IsNotNull(robotAction1.PieceId);
            Assert.IsNull(robotAction1.PathToPickup); //This is null because we start in the right location
            Assert.IsNotNull(robotAction1.PickupAction);
            Assert.IsNotNull(robotAction1.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction1.RobotDropoffStartingLocation);
            Assert.AreEqual(new(1, 1), robotAction1.PathToDropoff.Path[0]);
            Assert.AreEqual(new(1, 2), robotAction1.PathToDropoff.Path[1]);
            Assert.AreEqual(new(0, 2), robotAction1.PathToDropoff.Path[2]);
            Assert.AreEqual(new(0, 3), robotAction1.PathToDropoff.Path[3]);
            Assert.AreEqual(new(0, 3), robotAction1.RobotDropoffEndingLocation);
            Assert.AreEqual(1, robotAction1.DropoffPieceCount);
            Assert.IsNotNull(robotAction1.DropoffAction);
            Assert.AreEqual(new(0, 4), board.SortedPieces[0].Location);
            Assert.AreEqual(4, results.Count);

            //Complete the second action
            RobotAction robotAction2 = results.Dequeue();
            Assert.IsNotNull(robotAction2);
            Assert.IsNotNull(robotAction2.PieceId);
            Assert.IsNotNull(robotAction2.PathToPickup);
            Assert.AreEqual(new(0, 3), robotAction2.RobotPickupStartingLocation);
            Assert.AreEqual(new(1, 3), robotAction2.PathToPickup.Path[0]);
            Assert.AreEqual(new(1, 2), robotAction2.PathToPickup.Path[1]);
            Assert.AreEqual(new(1, 1), robotAction2.PathToPickup.Path[2]);
            Assert.AreEqual(new(2, 1), robotAction2.RobotPickupEndingLocation);
            Assert.IsNotNull(robotAction2.PickupAction);
            Assert.IsNotNull(robotAction2.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction2.RobotDropoffStartingLocation);
            Assert.AreEqual(new(3, 1), robotAction2.PathToDropoff.Path[0]);
            Assert.AreEqual(new(4, 1), robotAction2.PathToDropoff.Path[1]);
            Assert.AreEqual(new(4, 1), robotAction2.RobotDropoffEndingLocation);
            Assert.AreEqual(1, robotAction2.DropoffPieceCount);
            Assert.IsNotNull(robotAction2.DropoffAction);
            Assert.AreEqual(3, results.Count);

            //Complete the third action
            RobotAction robotAction3 = results.Dequeue();
            Assert.IsNotNull(robotAction3);
            Assert.IsNotNull(robotAction3.PieceId);
            Assert.IsNotNull(robotAction3.PathToPickup);
            Assert.AreEqual(new(4, 1), robotAction3.RobotPickupStartingLocation);
            Assert.AreEqual(new(3, 1), robotAction3.PathToPickup.Path[0]);
            Assert.AreEqual(new(2, 1), robotAction3.PathToPickup.Path[1]);
            Assert.AreEqual(new(2, 1), robotAction3.RobotPickupEndingLocation);
            Assert.IsNotNull(robotAction3.PickupAction);
            Assert.IsNotNull(robotAction3.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction3.RobotDropoffStartingLocation);
            Assert.AreEqual(new(1, 1), robotAction3.PathToDropoff.Path[0]);
            Assert.AreEqual(new(1, 2), robotAction3.PathToDropoff.Path[1]);
            Assert.AreEqual(new(0, 2), robotAction3.PathToDropoff.Path[2]);
            Assert.AreEqual(new(0, 3), robotAction3.PathToDropoff.Path[3]);
            Assert.AreEqual(new(0, 3), robotAction3.RobotDropoffEndingLocation);
            Assert.AreEqual(2, robotAction3.DropoffPieceCount);
            Assert.IsNotNull(robotAction3.DropoffAction);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(Color.Red.ToPixel<Rgb24>(), board.SortedPieces[0].TopColorGroup);
            Assert.AreEqual(2, board.SortedDropZones[0].Count);
            Assert.AreEqual(1, board.SortedDropZones[1].Count);
            Assert.AreEqual(1, board.SortedDropZones[2].Count);
            Assert.AreEqual(2, board.GetPieceCount(board.SortedDropZones[0].Location));
        }

        [TestMethod]
        public void Board6ColorsRunTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get6ColorPalette();
            Robot robot = new Robot(new System.Numerics.Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
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
            robot);

            //Act
            Queue<RobotAction> results = board.RunRobot();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(10, board.SortedPieces.Count);
            Assert.IsTrue(board.UnsortedPieces.Count == 0);
            Assert.IsNotNull(results);
            Assert.AreEqual(11, results.Count);

            //Complete the first action
            RobotAction robotAction1 = results.Dequeue();
            Assert.IsNotNull(robotAction1);
            Assert.IsNotNull(robotAction1.PieceId);
            Assert.IsNull(robotAction1.PathToPickup); //This is null because we start in the right location
            Assert.IsNotNull(robotAction1.PickupAction);
            Assert.IsNotNull(robotAction1.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction1.RobotDropoffStartingLocation);
            Assert.AreEqual(new(1, 1), robotAction1.PathToDropoff.Path[0]);
            Assert.AreEqual(new(1, 2), robotAction1.PathToDropoff.Path[1]);
            Assert.AreEqual(new(0, 2), robotAction1.PathToDropoff.Path[2]);
            Assert.AreEqual(new(0, 3), robotAction1.PathToDropoff.Path[3]);
            Assert.AreEqual(new(0, 3), robotAction1.RobotDropoffEndingLocation);
            Assert.AreEqual(1, robotAction1.DropoffPieceCount);
            Assert.IsNotNull(robotAction1.DropoffAction);
            Assert.AreEqual(new(0, 4), board.SortedPieces[0].Location);
            Assert.AreEqual(10, results.Count);

            //Complete the second action
            RobotAction robotAction2 = results.Dequeue();
            Assert.IsNotNull(robotAction2);
            Assert.IsNotNull(robotAction2.PieceId);
            Assert.IsNotNull(robotAction2.PathToPickup);
            Assert.AreEqual(new(0, 3), robotAction2.RobotPickupStartingLocation);
            Assert.AreEqual(new(1, 3), robotAction2.PathToPickup.Path[0]);
            Assert.AreEqual(new(1, 2), robotAction2.PathToPickup.Path[1]);
            Assert.AreEqual(new(1, 1), robotAction2.PathToPickup.Path[2]);
            Assert.AreEqual(new(2, 1), robotAction2.RobotPickupEndingLocation);
            Assert.IsNotNull(robotAction2.PickupAction);
            Assert.IsNotNull(robotAction2.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction2.RobotDropoffStartingLocation);
            Assert.AreEqual(new(3, 1), robotAction2.PathToDropoff.Path[0]);
            Assert.AreEqual(new(4, 1), robotAction2.PathToDropoff.Path[1]);
            Assert.AreEqual(new(4, 1), robotAction2.RobotDropoffEndingLocation);
            Assert.AreEqual(1, robotAction2.DropoffPieceCount);
            Assert.IsNotNull(robotAction2.DropoffAction);
            Assert.AreEqual(9, results.Count);

            //Complete the third action
            RobotAction robotAction3 = results.Dequeue();
            Assert.IsNotNull(robotAction3);
            Assert.IsNotNull(robotAction3.PieceId);
            Assert.IsNotNull(robotAction3.PathToPickup);
            Assert.AreEqual(new(4, 1), robotAction3.RobotPickupStartingLocation);
            Assert.AreEqual(new(3, 1), robotAction3.PathToPickup.Path[0]);
            Assert.AreEqual(new(2, 1), robotAction3.PathToPickup.Path[1]);
            Assert.AreEqual(new(2, 1), robotAction3.RobotPickupEndingLocation);
            Assert.IsNotNull(robotAction3.PickupAction);
            Assert.IsNotNull(robotAction3.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction3.RobotDropoffStartingLocation);
            Assert.AreEqual(new(1, 1), robotAction3.PathToDropoff.Path[0]);
            Assert.AreEqual(new(1, 2), robotAction3.PathToDropoff.Path[1]);
            Assert.AreEqual(new(0, 2), robotAction3.PathToDropoff.Path[2]);
            Assert.AreEqual(new(0, 3), robotAction3.PathToDropoff.Path[3]);
            Assert.AreEqual(new(0, 3), robotAction3.RobotDropoffEndingLocation);
            Assert.AreEqual(2, robotAction3.DropoffPieceCount);
            Assert.IsNotNull(robotAction3.DropoffAction);
            Assert.AreEqual(8, results.Count);

            //Complete the fourth action
            RobotAction robotAction4 = results.Dequeue();
            Assert.IsNotNull(robotAction4);
            Assert.IsNotNull(robotAction4.PieceId);
            Assert.IsNotNull(robotAction4.PathToPickup);
            //Assert.AreEqual(new(4, 0), robotAction4.RobotPickupStartingLocation);
            //Assert.AreEqual(new(3, 0), robotAction4.PathToPickup.Path[0]);
            //Assert.AreEqual(new(2, 0), robotAction4.PathToPickup.Path[1]);
            //Assert.AreEqual(new(2, 1), robotAction4.PathToPickup.Path[2]);
            //Assert.AreEqual(new(2, 1), robotAction4.RobotPickupEndingLocation);
            Assert.IsNotNull(robotAction4.PickupAction);
            Assert.IsNotNull(robotAction4.PathToDropoff);
            //Assert.AreEqual(new(2, 1), robotAction4.RobotDropoffStartingLocation);
            //Assert.AreEqual(new(1, 1), robotAction4.PathToDropoff.Path[0]);
            //Assert.AreEqual(new(1, 2), robotAction4.PathToDropoff.Path[1]);
            //Assert.AreEqual(new(1, 3), robotAction4.PathToDropoff.Path[2]);
            //Assert.AreEqual(new(0, 3), robotAction4.PathToDropoff.Path[3]);
            //Assert.AreEqual(new(0, 4), robotAction4.PathToDropoff.Path[4]);
            //Assert.AreEqual(new(0, 4), robotAction4.RobotDropoffEndingLocation);
            Assert.AreEqual(1, robotAction4.DropoffPieceCount);
            Assert.IsNotNull(robotAction4.DropoffAction);
            Assert.AreEqual(7, results.Count);

            Assert.AreEqual(Color.Red.ToPixel<Rgb24>(), board.SortedPieces[0].TopColorGroup);
            Assert.AreEqual(4, board.SortedDropZones[0].Count);
            Assert.AreEqual(1, board.SortedDropZones[1].Count);
            Assert.AreEqual(2, board.SortedDropZones[2].Count);
            Assert.AreEqual(1, board.SortedDropZones[3].Count);
            Assert.AreEqual(1, board.SortedDropZones[4].Count);
            Assert.AreEqual(1, board.SortedDropZones[5].Count);
            Assert.AreEqual(4, board.GetPieceCount(board.SortedDropZones[0].Location));
        }

    }
}
