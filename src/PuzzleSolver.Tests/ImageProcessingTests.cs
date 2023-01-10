using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

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
        string expected = @"Red: 50.00%
Blue: 25.00%
Yellow: 25.00%
";
        Assert.AreEqual(expected, ImageProcessing.BuildNamedColorsAndPercentsString(groupedColors));
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
        string expected = @"Red: 33.33%
Blue: 33.33%
Yellow: 33.33%
";
        Assert.AreEqual(expected, ImageProcessing.BuildNamedColorsAndPercentsString(groupedColors));
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
            else if (i == 1)
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
        string expected = @"Blue: 22.17%
White: 44.46%
Orange: 11.21%
Red: 22.17%
";
        Assert.AreEqual(expected, ImageProcessing.BuildNamedColorsAndPercentsString(groupedColors));
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
        string expected = @"White: 73.95%
Purple: 0.30%
Black: 2.98%
Red: 5.39%
Green: 6.01%
Blue: 5.44%
Orange: 5.87%
Yellow: 0.05%
";
        Assert.AreEqual(expected, ImageProcessing.BuildNamedColorsAndPercentsString(groupedColors));
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
        string expected = @"White: 7.65%
Snow: 4.37%
MintCream: 2.74%
LavenderBlush: 1.06%
GhostWhite: 1.19%
LightCyan: 0.85%
Azure: 1.55%
LightYellow: 0.67%
Honeydew: 0.73%
FloralWhite: 0.96%
Ivory: 1.86%
PaleTurquoise: 0.65%
SeaShell: 0.32%
OldLace: 0.73%
AliceBlue: 0.64%
WhiteSmoke: 0.68%
Linen: 0.97%
Beige: 0.77%
Turquoise: 0.53%
MediumTurquoise: 0.50%
SkyBlue: 0.56%
Gainsboro: 0.80%
PowderBlue: 0.56%
AntiqueWhite: 0.68%
Aqua: 0.97%
Aquamarine: 0.46%
Bisque: 0.83%
BlanchedAlmond: 0.43%
Lavender: 1.04%
PapayaWhip: 0.45%
Cornsilk: 0.56%
Wheat: 0.61%
Moccasin: 0.36%
DarkTurquoise: 0.48%
PeachPuff: 0.60%
MistyRose: 0.52%
LightGoldenrodYellow: 0.38%
Silver: 0.80%
LightSlateGray: 0.67%
DarkGray: 0.93%
LightGray: 0.67%
Gray: 0.83%
RosyBrown: 0.91%
Tan: 0.79%
LightSeaGreen: 0.49%
MediumAquamarine: 0.64%
MediumSeaGreen: 0.51%
DarkSeaGreen: 0.54%
DarkSlateGray: 1.14%
Black: 2.15%
DimGray: 0.91%
DarkOliveGreen: 0.81%
Teal: 0.65%
LightBlue: 0.51%
DarkGreen: 0.73%
SeaGreen: 0.67%
SlateGray: 0.71%
LemonChiffon: 0.57%
DarkCyan: 0.44%
CadetBlue: 0.67%
MidnightBlue: 0.83%
SteelBlue: 0.57%
LightSteelBlue: 0.63%
MediumBlue: 0.43%
Blue: 0.53%
SlateBlue: 0.59%
BlueViolet: 0.50%
Brown: 0.69%
Sienna: 0.69%
DarkOrchid: 0.58%
DarkSlateBlue: 0.70%
Firebrick: 0.45%
BurlyWood: 0.49%
DarkKhaki: 0.64%
Khaki: 0.59%
SaddleBrown: 0.62%
MediumSlateBlue: 0.80%
RoyalBlue: 0.46%
Orchid: 0.53%
MediumPurple: 0.59%
MediumOrchid: 0.50%
PaleVioletRed: 0.51%
IndianRed: 0.69%
LightPink: 0.49%
Peru: 0.70%
Violet: 0.55%
Pink: 0.58%
LightCoral: 0.56%
Plum: 0.57%
DarkSalmon: 0.88%
CornflowerBlue: 0.43%
LightSalmon: 0.42%
Maroon: 0.76%
DarkBlue: 0.58%
NavajoWhite: 0.29%
Thistle: 0.55%
Navy: 0.48%
LightSkyBlue: 0.38%
PaleGoldenrod: 0.65%
YellowGreen): 0.53%
LightGreen: 0.53%
Chartreuse: 0.44%
LawnGreen: 0.46%
Chocolate: 0.47%
Salmon: 0.45%
Coral: 0.48%
SandyBrown: 0.50%
Crimson: 0.46%
Tomato: 0.50%
DarkOrange: 0.43%
OliveDrab: 0.58%
LimeGreen: 0.52%
ForestGreen: 0.52%
GreenYellow: 0.50%
Green: 0.52%
HotPink: 0.52%
DarkRed: 0.44%
DarkGoldenrod: 0.48%
Purple: 0.58%
DarkMagenta: 0.47%
Goldenrod: 0.51%
Indigo: 0.59%
PaleGreen: 0.53%
MediumVioletRed: 0.94%
Olive: 0.49%
Orange: 0.45%
Gold: 0.53%
DarkViolet: 0.49%
DeepPink: 0.50%
DeepSkyBlue: 0.45%
DodgerBlue: 0.49%
Fuchsia: 0.97%
Yellow: 0.48%
Lime: 0.52%
MediumSpringGreen: 0.40%
SpringGreen: 0.43%
OrangeRed: 0.43%
Red: 0.48%
";
        Assert.AreEqual(expected, ImageProcessing.BuildNamedColorsAndPercentsString(groupedColors));
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
        string expected = @"LightSkyBlue: 14.32%
