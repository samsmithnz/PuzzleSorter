using PuzzleSolver.Map;
using System.Numerics;
using System.Reflection;

namespace PuzzleSolver.Tests
{
    [TestClass]
    [TestCategory("L0")]
    public class PathFindingTests
    {

        [TestMethod]
        public void Test_WithoutWalls_CanFindPath()
        {
            //Arrange
            //  . . . . . 
            //  . * * * . 
            //  . S ■ * F 
            //  . . . . . 
            //  . . . . . 
            string[,,] map = MapGeneration.GenerateMap();
            //map[2, 0, 2] = "P";
            Vector3 startLocation = new(1, 0, 2);
            Vector3 endLocation = new(4, 0, 2);
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
            Assert.AreEqual("<1, 0, 3>", PathFindingResult.Path[0].ToString());
            Assert.AreEqual("<2, 0, 3>", PathFindingResult.Path[1].ToString());
            Assert.AreEqual("<3, 0, 3>", PathFindingResult.Path[2].ToString());
            Assert.AreEqual("<4, 0, 3>", PathFindingResult.Path[3].ToString());
            Assert.AreEqual("<4, 0, 2>", PathFindingResult.Path[4].ToString());
            Assert.AreEqual(expectedMapString, mapString);
        }

        //[TestMethod]
        //public void Test_WithOpenWall_CanFindPathAroundWall()
        //{
        //    //Arrange
        //    //  . . . ■ . . .
        //    //  . . . ■ . . .
        //    //  . S . ■ . F .
        //    //  . . * ■ ■ * .
        //    //  . . . * * . .

        //    // Path: 1,2 ; 2,1 ; 3,0 ; 4,0 ; 5,1 ; 5,2
        //    Vector3 startLocation = new(1, 2);
        //    Vector3 endLocation = new(5, 2);
        //    string[,,] map = MapCore.InitializeMap(7, 1, 5);
        //    map[3, 4] = CoverType.FullCover;
        //    map[3, 3] = CoverType.FullCover;
        //    map[3, 2] = CoverType.FullCover;
        //    map[3, 1] = CoverType.FullCover;
        //    map[4, 1] = CoverType.FullCover;

        //    //Act
        //    PathFindingResult PathFindingResult = PathFinding.FindPath(map, startLocation, endLocation);

        //    //Assert
        //    Assert.IsNotNull(PathFindingResult);
        //    Assert.IsNotNull(PathFindingResult.Path);
        //    Assert.IsTrue(PathFindingResult.Path.Any());
        //    Assert.IsTrue(PathFindingResult.GetLastTile() != null);
        //    Assert.AreEqual(7, PathFindingResult.GetLastTile().TraversalCost);
        //    Assert.AreEqual(5, PathFindingResult.Path.Count);
        //}

        //[TestMethod]
        //public void Test_WithClosedWall_CannotFindPath()
        //{
        //    //Arrange
        //    //  . . . ■ . . .
        //    //  . . . ■ . . .
        //    //  . S . ■ . F .
        //    //  . . . ■ . . .
        //    //  . . . ■ . . .

        //    // No path
        //    Vector3 startLocation = new(1, 2);
        //    Vector3 endLocation = new(5, 2);
        //    string[,,] map = MapCore.InitializeMap(7, 1, 5);
        //    map[3, 4] = CoverType.FullCover;
        //    map[3, 3] = CoverType.FullCover;
        //    map[3, 2] = CoverType.FullCover;
        //    map[3, 1] = CoverType.FullCover;
        //    map[3, 0] = CoverType.FullCover;

        //    //Act
        //    PathFindingResult PathFindingResult = PathFinding.FindPath(map, startLocation, endLocation);

        //    //Assert
        //    Assert.IsNotNull(PathFindingResult);
        //    Assert.IsNotNull(PathFindingResult.Path);
        //    Assert.IsFalse(PathFindingResult.Path.Any());
        //    Assert.IsFalse(PathFindingResult.Tiles.Any());
        //}


        //[TestMethod]
        //public void Test_WithMazeWall()
        //{
        //    //Arrange
        //    //  S ■ ■ . ■ ■ F
        //    //  * ■ . ■ . ■ .
        //    //  * ■ . ■ . ■ .
        //    //  * ■ . ■ . ■ .
        //    //  ■ . ■ ■ ■ . ■

