namespace PuzzleSolver.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        //Arrange
        Class1 class1 = new();
        
        //Act
        int count = class1.ProcessImage(@"C:\Users\samsm\source\repos\PuzzleSolver\src\PuzzleSolver\baseImage.png");

        //Assert
        Assert.AreEqual(4, count);
    }
}