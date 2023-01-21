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
        ImageProcessing imageProcessing = new(ColorPalettes.Get3ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/BaseImage.png";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir, null, false);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(3, imageStats?.ColorGroups?.Count);
        Assert.AreEqual(2, imageStats?.ColorGroups?[Color.Red.ToPixel<Rgb24>()].Count);
        string expected = @"Red: 50.00%
Blue: 25.00%
Yellow: 25.00%
";
        Assert.AreEqual(expected, imageStats.NamesToString);
    }

    [TestMethod]
    public void FourPixelImageWithPrimaryAndSecondaryPaletteTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.Get8ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/BaseImage.png";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(3, imageStats?.ColorGroups?.Count);
        Assert.AreEqual(2, imageStats?.ColorGroups?[Color.Red.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(1, imageStats?.ColorGroups?[Color.Green.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(1, imageStats?.ColorGroups?[Color.Blue.ToPixel<Rgb24>()].Count);
    }

    [TestMethod]
    public void FourPixelImageWithAllNamedColorsPaletteTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.Get140ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/BaseImage.png";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(3, imageStats?.ColorGroups?.Count);
        Assert.AreEqual(2, imageStats?.ColorGroups?[Color.Red.ToPixel<Rgb24>()].Count);
    }

    [TestMethod]
    public void PrimaryAndSecondaryColorsImageWithOnlyPrimaryPaletteTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.Get3ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/PrimaryAndSecondaryColors.png";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir, null, false);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(3, imageStats?.ColorGroups?.Count);
        Assert.AreEqual(25 * 25 * 2, imageStats?.ColorGroups?[Color.Red.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25 * 2, imageStats?.ColorGroups?[Color.Blue.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25 * 2, imageStats?.ColorGroups?[Color.Yellow.ToPixel<Rgb24>()].Count);
        string expected = @"Blue: 33.33%
Red: 33.33%
Yellow: 33.33%
";
        Assert.AreEqual(expected, imageStats.NamesToString);
    }

    [TestMethod]
    public void PrimaryAndSecondaryColorsImageWithPrimaryAndSecondaryPaletteTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.Get8ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/PrimaryAndSecondaryColors.png";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(6, imageStats?.ColorGroups?.Count);
        Assert.AreEqual(25 * 25, imageStats?.ColorGroups?[Color.Red.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, imageStats?.ColorGroups?[Color.Blue.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, imageStats?.ColorGroups?[Color.Yellow.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, imageStats?.ColorGroups?[Color.Purple.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, imageStats?.ColorGroups?[Color.Orange.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(25 * 25, imageStats?.ColorGroups?[Color.Green.ToPixel<Rgb24>()].Count);
    }

    [TestMethod]
    public void PrimaryAndSecondaryColorsImageWithNamedColorsPaletteTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.Get140ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/PrimaryAndSecondaryColors.png";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(6, imageStats?.ColorGroups?.Count);
        int i = 0;
        foreach (KeyValuePair<Rgb24, List<Rgb24>> entry in imageStats?.ColorGroups?)
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
        ImageProcessing imageProcessing = new(ColorPalettes.Get8ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/RedToBlueBlend.jpg";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir, null, false);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(4, imageStats?.ColorGroups?.Count);
        Assert.AreEqual(59160, imageStats?.ColorGroups?[Color.Blue.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(118660, imageStats?.ColorGroups?[Color.White.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(29920, imageStats?.ColorGroups?[Color.Orange.ToPixel<Rgb24>()].Count); //one of the bars is closer to orange than white or red
        Assert.AreEqual(59160, imageStats?.ColorGroups?[Color.Red.ToPixel<Rgb24>()].Count);
        string expected = @"White: 44.46%
Blue: 22.17%
Red: 22.17%
Orange: 11.21%
";
        Assert.AreEqual(expected, imageStats.NamesToString);
    }

    [TestMethod]
    public void PuzzlePiecesImageTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.Get8ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/PuzzlePieces.jpg";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir, null, false);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(8, imageStats?.ColorGroups?.Count);
        Assert.AreEqual(167062, imageStats?.ColorGroups?[Color.Red.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(168713, imageStats?.ColorGroups?[Color.Blue.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(1576, imageStats?.ColorGroups?[Color.Yellow.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(182167, imageStats?.ColorGroups?[Color.Orange.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(9431, imageStats?.ColorGroups?[Color.Purple.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(186354, imageStats?.ColorGroups?[Color.Green.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(92385, imageStats?.ColorGroups?[Color.Black.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(2293112, imageStats?.ColorGroups?[Color.White.ToPixel<Rgb24>()].Count);
        string expected = @"White: 73.95%
Green: 6.01%
Orange: 5.87%
Blue: 5.44%
Red: 5.39%
Black: 2.98%
Purple: 0.30%
Yellow: 0.05%
";
        Assert.AreEqual(expected, imageStats.NamesToString);
    }

    [TestMethod]
    public void NamedColorImageTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.Get140ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/NamedColors.jpg";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir, null, false);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(138, imageStats?.ColorGroups?.Count);
        string expected = @"White: 7.65%
Snow: 4.37%
MintCream: 2.74%
Black: 2.15%
Ivory: 1.86%
Azure: 1.55%
GhostWhite: 1.19%
DarkSlateGray: 1.14%
LavenderBlush: 1.06%
Lavender: 1.04%
Linen: 0.97%
Fuchsia: 0.97%
Aqua: 0.97%
FloralWhite: 0.96%
MediumVioletRed: 0.94%
DarkGray: 0.93%
RosyBrown: 0.91%
DimGray: 0.91%
DarkSalmon: 0.88%
LightCyan: 0.85%
MidnightBlue: 0.83%
Gray: 0.83%
Bisque: 0.83%
DarkOliveGreen: 0.81%
Silver: 0.80%
Gainsboro: 0.80%
MediumSlateBlue: 0.80%
Tan: 0.79%
Beige: 0.77%
Maroon: 0.76%
Honeydew: 0.73%
OldLace: 0.73%
DarkGreen: 0.73%
SlateGray: 0.71%
Peru: 0.70%
DarkSlateBlue: 0.70%
Brown: 0.69%
Sienna: 0.69%
IndianRed: 0.69%
WhiteSmoke: 0.68%
AntiqueWhite: 0.68%
CadetBlue: 0.67%
LightSlateGray: 0.67%
SeaGreen: 0.67%
LightYellow: 0.67%
LightGray: 0.67%
PaleTurquoise: 0.65%
PaleGoldenrod: 0.65%
Teal: 0.65%
DarkKhaki: 0.64%
MediumAquamarine: 0.64%
AliceBlue: 0.64%
LightSteelBlue: 0.63%
SaddleBrown: 0.62%
Wheat: 0.61%
PeachPuff: 0.60%
Indigo: 0.59%
MediumPurple: 0.59%
SlateBlue: 0.59%
Khaki: 0.59%
Pink: 0.58%
OliveDrab: 0.58%
DarkOrchid: 0.58%
Purple: 0.58%
DarkBlue: 0.58%
SteelBlue: 0.57%
Plum: 0.57%
LemonChiffon: 0.57%
SkyBlue: 0.56%
PowderBlue: 0.56%
Cornsilk: 0.56%
LightCoral: 0.56%
Violet: 0.55%
Thistle: 0.55%
DarkSeaGreen: 0.54%
LightGreen: 0.53%
Gold: 0.53%
Turquoise: 0.53%
Orchid: 0.53%
PaleGreen: 0.53%
Blue: 0.53%
YellowGreen: 0.53%
HotPink: 0.52%
MistyRose: 0.52%
Green: 0.52%
Lime: 0.52%
LimeGreen: 0.52%
ForestGreen: 0.52%
LightBlue: 0.51%
Goldenrod: 0.51%
PaleVioletRed: 0.51%
MediumSeaGreen: 0.51%
BlueViolet: 0.50%
MediumTurquoise: 0.50%
SandyBrown: 0.50%
DeepPink: 0.50%
GreenYellow: 0.50%
MediumOrchid: 0.50%
Tomato: 0.50%
LightSeaGreen: 0.49%
DarkViolet: 0.49%
Olive: 0.49%
BurlyWood: 0.49%
DodgerBlue: 0.49%
LightPink: 0.49%
Red: 0.48%
DarkGoldenrod: 0.48%
Yellow: 0.48%
Navy: 0.48%
Coral: 0.48%
DarkTurquoise: 0.48%
DarkMagenta: 0.47%
Chocolate: 0.47%
RoyalBlue: 0.46%
Crimson: 0.46%
LawnGreen: 0.46%
Aquamarine: 0.46%
Orange: 0.45%
Firebrick: 0.45%
Salmon: 0.45%
PapayaWhip: 0.45%
DeepSkyBlue: 0.45%
DarkRed: 0.44%
Chartreuse: 0.44%
DarkCyan: 0.44%
OrangeRed: 0.43%
CornflowerBlue: 0.43%
BlanchedAlmond: 0.43%
MediumBlue: 0.43%
SpringGreen: 0.43%
DarkOrange: 0.43%
LightSalmon: 0.42%
MediumSpringGreen: 0.40%
LightSkyBlue: 0.38%
LightGoldenrodYellow: 0.38%
Moccasin: 0.36%
SeaShell: 0.32%
NavajoWhite: 0.29%
";
        Assert.AreEqual(expected, imageStats.NamesToString);
    }

    [TestMethod]
    public void ColorfulPhotoImageTest()
    {
        //Arrange
        ImageProcessing imageProcessing = new(ColorPalettes.Get140ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/ColorfulPhoto.jpg";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir, null, false);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(107, imageStats?.ColorGroups?.Count);
        string expected = @"LightSkyBlue: 14.32%
DarkSlateGray: 7.58%
DimGray: 6.94%
Black: 6.21%
RosyBrown: 5.41%
SaddleBrown: 5.38%
Gray: 5.32%
LightBlue: 4.99%
Sienna: 4.37%
DarkGray: 3.71%
Maroon: 3.49%
DarkOliveGreen: 3.34%
Chocolate: 3.20%
Firebrick: 1.67%
Peru: 1.64%
IndianRed: 1.59%
DarkGoldenrod: 1.54%
DarkOrange: 1.46%
LightSlateGray: 1.40%
MidnightBlue: 1.28%
DarkRed: 1.14%
Teal: 0.97%
SandyBrown: 0.84%
SlateGray: 0.83%
Olive: 0.64%
NavajoWhite: 0.61%
DarkSlateBlue: 0.60%
Orange: 0.55%
Silver: 0.55%
BurlyWood: 0.54%
DarkSalmon: 0.50%
Brown: 0.45%
OrangeRed: 0.44%
Tan: 0.41%
PaleVioletRed: 0.36%
Goldenrod: 0.35%
SteelBlue: 0.34%
DarkCyan: 0.33%
Red: 0.28%
LightSteelBlue: 0.28%
Khaki: 0.26%
CadetBlue: 0.25%
Tomato: 0.21%
Coral: 0.21%
LightSalmon: 0.20%
MediumOrchid: 0.20%
DarkOrchid: 0.19%
DarkKhaki: 0.19%
SeaGreen: 0.19%
PeachPuff: 0.18%
MistyRose: 0.17%
DarkGreen: 0.14%
Wheat: 0.13%
SkyBlue: 0.13%
Gold: 0.12%
Bisque: 0.12%
CornflowerBlue: 0.11%
MediumVioletRed: 0.09%
Thistle: 0.08%
OliveDrab: 0.08%
LightPink: 0.07%
Pink: 0.07%
AntiqueWhite: 0.07%
RoyalBlue: 0.07%
Purple: 0.06%
MediumSeaGreen: 0.06%
Moccasin: 0.05%
Gainsboro: 0.05%
PaleGoldenrod: 0.04%
DarkSeaGreen: 0.04%
LightGray: 0.04%
DodgerBlue: 0.03%
MediumPurple: 0.03%
LightSeaGreen: 0.03%
DarkMagenta: 0.02%
MediumAquamarine: 0.02%
YellowGreen: 0.02%
ForestGreen: 0.02%
LightCoral: 0.02%
SlateBlue: 0.01%
Indigo: 0.01%
Salmon: 0.01%
BlanchedAlmond: 0.01%
LavenderBlush: 0.01%
Crimson: 0.00%
Lavender: 0.00%
Linen: 0.00%
Plum: 0.00%
MediumTurquoise: 0.00%
DarkTurquoise: 0.00%
GhostWhite: 0.00%
Yellow: 0.00%
Green: 0.00%
MediumSlateBlue: 0.00%
SeaShell: 0.00%
Snow: 0.00%
Cornsilk: 0.00%
Navy: 0.00%
PowderBlue: 0.00%
WhiteSmoke: 0.00%
PapayaWhip: 0.00%
White: 0.00%
AliceBlue: 0.00%
Beige: 0.00%
DarkBlue: 0.00%
LightGreen: 0.00%
OldLace: 0.00%
";
        Assert.AreEqual(expected, imageStats.NamesToString);
    }
}