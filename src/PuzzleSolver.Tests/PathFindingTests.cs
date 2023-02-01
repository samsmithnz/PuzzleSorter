using PuzzleSolver.Map;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace PuzzleSolver.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    [TestCategory("L0")]
    public class PathFindingTests
    {

        [TestMethod]
        public void PathFromWestToEastAroundPileTest()
        {
            //Arrange
            //  . . . . . 
            //  . * * * . 
            //  . S ■ * F 
            //  . . . . . 
            //  . . . . . 
            string[,] map = MapGeneration.GenerateMap();
            //map[2, 0, 2] = "P";
            Vector2 startLocation = new(1, 2);
            Vector2 endLocation = new(4, 2);
            string expectedMapString = @"
. . . . . 
. . . . . 
. . P . . 
. . . . . 
. . . . . 
";

            //Act
            PathFindingResult PathFindingResult = PathFinding.FindPath(map, startLocation, endLocation);
            string mapString = MapCore.GetMapString(map);

            //Assert
            Assert.IsNotNull(PathFindingResult);
            Assert.IsNotNull(PathFindingResult.Path);
            Assert.IsTrue(PathFindingResult.Path.Any());
            Assert.AreEqual(5, PathFindingResult.Path.Count);
            Assert.AreEqual("<1, 3>", PathFindingResult.Path[0].ToString());
            Assert.AreEqual("<2, 3>", PathFindingResult.Path[1].ToString());
            Assert.AreEqual("<3, 3>", PathFindingResult.Path[2].ToString());
            Assert.AreEqual("<4, 3>", PathFindingResult.Path[3].ToString());
            Assert.AreEqual("<4, 2>", PathFindingResult.Path[4].ToString());
            Assert.AreEqual(expectedMapString, mapString);
        }

        [TestMethod]
        public void PathFromNorthToSouthToPileTest()
        {
            //Arrange
            //  . . . S . 
            //  . . . * . 
            //  . . ■ * . 
            //  . . F * . 
            //  . . . . . 
            string[,] map = MapGeneration.GenerateMap();
            //map[2, 0, 2] = "P";
            Vector2 startLocation = new(3, 4);
            Vector2 endLocation = new(2, 1);
            string expectedMapString = @"
. . . . . 
. . . . . 
. . P . . 
. . . . . 
. . . . . 
";

            //Act
            PathFindingResult PathFindingResult = PathFinding.FindPath(map, startLocation, endLocation);
            string mapString = MapCore.GetMapString(map);

            //Assert
            Assert.IsNotNull(PathFindingResult);
            Assert.IsNotNull(PathFindingResult.Path);
            Assert.IsTrue(PathFindingResult.Path.Any());
            Assert.AreEqual(4, PathFindingResult.Path.Count);
            Assert.AreEqual("<3, 3>", PathFindingResult.Path[0].ToString());
            Assert.AreEqual("<3, 2>", PathFindingResult.Path[1].ToString());
            Assert.AreEqual("<3, 1>", PathFindingResult.Path[2].ToString());
            Assert.AreEqual("<2, 1>", PathFindingResult.Path[3].ToString());
            Assert.AreEqual(expectedMapString, mapString);
        }


    }
}
