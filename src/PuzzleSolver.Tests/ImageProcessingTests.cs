using SixLabors.ImageSharp.PixelFormats;

namespace PuzzleSolver.Tests;

[TestClass]
public class ImageProcessingTests
{
    [TestMethod]
    public void ImageTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new();

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(@"C:\Users\samsm\source\repos\PuzzleSolver\src\PuzzleSolver\baseImage.png");

        //Assert
        Assert.AreEqual(3, groupedColors.Count);
    }
}