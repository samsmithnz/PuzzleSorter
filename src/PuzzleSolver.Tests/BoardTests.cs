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
                    new SortedDropZone(Color.Green.ToPixel<Rgb24>(), new(4, 4))
                },
                new Robot(new(2, 1)));

            //Act

            //Assert
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
                    new SortedDropZone(Color.Green.ToPixel<Rgb24>(), new(4, 4)),
                    //new SortedDropZone(Color.Yellow.ToPixel<Rgb24>(),new(4, 4)),
                },
                new Robot(new(2, 1)));

            //Act
            Queue<RobotAction> results = board.RunRobot();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(4, board.SortedPieces.Count);
            Assert.IsNotNull(board.UnsortedPieces.Count == 0);
            Assert.IsNotNull(results);
            Assert.AreEqual(4, results.Count);
            Assert.IsNotNull(results.Peek());
            Assert.IsNotNull(results.Peek().PickupAction);
            Assert.IsNull(results.Peek().PathToPickup); //This is null because we start in the right location
            Assert.IsNotNull(results.Peek().DropoffAction);
            Assert.IsNotNull(results.Peek().PathToDropoff);
            results.Dequeue(); //Complete the first action
            Assert.AreEqual(3, results.Count);
            Assert.IsNotNull(results.Peek());
            Assert.IsNotNull(results.Peek().PickupAction);
            Assert.IsNull(results.Peek().PathToPickup);
            Assert.IsNotNull(results.Peek().DropoffAction);
            Assert.IsNotNull(results.Peek().PathToDropoff);
            Assert.AreEqual(Color.Red.ToPixel<Rgb24>(), board.SortedPieces[0].TopColorGroup);
        }

    }
}
