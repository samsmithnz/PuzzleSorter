using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Xml.Linq;

namespace PuzzleSolver.Tests;

[TestClass]
public class ImageProcessingTests
{

    [TestMethod]
    public void FourPixelImageWithJustPrimaryPaletteTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.GetPrimaryColors());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/BaseImage.png";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(3, groupedColors.Count);
        Assert.AreEqual(2, groupedColors[Color.Red.ToPixel<Rgb24>()].Count);
    }

    [TestMethod]
    public void FourPixelImageWithPrimaryAndSecondaryPaletteTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.GetPrimaryAndSecondaryColors());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/BaseImage.png";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(3, groupedColors.Count);
        Assert.AreEqual(2, groupedColors[Color.Red.ToPixel<Rgb24>()].Count);
    }

    [TestMethod]
    public void FourPixelImageWithAllNamedColorsPaletteTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.GetAllNamedColors());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/BaseImage.png";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(3, groupedColors.Count);
        Assert.AreEqual(2, groupedColors[Color.Red.ToPixel<Rgb24>()].Count);
    }

    [TestMethod]
    public void PrimaryAndSecondaryColorsImageWithOnlyPrimaryPaletteTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.GetPrimaryColors());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/PrimaryAndSecondaryColors.png";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(3, groupedColors.Count);
        Assert.AreEqual(25 * 25 * 2, groupedColors[Color.Red.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25 * 2, groupedColors[Color.Blue.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25 * 2, groupedColors[Color.Yellow.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(25 * 25, groupedColors[Color.Purple.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(25 * 25, groupedColors[Color.Orange.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(25 * 25, groupedColors[Color.Green.ToPixel<Rgb24>()].Count);
    }

    [TestMethod]
    public void PrimaryAndSecondaryColorsImageWithPrimaryAndSecondaryPaletteTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.GetPrimaryAndSecondaryColors());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/PrimaryAndSecondaryColors.png";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(6, groupedColors.Count);
        Assert.AreEqual(25 * 25, groupedColors[Color.Red.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, groupedColors[Color.Blue.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, groupedColors[Color.Yellow.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, groupedColors[Color.Purple.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, groupedColors[Color.Orange.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, groupedColors[Color.Green.ToPixel<Rgb24>()].Count);
    }

    [TestMethod]
    public void PrimaryAndSecondaryColorsImageWithNamedColorsPaletteTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.GetAllNamedColors());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/PrimaryAndSecondaryColors.png";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(6, groupedColors.Count);
        int i = 0;
        foreach (KeyValuePair<Rgb24, List<Rgb24>> entry in groupedColors)
        {
            if (i == 0)
            {
                Assert.AreEqual("Crimson", ColorPalettes.ToName(entry.Key));
            }
            else if (i ==1)
            {
                Assert.AreEqual("RoyalBlue", ColorPalettes.ToName(entry.Key));
            }
            else if (i == 2)
            {
                Assert.AreEqual("Yellow", ColorPalettes.ToName(entry.Key));
            }
            else if (i == 3)
            {
                Assert.AreEqual("DarkOrchid", ColorPalettes.ToName(entry.Key));
            }
            else if (i == 4)
            {
                Assert.AreEqual("LimeGreen", ColorPalettes.ToName(entry.Key));
            }
            else if (i == 5)
            {
                Assert.AreEqual("Coral", ColorPalettes.ToName(entry.Key));
            }
            i++;
        }
    }

    [TestMethod]
    public void RedToBlueBlendColorsImageTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.GetPrimaryAndSecondaryColors());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/RedToBlueBlend.jpg";

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
        ImageProcessing imageProcessing = new(ColorPalettes.GetPrimaryAndSecondaryColors());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/PuzzlePieces.jpg";

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

    [TestMethod]
    public void NamedColorImageTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.GetAllNamedColors());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/NamedColors.jpg";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(138, groupedColors.Count);
        //Assert.AreEqual(167062, groupedColors[Color.Red.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(168713, groupedColors[Color.Blue.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(1576, groupedColors[Color.Yellow.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(182167, groupedColors[Color.Orange.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(9431, groupedColors[Color.Purple.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(186354, groupedColors[Color.Green.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(92385, groupedColors[Color.Black.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(2293112, groupedColors[Color.White.ToPixel<Rgb24>()].Count);
    }

    [TestMethod]
    public void ColorfulPhotoImageTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.GetAllNamedColors());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/ColorfulPhoto.jpg";

        //Act
        Dictionary<Rgb24, List<Rgb24>> groupedColors = imageProcessing.ProcessImageIntoColorGroups(imageDir);

        //Assert
        Assert.AreEqual(107, groupedColors.Count);
        //Assert.AreEqual(167062, groupedColors[Color.Red.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(168713, groupedColors[Color.Blue.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(1576, groupedColors[Color.Yellow.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(182167, groupedColors[Color.Orange.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(9431, groupedColors[Color.Purple.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(186354, groupedColors[Color.Green.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(92385, groupedColors[Color.Black.ToPixel<Rgb24>()].Count);
        //Assert.AreEqual(2293112, groupedColors[Color.White.ToPixel<Rgb24>()].Count);
    }
}