LightBlue: 4.99%
SkyBlue: 0.13%
LightSteelBlue: 0.28%
DarkGray: 3.71%
LightSlateGray: 1.40%
Gray: 5.32%
DarkSeaGreen: 0.04%
DarkOliveGreen: 3.34%
Olive: 0.64%
OliveDrab: 0.08%
SaddleBrown: 5.38%
DimGray: 6.94%
CornflowerBlue: 0.11%
MediumPurple: 0.03%
SlateGray: 0.83%
SteelBlue: 0.34%
DarkSlateGray: 7.58%
Black: 6.21%
CadetBlue: 0.25%
RosyBrown: 5.41%
DarkGoldenrod: 1.54%
Sienna: 4.37%
DarkSlateBlue: 0.60%
DarkKhaki: 0.19%
Peru: 1.64%
MidnightBlue: 1.28%
Silver: 0.55%
Thistle: 0.08%
PowderBlue: 0.00%
Lavender: 0.00%
Gainsboro: 0.05%
LavenderBlush: 0.01%
MistyRose: 0.17%
IndianRed: 1.59%
DarkSalmon: 0.50%
DarkGreen: 0.14%
PeachPuff: 0.18%
Tan: 0.41%
Maroon: 3.49%
Bisque: 0.12%
SandyBrown: 0.84%
AntiqueWhite: 0.07%
Chocolate: 3.20%
BurlyWood: 0.54%
Khaki: 0.26%
LightGray: 0.04%
Cornsilk: 0.00%
BlanchedAlmond: 0.01%
LightPink: 0.07%
RoyalBlue: 0.07%
Beige: 0.00%
Wheat: 0.13%
Goldenrod: 0.35%
Plum: 0.00%
Brown: 0.45%
LightCoral: 0.02%
DarkCyan: 0.33%
Teal: 0.97%
PaleVioletRed: 0.36%
SeaGreen: 0.19%
LightSeaGreen: 0.03%
Firebrick: 1.67%
DarkRed: 1.14%
Coral: 0.21%
DodgerBlue: 0.03%
MediumTurquoise: 0.00%
Purple: 0.06%
DarkOrange: 1.46%
MediumSeaGreen: 0.06%
DarkTurquoise: 0.00%
Pink: 0.07%
LightSalmon: 0.20%
SlateBlue: 0.01%
YellowGreen): 0.02%
Tomato: 0.21%
OrangeRed: 0.44%
Red: 0.28%
Crimson: 0.00%
Orange: 0.55%
DarkMagenta: 0.02%
DarkBlue: 0.00%
Salmon: 0.01%
MediumSlateBlue: 0.00%
MediumOrchid: 0.20%
MediumVioletRed: 0.09%
DarkOrchid: 0.19%
Indigo: 0.01%
Gold: 0.12%
ForestGreen: 0.02%
NavajoWhite: 0.61%
Linen: 0.00%
SeaShell: 0.00%
LightGreen: 0.00%
PaleGoldenrod: 0.04%
Green: 0.00%
PapayaWhip: 0.00%
MediumAquamarine: 0.02%
Moccasin: 0.05%
GhostWhite: 0.00%
WhiteSmoke: 0.00%
Snow: 0.00%
White: 0.00%
Navy: 0.00%
Yellow: 0.00%
OldLace: 0.00%
AliceBlue: 0.00%
";
        Assert.AreEqual(expected, ImageProcessing.BuildNamedColorsAndPercentsString(groupedColors));
    }
}