using PuzzleSolver.Map;
using System.Diagnostics.CodeAnalysis;

namespace PuzzleSolver.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class MapGenerationTests
    {

        [TestMethod]
        public void RandomMapTest()
        {
            //Arrange
            int xMax = 5;
            int yMax = 5;
            string[,] map = MapCore.InitializeMap(xMax, yMax);

            //Act
            map = MapGeneration.GenerateMap();
            MapGeneration.DebugPrintOutMap(map);
            
            //Assert
            Assert.AreEqual(25, map.Length);
        }
    }
}
