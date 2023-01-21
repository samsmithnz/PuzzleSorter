using SixLabors.ImageSharp.PixelFormats;

namespace PuzzleSolver.Tests;

[TestClass]
public class ColorPaletteTests
{

    [TestMethod]
    public void Verify3ColorPaletteTest()
    {
        //Arrange
        List<Rgb24> colors = ColorPalettes.Get3ColorPalette();

        //Act

        //Assert
        Assert.AreEqual(3, colors.Count);
        foreach (Rgb24 color in colors)
        {
            Assert.IsFalse(string.IsNullOrEmpty(ColorPalettes.ToName(color)));
        }
    }
    
    [TestMethod]
    public void Verify5ColorPaletteTest()
    {
        //Arrange
        List<Rgb24> colors = ColorPalettes.Get5ColorPalette();

        //Act

        //Assert
        Assert.AreEqual(5, colors.Count);
        foreach (Rgb24 color in colors)
        {
            Assert.IsFalse(string.IsNullOrEmpty(ColorPalettes.ToName(color)));
        }
    }

    [TestMethod]
    public void Verify6ColorPaletteTest()
    {
        //Arrange
        List<Rgb24> colors = ColorPalettes.Get6ColorPalette();

        //Act

        //Assert
        Assert.AreEqual(6, colors.Count);
        foreach (Rgb24 color in colors)
        {
            Assert.IsFalse(string.IsNullOrEmpty(ColorPalettes.ToName(color)));
        }
    }

    [TestMethod]
    public void Verify8ColorPaletteTest()
    {
        //Arrange
        List<Rgb24> colors = ColorPalettes.Get8ColorPalette();

        //Act

        //Assert
        Assert.AreEqual(8, colors.Count);
        foreach (Rgb24 color in colors)
        {
            Assert.IsFalse(string.IsNullOrEmpty(ColorPalettes.ToName(color)));
        }
    }

    [TestMethod]
    public void Verify16ColorPaletteTest()
    {
        //Arrange
        List<Rgb24> colors = ColorPalettes.Get16ColorPalette();

        //Act

        //Assert
        Assert.AreEqual(16, colors.Count);
        foreach (Rgb24 color in colors)
        {
            Assert.IsFalse(string.IsNullOrEmpty(ColorPalettes.ToName(color)));
        }
    }

    //[TestMethod]
    //public void Verify24ColorPaletteTest()
    //{
    //    //Arrange
    //    List<Rgb24> colors = ColorPalettes.Get24ColorPalette();

    //    //Act

    //    //Assert
    //    Assert.AreEqual(24, colors.Count);
    //    foreach (Rgb24 color in colors)
    //    {
    //        Assert.IsFalse(string.IsNullOrEmpty(ColorPalettes.ToName(color)));
    //    }
    //}

}