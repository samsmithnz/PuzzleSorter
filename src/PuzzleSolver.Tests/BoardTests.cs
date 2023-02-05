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
                SortedPiecesLocations = new()
                {
                    { Color.Red.ToPixel<Rgb24>(), new(0, 0)},
                    { Color.Blue.ToPixel<Rgb24>(), new(0, 4)},
                    { Color.Green.ToPixel<Rgb24>(), new(4, 0)},
                    { Color.Yellow.ToPixel<Rgb24>(), new(4, 4)}
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
            Assert.AreEqual(4, board.SortedPiecesLocations.Count);
            Assert.AreEqual(new(0, 0), board.SortedPiecesLocations[Color.Red.ToPixel<Rgb24>()]);
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
                SortedPiecesLocations = new()
                {
                    { Color.Red.ToPixel<Rgb24>(), new(0, 0)},
                    { Color.Blue.ToPixel<Rgb24>(), new(0, 4)},
                    { Color.Green.ToPixel<Rgb24>(), new(4, 0)},
                    { Color.Yellow.ToPixel<Rgb24>(), new(4, 4)}
                },
                SortedPiecesCount = 0,
                Robot = new(new(2, 1))
            };

            //Act
            Queue<RobotAction> results = board.RunRobot();

            //Assert
            Assert.IsNotNull(board);
            Assert.IsNotNull(board.Map);
            Assert.IsNotNull(board.Robot);
            Assert.AreEqual(new(2, 2), board.UnsortedPiecesLocation);
            Assert.AreEqual(4, board.SortedPiecesLocations.Count);
            Assert.AreEqual(new(0, 0), board.SortedPiecesLocations[Color.Red.ToPixel<Rgb24>()]);
            Assert.AreEqual(4, board.SortedPiecesCount);
            Assert.AreEqual(0, board.UnsortedPiecesCount);
            Assert.AreEqual(new Vector2(2, 1), board.Robot.Location);
            Assert.IsNotNull(results);
            Assert.AreEqual(4, results.Count);
        }

    }
}
