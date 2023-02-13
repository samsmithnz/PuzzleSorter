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
            Board board = new(MapGeneration.GenerateMap(),
                new(2, 2),
                ColorPalettes.Get3ColorPalette(),
                new List<Piece>(){
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = new(2, 2)
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = new(2, 2)
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = new(2, 2)
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = new(2, 2)
                    }
                },
                new()
                {
                    new SortedDropZone(Color.Red.ToPixel<Rgb24>(), new(0, 4)),
                    new SortedDropZone(Color.Blue.ToPixel<Rgb24>(), new(4, 0)),
                    new SortedDropZone(Color.Yellow.ToPixel<Rgb24>(), new(4, 4))
                },
                new Robot(new(2, 1)));

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
            Assert.AreEqual(new(0, 4), board.SortedDropZones[0].Location);
            Assert.AreEqual(0, board.SortedPieces.Count);
            Assert.AreEqual(4, board.UnsortedPieces.Count);
            Assert.AreEqual(new Vector2(2, 1), board.Robot.Location);
        }

        [TestMethod]
        public void BoardRunTest()
        {
            //Arrange
            Board board = new(MapGeneration.GenerateMap(),
                new(2, 2),
                ColorPalettes.Get3ColorPalette(),
                new List<Piece>() {
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = new(2, 2)
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = new(2, 2)
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = new(2, 2)
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = new(2, 2)
                    }
                },
                new()
                {
                    new SortedDropZone(Color.Red.ToPixel<Rgb24>(), new(0, 4)),
                    new SortedDropZone(Color.Blue.ToPixel<Rgb24>(), new(4, 0)),
                    new SortedDropZone(Color.Yellow.ToPixel<Rgb24>(), new(4, 4)),
                    //new SortedDropZone(Color.Yellow.ToPixel<Rgb24>(),new(4, 4)),
                },
                new Robot(new(2, 1)));

            //Act
            Queue<RobotAction> results = board.RunRobot();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(4, board.SortedPieces.Count);
            Assert.IsTrue(board.UnsortedPieces.Count == 0);
            Assert.IsNotNull(results);
            Assert.AreEqual(4, results.Count);

            RobotAction robotAction1 = results.Dequeue(); //Complete the first action
            Assert.IsNotNull(robotAction1);
            Assert.IsNotNull(robotAction1.PieceId);
            Assert.IsNull(robotAction1.PathToPickup); //This is null because we start in the right location
            Assert.IsNotNull(robotAction1.PickupAction);
            Assert.IsNotNull(robotAction1.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction1.RobotDropoffStartingLocation);
            Assert.AreEqual(new(1, 1), robotAction1.PathToDropoff.Path[0]);
            Assert.AreEqual(new(1, 2), robotAction1.PathToDropoff.Path[1]);
            Assert.AreEqual(new(1, 3), robotAction1.PathToDropoff.Path[2]);
            Assert.AreEqual(new(0, 3), robotAction1.PathToDropoff.Path[3]);
            Assert.AreEqual(new(0, 4), robotAction1.PathToDropoff.Path[4]);
            Assert.AreEqual(new(0, 4), robotAction1.RobotDropoffEndingLocation);
            Assert.IsNotNull(robotAction1.DropoffAction);
            Assert.AreEqual(3, results.Count);

            RobotAction robotAction2 = results.Dequeue(); //Complete the second action
            Assert.IsNotNull(robotAction2);
            Assert.IsNotNull(robotAction2.PieceId);
            Assert.IsNotNull(robotAction2.PathToPickup);
            Assert.AreEqual(new(0, 4), robotAction2.RobotPickupStartingLocation);
            Assert.AreEqual(new(0, 3), robotAction2.PathToPickup.Path[0]);
            Assert.AreEqual(new(1, 3), robotAction2.PathToPickup.Path[1]);
            Assert.AreEqual(new(1, 2), robotAction2.PathToPickup.Path[2]);
            Assert.AreEqual(new(2, 1), robotAction2.RobotPickupEndingLocation);
            Assert.IsNotNull(robotAction2.PickupAction);
            Assert.IsNotNull(robotAction2.PathToDropoff);
            Assert.IsNotNull(robotAction2.DropoffAction);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(Color.Red.ToPixel<Rgb24>(), board.SortedPieces[0].TopColorGroup);
        }

    }
}
