using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PuzzleSolver.Tests;

[TestClass]
public class ImageProcessingTests
{
    [TestMethod]
    public void FourPixelImageTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new();
        string imageDir = Environment.CurrentDirectory;
        imageDir += @"/TestImages/baseImage.png";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(3, groupedColors.Count);
        Assert.AreEqual(2, groupedColors[Color.Red.ToPixel<Rgb24>()].Count);
    }
}