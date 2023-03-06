using PuzzleSolver.Images;
using PuzzleSolver.Map;
using PuzzleSolver.MultipleRobots;
using PuzzleSolver.Processing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace PuzzleSolver.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    [TestCategory("L1")]
    public class BoardL1Tests
    {

        [TestMethod]
        public void StJohnOneRobotImage16ColorsRunTest()
        {
            //Arrange
            int width = 7;
            int height = 7;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get16ColorPalette();
            //Process + Split the image
            string imageDir = Environment.CurrentDirectory + @"/TestImages/st-john-beach.jpg";
            Image<Rgb24> sourceImage = Image.Load<Rgb24>(imageDir);
            List<Image<Rgb24>> images = ImageCropping.SplitImageIntoMultiplePieces(sourceImage, 250, 250);
            List<ImageStats> subImages = new();
            ImageColorGroups imageProcessing = new(palette);
            foreach (Image<Rgb24> image in images)
            {
                ImageStats subitemImageStats = imageProcessing.ProcessStatsForImage(null, image, true);
                if (subitemImageStats != null)
                {
                    subImages.Add(subitemImageStats);
                }
            }
            int i = 0;
            List<Piece> pieces = new List<Piece>();
            foreach (ImageStats image in subImages)
            {
                i++;
                pieces.Add(new Piece()
                {
                    Id = i,
                    Image = image.Image,
                    ImageStats = image,
                    Location = centerPointLocation
                });
            }
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            Robot robot = new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                pieces,
                sortedDropZones,
                new List<Robot>() { robot });

            //Act
            TimeLine results = board.RunRobots();

            //Assert
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(12, board.SortedPieces.Count);
            Assert.IsTrue(board.UnsortedPieces.Count == 0);
            Assert.IsNotNull(results);
            Assert.AreEqual(82, results.Turns.Count);
        }

    }
}
