using Assets.Scripts.Common;
using PuzzleSolver;
using PuzzleSolver.Images;
using PuzzleSolver.Map;
using PuzzleSolver.MultipleRobots;
using PuzzleSolver.Processing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class MainLoop : MonoBehaviour
{
    public Texture2D SourceTexture;
    public Material PieceMaterial;

    private readonly bool _ShowCoordOnFloor = true;
    private readonly bool _ShowLinesOnFloor = true;
    private Queue<RobotAction> _RobotActions = null;
    private TimeLine _Timeline = null;
    //private GameObject _RobotObject = null;
    private int _ProcessingRobotsInTurnCounter = 0;
    private int _ActionCount = 0;
    private float _PieceWidth = 0.5f;
    private float _PieceHeight = 0.25f;
    private float _PieceDepth = 0.5f;
    private int _PieceSize = 250;
    private int _Turn = 0;

    // Start is called before the first frame update
    void Start()
    {
        Utility.LogWithTime("Initializing map");
        //Setup board
        int width = 7;
        int height = 7;
        string[,] map = MapGeneration.GenerateMap(width, height);
        System.Numerics.Vector2 centerPointLocation = MapGeneration.GetCenterPointLocation(width, height);
        Utility.LogWithTime("Initializing color palette");
        List<Rgb24> palette = ColorPalettes.Get6ColorPalette();
        Utility.LogWithTime("Initializing pieces");
        Dictionary<int, System.Numerics.Vector2> robotStartingLocations = new()
        {
            { 1, new System.Numerics.Vector2(centerPointLocation.X, centerPointLocation.Y - 1) },
            { 2, new System.Numerics.Vector2(centerPointLocation.X - 1, centerPointLocation.Y) },
            { 3, new System.Numerics.Vector2(centerPointLocation.X + 1, centerPointLocation.Y) },
            { 4, new System.Numerics.Vector2(centerPointLocation.X, centerPointLocation.Y + 1) }
        };
        //List<Piece> pieces = GetRandomPieceList(36, palette);
        //List<Piece> pieces = GetPiecesFromImage(_PieceSize, _PieceSize, palette, centerPointLocation);
        List<Piece> pieces = GetColoredPieceList(centerPointLocation);
        List<SortedDropZone> sortedDropZones = SortedDropZones.GetSortedDropZones(map, palette);

        List<Robot> robots = new() {
            new Robot(1, robotStartingLocations[1], robotStartingLocations[1]),
            new Robot(2, robotStartingLocations[2], robotStartingLocations[2]),
            //new Robot(3, robotStartingLocations[3], robotStartingLocations[3]),
            //new Robot(4, robotStartingLocations[4], robotStartingLocations[4])
        };
        //Initialize the game board
        Board board = new(map,
            centerPointLocation,
            palette,
            pieces,
            sortedDropZones,
            robots);

        //Setup map
        Utility.LogWithTime("Setting up map");
        LevelSetup.SetupMap(gameObject, board.Map, _ShowLinesOnFloor, _ShowCoordOnFloor);

        Piece[] unsortedList = new Piece[board.UnsortedPieces.Count];
        board.UnsortedPieces.ToList().CopyTo(unsortedList);

        //Get the robot actions
        Utility.LogWithTime("Calculating robot moves");
        _Timeline = board.RunRobots();
        Utility.LogWithTime(_Timeline.Turns.Count + " turns found");

        //Add unsorted pieces
        Utility.LogWithTime("Building stack of unsorted pieces");
        float y = (_PieceHeight / 2f) + (_PieceHeight * unsortedList.Length) - _PieceHeight; //Add the pieces in reverse, so the first item in the queue is also the top of the stack
        int i = 0;
        Utility.LogWithTime("There are " + unsortedList.Count().ToString() + " unsorted pieces to process");
        foreach (Piece piece in unsortedList)
        {
            i++;
            //Debug.Log("Adding piece " + piece.Id);
            GameObject pieceObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            pieceObject.transform.position = new Vector3(centerPointLocation.X, y, centerPointLocation.Y);
            pieceObject.transform.localScale = new Vector3(_PieceWidth, _PieceHeight, _PieceDepth);
            pieceObject.name = GetPieceName(i);
            if (piece != null && piece.TopColorGroup != null)
            {
                pieceObject.GetComponent<Renderer>().material = PieceMaterial;
                pieceObject.GetComponent<Renderer>().material.color = Utility.ConvertToUnityColor((Rgb24)piece.TopColorGroup);
                //Debug.Log("Piece " + i + " color: " + pieceObject.GetComponent<Renderer>().material.color);
            }
            GameObject pieceImageObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Texture texture = Image2Texture(piece.Image);
            Material material = new Material(Shader.Find("Standard"));
            material.mainTexture = texture;
            Renderer renderer = pieceImageObject.GetComponent<Renderer>();
            renderer.material = material;
            pieceImageObject.transform.parent = pieceObject.transform;
            pieceImageObject.transform.localScale = new Vector3(1f, 0.1f, 1f);
            pieceImageObject.transform.localPosition = new Vector3(0f, 0.6f, 0f);
            pieceImageObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            y -= _PieceHeight;
        }

        //Add the robot
        Utility.LogWithTime("Creating robot entities");
        List<Rgb24> robotPalette = ColorPalettes.Get6ColorPalette();
        if (robotPalette.Count < board.Robots.Count)
        {
            Debug.LogError("More robot palettes are needed to support this many robots");
        }
        //Reset robot locations with the start locations
        foreach (Robot robot in board.Robots)
        {
            robot.Location = robotStartingLocations[robot.RobotId];
        }
        for (int j = 0; j < board.Robots.Count; j++)
        {
            Robot robot = board.Robots[j];
            GameObject robotObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            robotObject.transform.position = new Vector3(robot.Location.X, 0.5f, robot.Location.Y);
            robotObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            robotObject.name = GetRobotName(robot.RobotId);
            robotObject.GetComponent<Renderer>().material.color = Utility.ConvertToUnityColor(robotPalette[j]); //UnityEngine.Color.gray; //dark gray
            Utility.LogWithTime("Robot " + robot.RobotId + " created at " + robot.Location);
        }

        ////Add lines on puzzle map, Drawing line renderers
        //int width = 4;
        //int length = 3;
        //for (int x = 0; x <= width - 1; x++)
        //{
        //    for (int z = 0; z <= length - 1; z++)
        //    {
        //        if (x == 0 && z != length - 1)
        //        {
        //            LineRenderer xGuideLine = newFloorObject.AddComponent<LineRenderer>();
        //            xGuideLine.material = new Material(Shader.Find("Sprites/Default"));
        //            xGuideLine.widthMultiplier = 0.01f;
        //            xGuideLine.startColor = Color.gray;
        //            xGuideLine.endColor = Color.gray;
        //            xGuideLine.SetPosition(0, new Vector3(-0.5f, 0.01f, z + 0.5f));
        //            xGuideLine.SetPosition(1, new Vector3(width - 0.5f, 0.01f, z + 0.5f));
        //        }
        //        else if (z == length - 1 && x != 0)
        //        {
        //            LineRenderer zGuideLine = newFloorObject.AddComponent<LineRenderer>();
        //            zGuideLine.material = new Material(Shader.Find("Sprites/Default"));
        //            zGuideLine.widthMultiplier = 0.01f;
        //            zGuideLine.startColor = Color.gray;
        //            zGuideLine.endColor = Color.gray;
        //            zGuideLine.SetPosition(0, new Vector3(x - 0.5f, 0.01f, -0.5f));
        //            zGuideLine.SetPosition(1, new Vector3(x - 0.5f, 0.01f, length - 0.5f));
        //        }
        //    }
        //}

        Utility.LogWithTime(board.Robots.Count + " robots ready to roll!");
    }

    // Update is called once per frame
    void Update()
    {
        if (_Timeline != null && _Timeline.Turns.Count > 0 && _ProcessingRobotsInTurnCounter == 0 && _Turn < _Timeline.Turns.Count)
        {
            _Turn++;
            //Process robot actions for this turn
            StartCoroutine(ProcessTurn(_Turn));
        }
    }

    private IEnumerator ProcessTurn(int turn)
    {
        Debug.Log("Turn " + turn + " processing");

        foreach (RobotTurnAction item in _Timeline.Turns[turn - 1].RobotActions)
        {
            _ProcessingRobotsInTurnCounter++;
            //Double check we are only doing one thing. This shouldn't be needed, but is important to check. 
            int checkCount = 0;
            if (item.Movement != null)
            {
                checkCount++;
            }
            if (item.PickupAction != null)
            {
                checkCount++;
            }
            if (item.DropoffAction != null)
            {
                checkCount++;
            }
            if (checkCount > 1)
            {
                Debug.LogError("Turn " + turn + ", Robot " + item.RobotId + " has " + checkCount + " actions - only 1 was expected");
            }
            if (item.Movement != null && item.Movement.Count > 0)
            {
                StartCoroutine(MoveToLocation2(item.RobotId, item.Movement[0], item.Movement[1]));
            }
            if (item.PickupAction != null)
            {
                StartCoroutine(PickUpPiece(item.RobotId, (int)item.PieceId, item.PickupAction));
            }
            if (item.DropoffAction != null)
            {
                StartCoroutine(DropOffPiece(item.RobotId, (int)item.PieceId, item.DropoffAction));
            }
            //yield return StartCoroutine(DelayTurn(item));
        }
        yield return null;
    }

    private IEnumerator DelayTurn(RobotTurnAction item)
    {
        yield return new WaitForSeconds(2f);
    }

    //private IEnumerator ProcessQueueItem(RobotAction robotAction)
    //{
    //    _ActionCount++;
    //    Debug.Log("Action #" + _ActionCount + " processing");

    //    //Move to pickup zone
    //    if (robotAction.PathToPickup != null && robotAction.PathToPickup.Path.Count > 0)
    //    {
    //        yield return StartCoroutine(MoveToLocation(_RobotObject, robotAction.RobotPickupStartingLocation, robotAction.PathToPickup));
    //    }
    //    else
    //    {
    //        Debug.Log("No pickup path for action " + _ActionCount);
    //    }

    //    //Pickup piece
    //    if (robotAction.PickupAction != null)
    //    {
    //        float startingY = GameObject.Find("piece_" + robotAction.PieceId).transform.position.y;
    //        if (startingY < _PieceHeight / 2f)
    //        {
    //            startingY = _PieceHeight / 2f;
    //        }
    //        yield return StartCoroutine(PickUpPiece(robotAction.PieceId, startingY, robotAction.PickupAction));
    //    }

    //    //Move to drop off zone
    //    if (robotAction.PathToDropoff != null && robotAction.PathToDropoff.Path.Count > 0)
    //    {
    //        yield return StartCoroutine(MoveToLocation(_RobotObject, robotAction.RobotDropoffStartingLocation, robotAction.PathToDropoff));
    //    }
    //    else
    //    {
    //        Debug.Log("No drop off path for action " + _ActionCount);
    //    }

    //    //Drop piece
    //    if (robotAction.DropoffAction != null)
    //    {
    //        float endingY = (_PieceHeight / 2f) + (_PieceHeight * robotAction.DropoffPieceCount) - _PieceHeight;
    //        yield return StartCoroutine(DropOffPiece(robotAction.PieceId, endingY, robotAction.DropoffAction));
    //    }
    //    _ProcessingQueueItem = false;
    //    yield return null;
    //}

    //private IEnumerator MoveToLocation(GameObject robotObject, System.Numerics.Vector2 startLocation, PathFindingResult path)
    //{
    //    if (path != null && path.GetLastTile() != null)
    //    {
    //        //Debug.Log("Moving from " + startLocation + " to location " + path.GetLastTile().Location.ToString());

    //        Movement movementScript = robotObject.GetComponent<Movement>();
    //        if (movementScript == null)
    //        {
    //            movementScript = robotObject.AddComponent<Movement>();
    //        }
    //        //Utility.LogWithTime("Starting movement");
    //        yield return StartCoroutine(movementScript.MoveRobot(robotObject, startLocation, path));
    //    }
    //    else
    //    {
    //        Debug.Log("No movement needed - at end location");
    //        yield return null;
    //    }
    //}

    //MoveToLocation2(item.RobotID, item.Movement[0], item.Movement[1])
    private IEnumerator MoveToLocation2(int robotId, System.Numerics.Vector2 startLocation, System.Numerics.Vector2 endLocation)
    {
        GameObject robotObject = null;
        robotObject = GameObject.Find(GetRobotName(robotId));

        if (robotObject != null)
        {
            Debug.Log("Robot " + robotId + " moving from " + startLocation + " to location " + endLocation.ToString());
            Movement movementScript = robotObject.GetComponent<Movement>();
            if (movementScript == null)
            {
                movementScript = robotObject.AddComponent<Movement>();
            }
            //Utility.LogWithTime("Starting movement");
            yield return StartCoroutine(movementScript.MoveRobot2(robotObject, startLocation, endLocation));
            _ProcessingRobotsInTurnCounter--;
        }
        else
        {
            Debug.Log("Robot " + robotId + " no movement needed - at end location");
            yield return null;
        }
    }

    private IEnumerator PickUpPiece(int robotId, int pieceId, ObjectInteraction pickupAction)
    {
        GameObject robotObject = GameObject.Find(GetRobotName(robotId));
        GameObject pieceObject = GameObject.Find(GetPieceName(pieceId));
        Debug.Log("Robot " + robotId + " picking up piece " + pieceId + " at " + pickupAction.Location + " to " + robotObject.transform.position);
        float startingY = pieceObject.transform.position.y;
        if (startingY < _PieceHeight / 2f)
        {
            startingY = _PieceHeight / 2f;
        }
        if (startingY < 1.25f)
        {
            startingY = 1.25f;
        }
        if (pieceObject != null)
        {
            Movement movementScript = pieceObject.GetComponent<Movement>();
            if (movementScript == null)
            {
                movementScript = pieceObject.AddComponent<Movement>();
            }
            List<Vector3> path = new()
            {
                //Start
                pieceObject.transform.position,
                //Raise piece off pile
                new Vector3(pieceObject.transform.position.x, startingY, pieceObject.transform.position.z),
                //Move above robot
                new Vector3(robotObject.transform.position.x, startingY, robotObject.transform.position.z),
                //Drop piece on robot, and attach to parent robot at y 1.25s
                new Vector3(robotObject.transform.position.x, 1.25f, robotObject.transform.position.z)
            };
            yield return StartCoroutine(movementScript.MovePiece(pieceObject, path, robotObject.transform));
            _ProcessingRobotsInTurnCounter--;
        }
        else
        {
            Debug.Log("Piece " + pieceId + " not found");
        }
        yield return null;
    }

    private IEnumerator DropOffPiece(int robotId, int pieceId, ObjectInteraction dropOffAction)
    {
        if (dropOffAction != null && dropOffAction.Location != null)
        {
            Debug.Log("Robot " + robotId + " dropping off piece " + pieceId + " to " + dropOffAction.Location.ToString());
        }
        else
        {
            Debug.Log("Robot " + robotId + " with piece " + pieceId + " does not a drop off action");
        }
        GameObject robotObject = GameObject.Find(GetRobotName(robotId));
        GameObject pieceObject = GameObject.Find(GetPieceName(pieceId));
        float endingY = (_PieceHeight / 2f) + (_PieceHeight * dropOffAction.DestinationPieceCount) - _PieceHeight;
        float robotDetachY = endingY;
        if (robotDetachY < 1.25f)
        {
            robotDetachY = 1.25f;
        }
        if (pieceObject != null)
        {
            Movement movementScript = pieceObject.GetComponent<Movement>();
            if (movementScript == null)
            {
                movementScript = pieceObject.AddComponent<Movement>();
            }
            List<Vector3> path = new()
            {
                //detach piece from parent robot at y 1.25s
                pieceObject.transform.position,
                //raise piece off robot
                new Vector3(robotObject.transform.position.x, robotDetachY, robotObject.transform.position.z),
                //move above destination pile
                new Vector3(dropOffAction.Location.X, robotDetachY, dropOffAction.Location.Y),
                //drop to sorted pile
                new Vector3(dropOffAction.Location.X, endingY, dropOffAction.Location.Y)
            };
            yield return StartCoroutine(movementScript.MovePiece(pieceObject, path, null));
            _ProcessingRobotsInTurnCounter--;
        }
        else
        {
            Debug.Log("Piece " + pieceId + " not found");
        }
        yield return null;
    }

    private List<Piece> GetRandomPieceList(int count, List<Rgb24> palette)
    {
        List<Piece> pieceList = new();
        for (int i = 0; i < count; i++)
        {
            int random = Utility.GenerateRandomNumber(0, palette.Count);
            pieceList.Add(new Piece()
            {
                Id = i + 1,
                Image = ImageCropping.CreateImage(palette[random]),
                Location = new(2, 2)
            });
        }
        return pieceList;
    }

    private List<Piece> GetPiecesFromImage(int subImageWidth, int subImageHeight, List<Rgb24> palette, System.Numerics.Vector2 centerPointLocation)
    {
        List<Piece> pieceList = new();

        //1. Read in input image
        Utility.LogWithTime("GetPiecesFromImage: Read in input image");
        //Texture2D sourceTexture = Resources.Load<Texture2D>(@"/Images/st-john-beach.jpg");
        ImageColorGroups imageProcessing = new(palette);
        //ImageStats? sourceImageStats = imageProcessing.ProcessStatsForImage(sourceImageLocation, null, false);

        //2. Split apart images/Crop the individual images next
        Utility.LogWithTime("GetPiecesFromImage: Split apart image into smaller images");
        Image<Rgb24> sourceImg = Texture2Image(SourceTexture);
        List<Image<Rgb24>> images = ImageCropping.SplitImageIntoMultiplePieces(sourceImg, subImageWidth, subImageHeight);

        //Get image stats for each individual image and combine in one list
        Utility.LogWithTime("GetPiecesFromImage: Get stats for each piece");
        List<ImageStats> subImages = new();
        foreach (Image<Rgb24> image in images)
        {
            ImageStats subitemImageStats = imageProcessing.ProcessStatsForImage(null, image, true);
            if (subitemImageStats != null)
            {
                subImages.Add(subitemImageStats);
            }
        }

        int i = 0;
        Utility.LogWithTime("GetPiecesFromImage: Build list of pieces at " + centerPointLocation.ToString());
        foreach (ImageStats image in subImages)
        {
            i++;
            pieceList.Add(new Piece()
            {
                Id = i,
                Image = image.Image,
                ImageStats = image,
                Location = centerPointLocation
            });
        }

        return pieceList;
    }

    private List<Piece> GetColoredPieceList(System.Numerics.Vector2 centerPointLocation)
    {
        List<Piece> pieces = new List<Piece>()
        {
            new Piece() {
                Id = 1,
                Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>()),
                Location = centerPointLocation
            },
            new Piece() {
                Id = 2,
                Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>()),
                Location = centerPointLocation
            },
            new Piece() {
                Id = 3,
                Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>()),
                Location = centerPointLocation
            },
            new Piece() {
                Id = 4,
                Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Green.ToPixel<Rgb24>()),
                Location = centerPointLocation
            },
            new Piece() {
                Id = 5,
                Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>()),
                Location = centerPointLocation
            },
            new Piece() {
                Id = 6,
                Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Purple.ToPixel<Rgb24>()),
                Location = centerPointLocation
            },
            new Piece() {
                Id = 7,
                Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>()),
                Location = centerPointLocation
            },
            new Piece() {
                Id = 8,
                Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>()),
                Location = centerPointLocation
            },
            new Piece() {
                Id = 9,
                Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Yellow.ToPixel<Rgb24>()),
                Location = centerPointLocation
            },
            new Piece() {
                Id = 10,
                Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Orange.ToPixel<Rgb24>()),
                Location = centerPointLocation
            }
        };
        return pieces;
    }

    public static Image<Rgb24> Texture2Image(Texture2D texture)
    {
        if (texture == null)
        {
            return null;
        }
        //Save the texture to the stream.
        byte[] bytes = texture.EncodeToPNG();

        //Memory stream to store the bitmap data.
        MemoryStream ms = new MemoryStream(bytes);

        //Seek the beginning of the stream.
        ms.Seek(0, SeekOrigin.Begin);

        //Create an image from a stream.
        Image<Rgb24> myImage = SixLabors.ImageSharp.Image.Load<Rgb24>(ms.ToArray());

        //Close the stream, we no longer need it.
        ms.Close();

        return (myImage);
    }

    public static Texture2D Image2Texture(SixLabors.ImageSharp.Image im)
    {
        //Memory stream to store the bitmap data.
        MemoryStream ms = new MemoryStream();

        //Save to that memory stream.
        im.SaveAsPng(ms);

        //Go to the beginning of the memory stream.
        ms.Seek(0, SeekOrigin.Begin);
        //make a new Texture2D
        Texture2D tex = new Texture2D(im.Width, im.Height);
        tex.LoadImage(ms.ToArray());

        //Close the stream.
        ms.Close();

        return tex;
    }

    private string GetRobotName(int robotId)
    {
        return "robot_" + robotId;
    }

    private string GetPieceName(int pieceId)
    {
        return "piece_" + pieceId;
    }

}
