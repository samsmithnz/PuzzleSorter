using PuzzleSolver.Images;
using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics.CodeAnalysis;

namespace PuzzleSolver.Tests;

[ExcludeFromCodeCoverage]
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

    [TestMethod]
    public void Verify32ColorPaletteTest()
    {
        //Arrange
        List<Rgb24> colors = ColorPalettes.Get32ColorPalette();

        //Act

        //Assert
        Assert.AreEqual(33, colors.Count); //Actually 33 as we have black AND white
    }

    [TestMethod]
    public void Verify141ColorPaletteTest()
    {
        //Arrange
        List<Rgb24> colors = ColorPalettes.Get141ColorPalette();

        //Act

        //Assert
        Assert.AreEqual(141, colors.Count);
        foreach (Rgb24 color in colors)
        {
            Assert.IsFalse(string.IsNullOrEmpty(ColorPalettes.ToName(color)));
        }
    }

    [TestMethod]
    public void VerifyColorWithNoNameTest()
    {
        //Arrange
        List<Rgb24> colors = new() { new Rgb24(1,1,1)};

        //Act

        //Assert
        Assert.AreEqual(1, colors.Count);
        foreach (Rgb24 color in colors)
        {
            Assert.IsTrue(string.IsNullOrEmpty(ColorPalettes.ToName(color)));
        }
    }

}