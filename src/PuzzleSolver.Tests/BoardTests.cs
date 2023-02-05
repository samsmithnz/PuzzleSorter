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
            Board board = new()
            {
                Map = MapGeneration.GenerateMap(),
                UnsortedPiecesLocation = new(2, 2),
                UnsortedPieces = new(new[] {
                    Color.Red.ToPixel<Rgb24>(),
                    Color.Blue.ToPixel<Rgb24>(),
                    Color.Red.ToPixel<Rgb24>(),
                    Color.Green.ToPixel<Rgb24>() }),
                SortedPieces = new()
                {
                    { Color.Red.ToPixel<Rgb24>(), new(Color.Red.ToPixel<Rgb24>(),new(0, 0))},
                    { Color.Blue.ToPixel<Rgb24>(), new(Color.Blue.ToPixel<Rgb24>(),new(0, 4))},
                    { Color.Green.ToPixel<Rgb24>(), new(Color.Green.ToPixel<Rgb24>(),new(4, 0))},
                    { Color.Yellow.ToPixel<Rgb24>(), new(Color.Yellow.ToPixel<Rgb24>(),new(4, 4))}
                },
                SortedPiecesCount = 0,
                Robot = new(new(2, 1))
            };

            //Act

            //Assert
            Assert.IsNotNull(board);
            Assert.IsNotNull(board.Map);
            Assert.IsNotNull(board.Robot);
            Assert.AreEqual(new(2, 2), board.UnsortedPiecesLocation);
            Assert.AreEqual(4, board.SortedPieces.Count);
            Assert.AreEqual(new(0, 0), board.SortedPieces[Color.Red.ToPixel<Rgb24>()].Location);
            Assert.AreEqual(0, board.SortedPiecesCount);
            Assert.AreEqual(4, board.UnsortedPiecesCount);
            Assert.AreEqual(new Vector2(2, 1), board.Robot.Location);
        }

        [TestMethod]
        public void BoardRunTest()
        {
            //Arrange
            Board board = new()
            {
                Map = MapGeneration.GenerateMap(),
                UnsortedPiecesLocation = new(2, 2),
                UnsortedPieces = new(new[] {
                    Color.Red.ToPixel<Rgb24>(),
                    Color.Blue.ToPixel<Rgb24>(),
                    Color.Red.ToPixel<Rgb24>(),
                    Color.Green.ToPixel<Rgb24>() }),
                SortedPieces = new()
                {
                    { Color.Red.ToPixel<Rgb24>(), new(Color.Red.ToPixel<Rgb24>(),new(0, 0))},
                    { Color.Blue.ToPixel<Rgb24>(), new(Color.Blue.ToPixel<Rgb24>(),new(0, 4))},
                    { Color.Green.ToPixel<Rgb24>(), new(Color.Green.ToPixel<Rgb24>(),new(4, 0))},
                    { Color.Yellow.ToPixel<Rgb24>(), new(Color.Yellow.ToPixel<Rgb24>(),new(4, 4))}
                },
                SortedPiecesCount = 0,
                Robot = new(new(2, 1))
            };

            //Act
            Queue<RobotAction> results = board.RunRobot();

            //Assert           
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
        }

    }
}
