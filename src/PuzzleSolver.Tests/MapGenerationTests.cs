using PuzzleSolver.Map;
using System.Diagnostics.CodeAnalysis;

namespace PuzzleSolver.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class MapGenerationTests
    {

        [TestMethod]
        public void GenerateMapTest()
        {
            //Arrange
            string[,] map = MapGeneration.GenerateMap();

            //Act
            MapGeneration.DebugPrintOutMap(map);
            
            //Assert
            Assert.AreEqual(25, map.Length);
            Assert.AreEqual("P", map[2, 2]);
        }

        [TestMethod]
        public void GenerateBiggerMapTest()
        {
            //Arrange
            string[,] map = MapGeneration.GenerateMap(9,9);

            //Act
            MapGeneration.DebugPrintOutMap(map);

            //Assert
            Assert.AreEqual(81, map.Length);
            Assert.AreEqual("P", map[4, 4]);
        }
    }
}