        //    // long path
        //    Vector3 startLocation = new(0, 4);
        //    Vector3 endLocation = new(6, 4);
        //    string[,,] map = MapCore.InitializeMap(7, 1, 5);
        //    map[0, 0] = CoverType.FullCover;
        //    map[1, 4] = CoverType.FullCover;
        //    map[1, 3] = CoverType.FullCover;
        //    map[1, 2] = CoverType.FullCover;
        //    map[1, 1] = CoverType.FullCover;
        //    map[2, 4] = CoverType.FullCover;
        //    map[2, 0] = CoverType.FullCover;
        //    map[3, 3] = CoverType.FullCover;
        //    map[3, 2] = CoverType.FullCover;
        //    map[3, 1] = CoverType.FullCover;
        //    map[3, 0] = CoverType.FullCover;
        //    map[4, 4] = CoverType.FullCover;
        //    map[4, 0] = CoverType.FullCover;
        //    map[5, 4] = CoverType.FullCover;
        //    map[5, 3] = CoverType.FullCover;
        //    map[5, 2] = CoverType.FullCover;
        //    map[5, 1] = CoverType.FullCover;
        //    map[6, 0] = CoverType.FullCover;

        //    //Act
        //    PathFindingResult PathFindingResult = PathFinding.FindPath(map, startLocation, endLocation);

        //    //Assert
        //    Assert.IsNotNull(PathFindingResult);
        //    Assert.IsNotNull(PathFindingResult.Path);
        //    Assert.IsTrue(PathFindingResult.Path.Any());
        //    Assert.IsTrue(PathFindingResult.GetLastTile() != null);
        //    Assert.AreEqual(19, PathFindingResult.GetLastTile().TraversalCost);
        //    Assert.AreEqual(16, PathFindingResult.Path.Count);
        //}


        //[TestMethod]
        //public void Test_GiantRandomMap_WithInefficentPath()
        //{
        //    //Arrange
        //    Vector3 startLocation = new(0, 0);
        //    Vector3 endLocation = new(69, 39);
        //    string[,,] map = CreateGiantMap();

        //    //Act
        //    PathFindingResult PathFindingResult = PathFinding.FindPath(map, startLocation, endLocation);

        //    //Assert
        //    Assert.IsNotNull(PathFindingResult);
        //    Assert.IsNotNull(PathFindingResult.Path);
        //    Assert.IsTrue(PathFindingResult.Path.Any());
        //    Assert.AreEqual(97, PathFindingResult.Path.Count);
        //    CreateDebugPictureOfMapAndRoute(map, 70, 1, 40, PathFindingResult.Path);
        //}

        //[TestMethod]
        //public void Test_Contained_RangeOf1_NoPath()
        //{
        //    // 4 . . . . F 
        //    // 3 . ■ ■ ■ . 
        //    // 2 . ■ S ■ . 
        //    // 1 . ■ ■ ■ . 
        //    // 0 . . . . . 
        //    //   0 1 2 3 4 

        //    //Arrange
        //    int height = 5;
        //    int width = 5;
        //    string[,,] map = MapCore.InitializeMap(width, 1, height);
        //    map[1, 1] = CoverType.FullCover;
        //    map[1, 2] = CoverType.FullCover;
        //    map[1, 3] = CoverType.FullCover;
        //    map[2, 1] = CoverType.FullCover;
        //    map[2, 3] = CoverType.FullCover;
        //    map[3, 1] = CoverType.FullCover;
        //    map[3, 2] = CoverType.FullCover;
        //    map[3, 3] = CoverType.FullCover;
        //    Vector3 startLocation = new(2, 2);
        //    Vector3 endLocation = new(2, 4);

        //    //Act
        //    PathFindingResult PathFindingResult = PathFinding.FindPath(map, startLocation, endLocation);

        //    //Assert
        //    Assert.IsNotNull(PathFindingResult);
        //    Assert.IsNotNull(PathFindingResult.Path);
        //    Assert.IsTrue(PathFindingResult.Path.Count == 0);
        //    Assert.IsTrue(PathFindingResult.Tiles.Count == 0);
        //    Assert.IsTrue(PathFindingResult.GetLastTile() == null);
        //}

        //[TestMethod]
        //public void Test_Contained_RangeOf1_StartIsSameAsFinish()
        //{
        //    // 4 . . . . . 
        //    // 3 . ■ ■ ■ . 
        //    // 2 . ■ S ■ . 
        //    // 1 . ■ ■ ■ . 
        //    // 0 . . . . . 
        //    //   0 1 2 3 4 

