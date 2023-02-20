using PuzzleSolver.Map;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

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
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
         
            //Act
            MapGeneration.DebugPrintOutMap(map);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);

            //Assert
            Assert.AreEqual(25, map.Length);
            Assert.AreEqual("P", map[2, 2]);
            Assert.AreEqual(new Vector2(2, 2), centerPointLocation);
        }

        [TestMethod]
        public void GenerateBigMapTest()
        {
            //Arrange
            int width = 7;
            int height = 7;
            string[,] map = MapGeneration.GenerateMap(width, height);
          
            //Act
            MapGeneration.DebugPrintOutMap(map);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);

            //Assert
            Assert.AreEqual(49, map.Length);
            Assert.AreEqual("P", map[3, 3]);
            Assert.AreEqual(new Vector2(3, 3), centerPointLocation);
        }

        [TestMethod]
        public void GenerateBiggerMapTest()
        {
            //Arrange
            int width = 9;
            int height = 9;
            string[,] map = MapGeneration.GenerateMap(width, height);
          
            //Act
            MapGeneration.DebugPrintOutMap(map);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);

            //Assert
            Assert.AreEqual(81, map.Length);
            Assert.AreEqual("P", map[4, 4]);
            Assert.AreEqual(new Vector2(4, 4), centerPointLocation);
        }
    }
}
