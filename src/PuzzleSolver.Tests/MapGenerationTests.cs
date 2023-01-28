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
            int zMax = 5;
            string[,] map = MapCore.InitializeMap(xMax, zMax);

            //Act
            map = MapGeneration.GenerateMap(map);
            MapGeneration.DebugPrintOutMap(map);
            
            //Assert
            Assert.AreEqual(25, map.Length);
        }
    }
}
