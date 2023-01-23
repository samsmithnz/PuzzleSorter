using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics.CodeAnalysis;

namespace PuzzleSolver.Tests;

[ExcludeFromCodeCoverage]
[TestClass]
public class ImageProcessingTests
{

    [TestMethod]
    public void FourPixelImageWith3ColorPaletteTest()
    {
        //Arrange
        ImageColorGroups imageProcessing = new(ColorPalettes.Get3ColorPalette());
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
        Assert.AreEqual(expected, imageStats?.NamesToString);
    }

    [TestMethod]
    public void FourPixelImageWith6ColorPaletteTest()
    {
        //Arrange
        ImageColorGroups imageProcessing = new(ColorPalettes.Get6ColorPalette());
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
    public void FourPixelImageWith16ColorPaletteTest()
    {
        //Arrange
        ImageColorGroups imageProcessing = new(ColorPalettes.Get16ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/BaseImage.png";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(3, imageStats?.ColorGroups?.Count);
        Assert.AreEqual(2, imageStats?.ColorGroups?[Color.Red.ToPixel<Rgb24>()].Count);
    }

    [TestMethod]
    public void FourPixelImageWith16ColorPaletteWithPriorityColorTest()
    {
        //Arrange
        SortedList<int, Rgb24> priorityColorPalette = new();
        priorityColorPalette.Add(1, Color.Lime.ToPixel<Rgb24>());

        ImageColorGroups imageProcessing = new(ColorPalettes.Get16ColorPalette(), priorityColorPalette);
        string imageDir = Environment.CurrentDirectory + @"/TestImages/BaseImage.png";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(3, imageStats?.ColorGroups?.Count);
        Assert.AreEqual(2, imageStats?.ColorGroups?[Color.Red.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(1, imageStats?.ColorGroups?[Color.Blue.ToPixel<Rgb24>()].Count);
        Assert.AreEqual(1, imageStats?.ColorGroups?[Color.Lime.ToPixel<Rgb24>()].Count);
        Assert.AreEqual("Lime", imageStats?.TopNamedColor);
    }

    [TestMethod]
    public void PrimaryAndSecondaryColorsImageWith3ColorPaletteTest()
    {
        //Arrange
        ImageColorGroups imageProcessing = new(ColorPalettes.Get3ColorPalette());
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
        Assert.AreEqual(expected, imageStats?.NamesToString);
    }

    [TestMethod]
    public void PrimaryAndSecondaryColorsImageWith6ColorPaletteTest()
    {
        //Arrange
        ImageColorGroups imageProcessing = new(ColorPalettes.Get6ColorPalette());
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
    public void PrimaryAndSecondaryColorsImageWith141ColorPaletteTest()
    {
        //Arrange
        ImageColorGroups imageProcessing = new(ColorPalettes.Get141ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/PrimaryAndSecondaryColors.png";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(3, imageStats?.NamedColorsAndPercentList?.Count);
        Assert.AreEqual("Other", imageStats?.NamedColorsAndPercentList?[2].Name);
        Assert.AreEqual(6, imageStats?.ColorGroups?.Count);
        int i = 0;
        if (imageStats?.ColorGroups != null)
        {
            foreach (KeyValuePair<Rgb24, List<Rgb24>> entry in imageStats.ColorGroups)
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

    }

    [TestMethod]
    public void RedToBlueBlendImageWith8ColorImageTest()
    {
        //Arrange
        ImageColorGroups imageProcessing = new(ColorPalettes.Get8ColorPalette());
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
        Assert.AreEqual(expected, imageStats?.NamesToString);
    }

    [TestMethod]
    public void PuzzlePiecesImageWith8ColorPaletteTest()
    {
        //Arrange
        ImageColorGroups imageProcessing = new(ColorPalettes.Get8ColorPalette());
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
        Assert.AreEqual(expected, imageStats?.NamesToString);
    }

    [TestMethod]
    public void NamedColorImageWith16ColorPaletteTest()
    {
        //Arrange
        ImageColorGroups imageProcessing = new(ColorPalettes.Get16ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/NamedColors.jpg";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir, null, false);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(16, imageStats?.ColorGroups?.Count);
        string expected = @"White: 33.53%
Silver: 19.93%
Gray: 12.28%
Olive: 4.66%
Purple: 4.51%
Aqua: 3.80%
Teal: 3.46%
Yellow: 3.07%
Maroon: 2.49%
Black: 2.48%
Navy: 2.04%
Red: 1.90%
Green: 1.78%
Lime: 1.58%
Fuchsia: 1.55%
Blue: 0.95%
";
        Assert.AreEqual(expected, imageStats?.NamesToString);
    }

    [TestMethod]
    public void ColorfulPhotoImageWith16ColorPaletteTest()
    {
        //Arrange
        ImageColorGroups imageProcessing = new(ColorPalettes.Get16ColorPalette());
        string imageDir = Environment.CurrentDirectory + @"/TestImages/ColorfulPhoto.jpg";

        //Act
        ImageStats? imageStats = imageProcessing.ProcessStatsForImage(imageDir, null, false);

        //Assert
        Assert.IsNotNull(imageStats);
        Assert.AreEqual(14, imageStats?.ColorGroups?.Count);
        string expected = @"Gray: 28.43%
Silver: 27.45%
Olive: 12.90%
Maroon: 11.75%
Black: 8.73%
Teal: 3.12%
Red: 2.20%
Navy: 1.86%
Yellow: 1.74%
Purple: 1.26%
White: 0.32%
Green: 0.21%
Aqua: 0.02%
Blue: 0.00%
";
        Assert.AreEqual(expected, imageStats?.NamesToString);
        Assert.AreEqual(new Rgb24(128, 128, 128), imageStats?.TopColorGroupColor);
        Assert.AreEqual("Gray", imageStats?.TopNamedColor);
    }

    [TestMethod]
    public void SplitColorfulPhotoImageTest()
    {
        //Arrange
        string imageDir = Environment.CurrentDirectory + @"/TestImages/ColorfulPhoto.jpg";

        //Act
        Image<Rgb24> image = Image.Load<Rgb24>(imageDir);
        List<Image<Rgb24>> images = ImageCropping.SplitImageIntoMultiplePieces(image, 390, 390);

        //Assert
        Assert.IsNotNull(images);
        Assert.AreEqual(6, images.Count);
    }
}