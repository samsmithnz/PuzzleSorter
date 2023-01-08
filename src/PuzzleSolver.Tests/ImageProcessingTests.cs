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
        imageDir += @"/TestImages/BaseImage.png";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(3, groupedColors.Count);
        Assert.AreEqual(2, groupedColors[Color.Red.ToPixel<Rgb24>()].Count);
    }
    
    [TestMethod]
    public void PrimaryAndSecondaryColorsImageTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new();
        string imageDir = Environment.CurrentDirectory;
        imageDir += @"/TestImages/PrimaryAndSecondaryColors.png";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(6, groupedColors.Count);
        Assert.AreEqual(25*25, groupedColors[Color.Red.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, groupedColors[Color.Blue.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, groupedColors[Color.Yellow.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, groupedColors[Color.Purple.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, groupedColors[Color.Orange.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, groupedColors[Color.Green.ToPixel<Rgb24>()].Count);
    }

    [TestMethod]
    public void RedToBlueBlendColorsImageTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new();
        string imageDir = Environment.CurrentDirectory;
        imageDir += @"/TestImages/RedToBlueBlend.jpg";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(4, groupedColors.Count);
        Assert.AreEqual(59160, groupedColors[Color.Blue.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(118660, groupedColors[Color.White.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(29920, groupedColors[Color.Orange.ToPixel<Rgb24>()].Count); //one of the bars is closer to orange than white or red
        Assert.AreEqual(59160, groupedColors[Color.Red.ToPixel<Rgb24>()].Count);
    }

    [TestMethod]
    public void PuzzlePiecesImageTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new();
        string imageDir = Environment.CurrentDirectory;
        imageDir += @"/TestImages/PuzzlePieces.jpg";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(8, groupedColors.Count);
        Assert.AreEqual(167062, groupedColors[Color.Red.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(168713, groupedColors[Color.Blue.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(1576, groupedColors[Color.Yellow.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(182167, groupedColors[Color.Orange.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(9431, groupedColors[Color.Purple.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(186354, groupedColors[Color.Green.ToPixel<Rgb24>()].Count); 
        Assert.AreEqual(92385, groupedColors[Color.Black.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(2293112, groupedColors[Color.White.ToPixel<Rgb24>()].Count);
    }
}