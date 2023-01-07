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
        int count = imageProcessing.ProcessImage(@"C:\Users\samsm\source\repos\PuzzleSolver\src\PuzzleSolver\baseImage.png");

        //Assert
        Assert.AreEqual(2, count);
    }
}