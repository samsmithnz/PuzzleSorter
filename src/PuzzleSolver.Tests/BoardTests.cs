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
                    { new(0, 0), Color.Red.ToPixel<Rgb24>() },
                    { new(0, 4), Color.Blue.ToPixel<Rgb24>() },
                    { new(4, 0), Color.Green.ToPixel<Rgb24>() },
                    { new(4, 4), Color.Yellow.ToPixel<Rgb24>() }
                },
                SortedPiecesCount = 0,
                Robot = new(new(2, 1))
            };

            //Act

            //Assert
            Assert.IsNotNull(board);
            Assert.IsNotNull(board.Map);
            Assert.AreEqual(new(2, 2), board.UnsortedPiecesLocation);
            Assert.AreEqual(4, board.SortedPiecesLocations.Count);
            Assert.AreEqual(Color.Red.ToPixel<Rgb24>(), board.SortedPiecesLocations[new(0, 0)]);
        }

    }
}
