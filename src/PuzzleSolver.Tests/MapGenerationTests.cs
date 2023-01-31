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
            string[,] map = MapGeneration.GenerateMap();

            //Act
            MapGeneration.DebugPrintOutMap(map);
            
            //Assert
            Assert.AreEqual(25, map.Length);
        }
    }
}