        //    //Arrange
        //    Vector3 startLocation = new(2, 2);
        //    Vector3 endLocation = new(2, 2);
        //    int height = 5;
        //    int width = 5;
        //    string[,,] map = MapCore.InitializeMap(width, 1, height);
        //    map[1, 1] = CoverType.FullCover;
        //    map[1, 2] = CoverType.FullCover;
        //    map[1, 3] = CoverType.FullCover;
        //    map[2, 1] = CoverType.FullCover;
        //    map[2, 3] = CoverType.FullCover;
        //    map[3, 1] = CoverType.FullCover;
        //    map[3, 2] = CoverType.FullCover;
        //    map[3, 3] = CoverType.FullCover;

        //    //Act
        //    PathFindingResult PathFindingResult = PathFinding.FindPath(map, startLocation, endLocation);

        //    //Assert
        //    Assert.IsNotNull(PathFindingResult);
        //    Assert.IsNotNull(PathFindingResult.Path);
        //    Assert.IsTrue(PathFindingResult.Path.Count == 0);
        //    Assert.IsTrue(PathFindingResult.Tiles.Count == 0);
        //    Assert.IsTrue(PathFindingResult.GetLastTile() == null);
        //}

        //#region "private helper functions"

        //private static void CreateDebugPictureOfMapAndRoute(string[,,] map, int xMax, int yMax, int zMax, List<Vector3> path)
        //{
        //    string[,,] mapDebug = new string[xMax, yMax, zMax];
        //    int y = 0;
        //    for (int z = 0; z < zMax; z++)
        //    {
        //        for (int x = 0; x < xMax; x++)
        //        {
        //            if (map[x, y, z] == "")
        //            {
        //                mapDebug[x, y, z] = " .";
        //            }
        //            else if (map[x, y, z] != "")
        //            {
        //                mapDebug[x, y, z] = " ■";
        //            }
        //        }
        //    }

        //    int i = 0;
        //    foreach (Vector3 item in path)
        //    {
        //        if (i == 0)
        //        {
        //            mapDebug[0, 0] = " S";
        //        }
        //        if (i == path.Count - 1)
        //        {
        //            mapDebug[(int)item.X, (int)item.Y, (int)item.Z] = " F";
        //        }
        //        else
        //        {
        //            mapDebug[(int)item.X, (int)item.Y, (int)item.Z] = " *";
        //        }
        //        i++;
        //    }

        //    y = 0;
        //    for (int z = zMax - 1; z >= 0; z--)
        //    {
        //        for (int x = 0; x < xMax; x++)
        //        {
        //            System.Diagnostics.Debug.Write(mapDebug[x, y, z]);
        //        }
        //        System.Diagnostics.Debug.WriteLine("");
        //    }

        //}



        //[TestMethod]
        //public void TileTest()
        //{
        //    //Arrange
        //    MapTile tile = new(3, 3, "", new(6, 6));

        //    //Act
        //    string result = tile.ToString();

        //    //Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("3, 0: Untested", result);
        //}

        //[TestMethod]
        //public void Test_WithoutWalls_CanFindPathNextDoor()
        //{
        //    //Arrange
        //    Vector3 startLocation = new(25, 30);
        //    Vector3 endLocation = new(25, 29);
        //    string[,,] map = MapCore.InitializeMap(50, 1, 50);

        //    //Act
        //    PathFindingResult PathFindingResult = PathFinding.FindPath(map, startLocation, endLocation);

        //    //Assert
        //    Assert.IsNotNull(PathFindingResult);
        //    Assert.IsNotNull(PathFindingResult.Path);
        //    Assert.IsTrue(PathFindingResult.Path.Any());
        //    Assert.AreEqual(1, PathFindingResult.Path.Count);
        //    Assert.AreEqual("<25, 29>", PathFindingResult.Path[0].ToString());
        //}

        //[TestMethod]
        //public void Test_WithoutWalls_NoMovement()
        //{
        //    //Arrange
        //    Vector3 startLocation = new(1, 2);
        //    Vector3 endLocation = new(1, 2);
        //    string[,,] map = MapCore.InitializeMap(7, 1, 5);

        //    //Act
        //    PathFindingResult PathFindingResult = PathFinding.FindPath(map, startLocation, endLocation);

        //    //Assert
        //    Assert.IsNotNull(PathFindingResult);
        //    Assert.IsNotNull(PathFindingResult.Path);
        //    Assert.AreEqual(0, PathFindingResult.Path.Count);
        //}


    }
}
