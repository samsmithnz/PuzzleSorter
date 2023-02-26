using PuzzleSolver.Images;
using PuzzleSolver.Map;
using PuzzleSolver.MultipleRobots;
using PuzzleSolver.Processing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace PuzzleSolver.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    [TestCategory("L0")]
    public class BoardTests
    {

        [TestMethod]
        public void BoardInitializationTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get3ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            Robot robot = new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>(){
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                new List<Robot>() { robot });

            //Act

            //Assert
            Assert.AreEqual(new Rgb24(255, 0, 0), Color.Red.ToPixel<Rgb24>());
            Assert.AreEqual(new Rgb24(0, 0, 255), Color.Blue.ToPixel<Rgb24>());
            Assert.AreEqual(new Rgb24(255, 255, 0), Color.Yellow.ToPixel<Rgb24>());
            Assert.IsNotNull(board);
            Assert.IsNotNull(board.Map);
            Assert.IsNotNull(board.Robots[0]);
            Assert.AreEqual(new(2, 2), board.UnsortedPiecesLocation);
            Assert.AreEqual(3, board.SortedDropZones.Count);
            Assert.AreEqual(new(0, 1), board.SortedDropZones[0].Location);
            Assert.AreEqual(0, board.SortedPieces.Count);
            Assert.AreEqual(4, board.UnsortedPieces.Count);
            Assert.AreEqual(new Vector2(2, 1), board.Robots[0].Location);
        }

        [TestMethod]
        public void BoardInitializationWith7WidthTest()
        {
            //Arrange
            int width = 7;
            int height = 7;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get3ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            Robot robot = new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>(){
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                new List<Robot>() { robot });

            //Act

            //Assert
            Assert.AreEqual(new Rgb24(255, 0, 0), Color.Red.ToPixel<Rgb24>());
            Assert.AreEqual(new Rgb24(0, 0, 255), Color.Blue.ToPixel<Rgb24>());
            Assert.AreEqual(new Rgb24(255, 255, 0), Color.Yellow.ToPixel<Rgb24>());
            Assert.IsNotNull(board);
            Assert.IsNotNull(board.Map);
            Assert.IsNotNull(board.Robots[0]);
            Assert.AreEqual(new(3, 3), board.UnsortedPiecesLocation);
            Assert.AreEqual(3, board.SortedDropZones.Count);
            Assert.AreEqual(new(0, 1), board.SortedDropZones[0].Location);
            Assert.AreEqual(0, board.SortedPieces.Count);
            Assert.AreEqual(4, board.UnsortedPieces.Count);
            Assert.AreEqual(new Vector2(3, 2), board.Robots[0].Location);
        }

        [TestMethod]
        public void Board3ColorsRunTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get3ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            Robot robot = new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>() {
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Yellow.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                new List<Robot>() { robot });

            //Act
            Queue<RobotAction> results = board.RunRobot();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(4, board.SortedPieces.Count);
            Assert.IsTrue(board.UnsortedPieces.Count == 0);
            Assert.IsNotNull(results);
            Assert.AreEqual(5, results.Count);

            //Complete the first action
            RobotAction robotAction1 = results.Dequeue();
            Assert.IsNotNull(robotAction1);
            Assert.IsNotNull(robotAction1.PieceId);
            Assert.IsNull(robotAction1.PathToPickup); //This is null because we start in the right location
            Assert.IsNotNull(robotAction1.PickupAction);
            Assert.IsNotNull(robotAction1.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction1.RobotDropoffStartingLocation);
            Assert.AreEqual(new(1, 1), robotAction1.PathToDropoff.Path[0]);
            Assert.AreEqual(new(1, 1), robotAction1.RobotDropoffEndingLocation);
            Assert.AreEqual(1, robotAction1.DropoffPieceCount);
            Assert.IsNotNull(robotAction1.DropoffAction);
            Assert.AreEqual(new(0, 1), board.SortedPieces[0].Location);
            Assert.AreEqual(4, results.Count);

            //Complete the second action
            RobotAction robotAction2 = results.Dequeue();
            Assert.IsNotNull(robotAction2);
            Assert.IsNotNull(robotAction2.PieceId);
            Assert.IsNotNull(robotAction2.PathToPickup);
            Assert.AreEqual(new(1, 1), robotAction2.RobotPickupStartingLocation);
            Assert.AreEqual(new(2, 1), robotAction2.PathToPickup.Path[0]);
            Assert.AreEqual(new(2, 1), robotAction2.RobotPickupEndingLocation);
            Assert.IsNotNull(robotAction2.PickupAction);
            Assert.IsNotNull(robotAction2.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction2.RobotDropoffStartingLocation);
            Assert.AreEqual(new(1, 1), robotAction2.PathToDropoff.Path[0]);
            Assert.AreEqual(new(1, 2), robotAction2.PathToDropoff.Path[1]);
            Assert.AreEqual(new(1, 2), robotAction2.RobotDropoffEndingLocation);
            Assert.AreEqual(1, robotAction2.DropoffPieceCount);
            Assert.IsNotNull(robotAction2.DropoffAction);
            Assert.AreEqual(3, results.Count);

            //Complete the third action
            RobotAction robotAction3 = results.Dequeue();
            Assert.IsNotNull(robotAction3);
            Assert.IsNotNull(robotAction3.PieceId);
            Assert.IsNotNull(robotAction3.PathToPickup);
            Assert.AreEqual(new(1, 2), robotAction3.RobotPickupStartingLocation);
            Assert.AreEqual(new(1, 1), robotAction3.PathToPickup.Path[0]);
            Assert.AreEqual(new(2, 1), robotAction3.PathToPickup.Path[1]);
            Assert.AreEqual(new(2, 1), robotAction3.RobotPickupEndingLocation);
            Assert.IsNotNull(robotAction3.PickupAction);
            Assert.IsNotNull(robotAction3.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction3.RobotDropoffStartingLocation);
            Assert.AreEqual(new(1, 1), robotAction3.PathToDropoff.Path[0]);
            Assert.AreEqual(new(1, 1), robotAction3.RobotDropoffEndingLocation);
            Assert.AreEqual(2, robotAction3.DropoffPieceCount);
            Assert.IsNotNull(robotAction3.DropoffAction);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(Color.Red.ToPixel<Rgb24>(), board.SortedPieces[0].TopColorGroup);
            Assert.AreEqual(2, board.SortedDropZones[0].Count);
            Assert.AreEqual(1, board.SortedDropZones[1].Count);
            Assert.AreEqual(1, board.SortedDropZones[2].Count);
            Assert.AreEqual(2, board.GetPieceCount(board.SortedDropZones[0].Location));
        }

        [TestMethod]
        public void Board6ColorsRunTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get6ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            Robot robot = new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>() {
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 5,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 6,
                        Image = ImageCropping.CreateImage(Color.Purple.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 7,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 8,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 9,
                        Image = ImageCropping.CreateImage(Color.Yellow.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 10,
                        Image = ImageCropping.CreateImage(Color.Orange.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                new List<Robot>() { robot });

            //Act
            Queue<RobotAction> results = board.RunRobot();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(10, board.SortedPieces.Count);
            Assert.IsTrue(board.UnsortedPieces.Count == 0);
            Assert.IsNotNull(results);
            Assert.AreEqual(11, results.Count);

            //Complete the first action
            RobotAction robotAction1 = results.Dequeue();
            Assert.IsNotNull(robotAction1);
            Assert.IsNotNull(robotAction1.PieceId);
            Assert.IsNull(robotAction1.PathToPickup); //This is null because we start in the right location
            Assert.IsNotNull(robotAction1.PickupAction);
            Assert.IsNotNull(robotAction1.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction1.RobotDropoffStartingLocation);
            Assert.AreEqual(new(1, 1), robotAction1.PathToDropoff.Path[0]);
            Assert.AreEqual(new(1, 1), robotAction1.RobotDropoffEndingLocation);
            Assert.AreEqual(1, robotAction1.DropoffPieceCount);
            Assert.IsNotNull(robotAction1.DropoffAction);
            Assert.AreEqual(new(0, 1), board.SortedPieces[0].Location);
            Assert.AreEqual(10, results.Count);

            //Complete the second action
            RobotAction robotAction2 = results.Dequeue();
            Assert.IsNotNull(robotAction2);
            Assert.IsNotNull(robotAction2.PieceId);
            Assert.IsNotNull(robotAction2.PathToPickup);
            Assert.AreEqual(new(1, 1), robotAction2.RobotPickupStartingLocation);
            Assert.AreEqual(new(2, 1), robotAction2.PathToPickup.Path[0]);
            Assert.AreEqual(new(2, 1), robotAction2.RobotPickupEndingLocation);
            Assert.IsNotNull(robotAction2.PickupAction);
            Assert.IsNotNull(robotAction2.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction2.RobotDropoffStartingLocation);
            Assert.AreEqual(new(1, 1), robotAction2.PathToDropoff.Path[0]);
            Assert.AreEqual(new(1, 2), robotAction2.PathToDropoff.Path[1]);
            Assert.AreEqual(new(1, 3), robotAction2.PathToDropoff.Path[2]);
            Assert.AreEqual(new(1, 3), robotAction2.RobotDropoffEndingLocation);
            Assert.AreEqual(1, robotAction2.DropoffPieceCount);
            Assert.IsNotNull(robotAction2.DropoffAction);
            Assert.AreEqual(9, results.Count);

            //Complete the third action
            RobotAction robotAction3 = results.Dequeue();
            Assert.IsNotNull(robotAction3);
            Assert.IsNotNull(robotAction3.PieceId);
            Assert.IsNotNull(robotAction3.PathToPickup);
            Assert.AreEqual(new(1, 3), robotAction3.RobotPickupStartingLocation);
            Assert.AreEqual(new(1, 2), robotAction3.PathToPickup.Path[0]);
            Assert.AreEqual(new(1, 1), robotAction3.PathToPickup.Path[1]);
            Assert.AreEqual(new(2, 1), robotAction3.PathToPickup.Path[2]);
            Assert.AreEqual(new(2, 1), robotAction3.RobotPickupEndingLocation);
            Assert.IsNotNull(robotAction3.PickupAction);
            Assert.IsNotNull(robotAction3.PathToDropoff);
            Assert.AreEqual(new(2, 1), robotAction3.RobotDropoffStartingLocation);
            Assert.AreEqual(new(1, 1), robotAction3.PathToDropoff.Path[0]);
            Assert.AreEqual(new(1, 1), robotAction3.RobotDropoffEndingLocation);
            Assert.AreEqual(2, robotAction3.DropoffPieceCount);
            Assert.IsNotNull(robotAction3.DropoffAction);
            Assert.AreEqual(8, results.Count);

            //Complete the fourth action
            RobotAction robotAction4 = results.Dequeue();
            Assert.IsNotNull(robotAction4);
            Assert.IsNotNull(robotAction4.PieceId);
            Assert.IsNotNull(robotAction4.PathToPickup);
            Assert.IsNotNull(robotAction4.PickupAction);
            Assert.IsNotNull(robotAction4.PathToDropoff);
            Assert.AreEqual(1, robotAction4.DropoffPieceCount);
            Assert.IsNotNull(robotAction4.DropoffAction);
            Assert.AreEqual(7, results.Count);

            Assert.AreEqual(Color.Red.ToPixel<Rgb24>(), board.SortedPieces[0].TopColorGroup);
            Assert.AreEqual(4, board.SortedDropZones[0].Count);
            Assert.AreEqual(1, board.SortedDropZones[1].Count);
            Assert.AreEqual(2, board.SortedDropZones[2].Count);
            Assert.AreEqual(1, board.SortedDropZones[3].Count);
            Assert.AreEqual(1, board.SortedDropZones[4].Count);
            Assert.AreEqual(1, board.SortedDropZones[5].Count);
            Assert.AreEqual(4, board.GetPieceCount(board.SortedDropZones[0].Location));
        }

        [TestMethod]
        public void StJohnImage16ColorsRunTest()
        {
            //Arrange
            int width = 7;
            int height = 7;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get16ColorPalette();
            //Process + Split the image
            string imageDir = Environment.CurrentDirectory + @"/TestImages/st-john-beach.jpg";
            Image<Rgb24> sourceImage = Image.Load<Rgb24>(imageDir);
            List<Image<Rgb24>> images = ImageCropping.SplitImageIntoMultiplePieces(sourceImage, 250, 250);
            List<ImageStats> subImages = new();
            ImageColorGroups imageProcessing = new(palette);
            foreach (Image<Rgb24> image in images)
            {
                ImageStats subitemImageStats = imageProcessing.ProcessStatsForImage(null, image, true);
                if (subitemImageStats != null)
                {
                    subImages.Add(subitemImageStats);
                }
            }
            int i = 0;
            List<Piece> pieces = new List<Piece>();
            foreach (ImageStats image in subImages)
            {
                i++;
                pieces.Add(new Piece()
                {
                    Id = i,
                    Image = image.Image,
                    ImageStats = image,
                    Location = centerPointLocation
                });
            }
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            Robot robot = new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1));
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                pieces,
                sortedDropZones,
                new List<Robot>() { robot });

            //Act
            Queue<RobotAction> results = board.RunRobot();

            //Assert
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(12, board.SortedPieces.Count);
            Assert.IsTrue(board.UnsortedPieces.Count == 0);
            Assert.IsNotNull(results);
            Assert.AreEqual(13, results.Count);
        }

        [TestMethod]
        public void Board6ColorsMultipleRobotsRunTest()
        {
            //Arrange
            int width = 5;
            int height = 5;
            string[,] map = MapGeneration.GenerateMap(width, height);
            Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
            List<Rgb24> palette = ColorPalettes.Get6ColorPalette();
            List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);
            List<Robot> robots = new() {
                new Robot(1, new Vector2(centerPointLocation.X, centerPointLocation.Y - 1), new Vector2(centerPointLocation.X, centerPointLocation.Y - 1)),
                new Robot(2, new Vector2(centerPointLocation.X - 1, centerPointLocation.Y), new Vector2(centerPointLocation.X - 1, centerPointLocation.Y))
            };
            //Initialize the game board
            Board board = new(map,
                centerPointLocation,
                palette,
                new List<Piece>() {
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(Color.Green.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 5,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 6,
                        Image = ImageCropping.CreateImage(Color.Purple.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 7,
                        Image = ImageCropping.CreateImage(Color.Blue.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 8,
                        Image = ImageCropping.CreateImage(Color.Red.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 9,
                        Image = ImageCropping.CreateImage(Color.Yellow.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    },
                    new Piece() {
                        Id = 10,
                        Image = ImageCropping.CreateImage(Color.Orange.ToPixel<Rgb24>()),
                        Location = centerPointLocation
                    }
                },
                sortedDropZones,
                robots);

            //Act
            TimeLine results = board.RunRobots();

            //Assert           
            Assert.IsNotNull(board);
            Assert.AreEqual(0, board.UnsortedPieces.Count);
            Assert.AreEqual(10, board.SortedPieces.Count);
            Assert.IsNotNull(results);
            Assert.AreEqual(21, results.Ticks.Count);

            //check the first tick
            Tick tick1 = results.Ticks[0];
            Assert.AreEqual(1, tick1.TickNumber);
            Assert.AreEqual(2, tick1.RobotActions.Count);
            Assert.AreEqual(1, tick1.RobotActions[0].PieceId);
            Assert.AreEqual(2, tick1.RobotActions[1].PieceId);
            Assert.IsNull(tick1.RobotActions[0].Movement);
            Assert.IsNull(tick1.RobotActions[1].Movement);

            Tick tick2 = results.Ticks[1];
            Assert.AreEqual(2, tick2.TickNumber);
            Assert.AreEqual(2, tick2.RobotActions.Count);
            Assert.AreEqual(1, tick2.RobotActions[0].PieceId);
            Assert.AreEqual(2, tick2.RobotActions[1].PieceId);
            Assert.AreEqual(2, tick2.RobotActions[0].Movement.Count);
            Assert.AreEqual(2, tick2.RobotActions[1].Movement.Count);
            Assert.AreEqual(new Vector2(2,1), tick2.RobotActions[0].Movement[0]);
            Assert.AreEqual(new Vector2(1,1), tick2.RobotActions[0].Movement[1]);
            Assert.AreEqual(new Vector2(1,2), tick2.RobotActions[1].Movement[0]);
            Assert.AreEqual(new Vector2(1,3), tick2.RobotActions[1].Movement[1]);

            Tick tick3 = results.Ticks[2];
            Assert.AreEqual(3, tick3.TickNumber);
            Assert.AreEqual(2, tick3.RobotActions.Count);
            Assert.AreEqual(1, tick3.RobotActions[0].PieceId);
            Assert.AreEqual(2, tick3.RobotActions[1].PieceId);
            Assert.AreEqual(new Vector2(0, 1), tick3.RobotActions[0].DropoffAction.Location);
            Assert.AreEqual(new Vector2(0, 3), tick3.RobotActions[1].DropoffAction.Location);
            Assert.AreEqual(1, tick3.RobotActions[0].DropoffAction.DestinationPieceCount);
            Assert.AreEqual(1, tick3.RobotActions[1].DropoffAction.DestinationPieceCount);
            Assert.IsNull(tick3.RobotActions[0].Movement);
            Assert.IsNull(tick3.RobotActions[1].Movement);

            Tick tick4 = results.Ticks[3];
            Assert.AreEqual(4, tick4.TickNumber);
            Assert.AreEqual(2, tick4.RobotActions.Count);
            Assert.AreEqual(3, tick4.RobotActions[0].PieceId);
            Assert.AreEqual(4, tick4.RobotActions[1].PieceId);
            Assert.AreEqual(2, tick4.RobotActions[0].Movement.Count);
            Assert.AreEqual(2, tick4.RobotActions[1].Movement.Count);

            //check the second to last tick
            Assert.AreEqual(20, results.Ticks[results.Ticks.Count - 2].TickNumber);
            Assert.AreEqual(2, results.Ticks[results.Ticks.Count - 2].RobotActions.Count);
            Assert.AreEqual(9, results.Ticks[results.Ticks.Count - 2].RobotActions[0].PieceId);
            Assert.AreEqual(10, results.Ticks[results.Ticks.Count - 2].RobotActions[1].PieceId);

            //check the last tick
            Assert.AreEqual(16, results.Ticks[results.Ticks.Count - 1].TickNumber);
            Assert.AreEqual(0, results.Ticks[results.Ticks.Count - 1].RobotActions.Count);
        }
    }
}
