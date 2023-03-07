using PuzzleSolver.Map;
using PuzzleSolver.Processing;
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
            PathFindingResult PathFindingResult = PathFinding.FindPath(map, startLocation, endLocation, new List<Robot>());
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
            PathFindingResult PathFindingResult = PathFinding.FindPath(map, startLocation, endLocation, new List<Robot>());
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
            Assert.AreEqual("2, 1: Open", PathFindingResult.GetLastTile().ToString());
            Assert.AreEqual(expectedMapString, mapString);
        }

        [TestMethod]
        public void TwoRobotsCrossingPathesTest()
        {
            //Arrange
            //  . . a . . 
            //  . . * . . 
            //  2 # #* # b 
            //  . . * . . 
            //  . . 1 . . 
            string[,] map = MapGeneration.GenerateMap();
            map[2, 2] = "";
            Vector2 endLocation1 = new(2, 4);
            Vector2 endLocation2 = new(4, 2);
            List<Robot> robots = new List<Robot>()
            {
                new Robot(1, new Vector2(0, 0), new Vector2(2,0)),
                new Robot(2, new Vector2(0, 0), new Vector2(0, 2))
            };
            map[(int)robots[0].Location.X, (int)robots[0].Location.Y] = "a";
            map[(int)robots[1].Location.X, (int)robots[1].Location.Y] = "b";
            string expectedMapString = @"
. . . . . 
. . . . . 
b . . . . 
. . . . . 
. . a . . 
";

            //Act
            PathFindingResult PathFindingResult = PathFinding.FindPath(map, robots[0].Location, endLocation1, new List<Robot>());
            PathFindingResult PathFindingResult2 = PathFinding.FindPath(map, robots[1].Location, endLocation2, new List<Robot>());
            string mapString = MapCore.GetMapString(map);

            //Assert
            Assert.IsNotNull(PathFindingResult);
            Assert.IsNotNull(PathFindingResult.Path);
            Assert.IsTrue(PathFindingResult.Path.Any());
            Assert.AreEqual(4, PathFindingResult.Path.Count);
            Assert.AreEqual("<2, 1>", PathFindingResult.Path[0].ToString());
            Assert.AreEqual("<2, 2>", PathFindingResult.Path[1].ToString());
            Assert.AreEqual("<2, 3>", PathFindingResult.Path[2].ToString());
            Assert.AreEqual("<2, 4>", PathFindingResult.Path[3].ToString());
            Assert.IsNotNull(PathFindingResult2);
            Assert.IsNotNull(PathFindingResult2.Path);
            Assert.IsTrue(PathFindingResult2.Path.Any());
            Assert.AreEqual(4, PathFindingResult2.Path.Count);
            Assert.AreEqual("<1, 2>", PathFindingResult2.Path[0].ToString());
            Assert.AreEqual("<2, 2>", PathFindingResult2.Path[1].ToString());
            Assert.AreEqual("<3, 2>", PathFindingResult2.Path[2].ToString());
            Assert.AreEqual("<4, 2>", PathFindingResult2.Path[3].ToString());
            Assert.AreEqual(expectedMapString, mapString);
        }


    }
}
