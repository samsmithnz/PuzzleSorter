using Assets.Scripts.Common;
using PuzzleSolver;
using PuzzleSolver.Images;
using PuzzleSolver.Map;
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
    private GameObject _RobotObject = null;
    private bool _ProcessingQueueItem = false;
    private int _ActionCount = 0;
    private float _PieceWidth = 0.5f;
    private float _PieceHeight = 0.25f;
    private float _PieceDepth = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Setup board
        string[,] map = MapGeneration.GenerateMap();
        List<Rgb24> colorPalette = ColorPalettes.Get16ColorPalette();
        //List<Piece> pieces = GetRandomPieceList(36, colorPalette);
        List<Piece> pieces = GetPiecesFromImage(250, 250, colorPalette);
        Board board = new(map,
            new System.Numerics.Vector2(2, 2),
            colorPalette,
            pieces,
            //new List<Piece>() {
            //        new Piece() {
            //            Id = 1,
            //            Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>()),
            //            Location = new(2, 2)
            //        },
            //        new Piece() {
            //            Id = 2,
            //            Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>()),
            //            Location = new(2, 2)
            //        },
            //        new Piece() {
            //            Id = 3,
            //            Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>()),
            //            Location = new(2, 2)
            //        },
            //        new Piece() {
            //            Id = 4,
            //            Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Green.ToPixel<Rgb24>()),
            //            Location = new(2, 2)
            //        },
            //        new Piece() {
            //            Id = 5,
            //            Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>()),
            //            Location = new(2, 2)
            //        },
            //        new Piece() {
            //            Id = 6,
            //            Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Purple.ToPixel<Rgb24>()),
            //            Location = new(2, 2)
            //        },
            //        new Piece() {
            //            Id = 7,
            //            Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>()),
            //            Location = new(2, 2)
            //        },
            //        new Piece() {
            //            Id = 8,
            //            Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>()),
            //            Location = new(2, 2)
            //        },
            //        new Piece() {
            //            Id = 9,
            //            Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Yellow.ToPixel<Rgb24>()),
            //            Location = new(2, 2)
            //        },
            //        new Piece() {
            //            Id = 10,
            //            Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Orange.ToPixel<Rgb24>()),
            //            Location = new(2, 2)
            //        }
            //},
            GetSortedDropZones(map, colorPalette),
            //new()
            //{
            //    new SortedDropZone(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>(), new(0, 4)),
            //    new SortedDropZone(SixLabors.ImageSharp.Color.Purple.ToPixel<Rgb24>(), new(0, 2)),
            //    new SortedDropZone(SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>(), new(4, 0)),
            //    new SortedDropZone(SixLabors.ImageSharp.Color.Green.ToPixel<Rgb24>(), new(2, 4)),
            //    new SortedDropZone(SixLabors.ImageSharp.Color.Yellow.ToPixel<Rgb24>(), new(4, 4)),
            //    new SortedDropZone(SixLabors.ImageSharp.Color.Orange.ToPixel<Rgb24>(),new(4, 2)),
            //},
            new Robot(new System.Numerics.Vector2(2, 1)));

        //Setup map
        LevelSetup.SetupMap(gameObject, board.Map, _ShowLinesOnFloor, _ShowCoordOnFloor);

        Piece[] unsortedList = new Piece[board.UnsortedPieces.Count];
        board.UnsortedPieces.ToList().CopyTo(unsortedList);

        //Get the robot actions
        _RobotActions = board.RunRobot();

        //Add unsorted pieces
        float y = (_PieceHeight / 2f) + (_PieceHeight * unsortedList.Length) - _PieceHeight; //Add the pieces in reverse, so the first item in the queue is also the top of the stack
        int i = 0;
        Debug.LogWarning("There are " + unsortedList.Count().ToString() + " unsorted pieces to process");
        foreach (Piece piece in unsortedList)
        {
            i++;
            //Debug.LogWarning("Adding piece " + piece.Id);
            GameObject pieceObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            pieceObject.transform.position = new Vector3(2f, y, 2f);
            pieceObject.transform.localScale = new Vector3(_PieceWidth, _PieceHeight, _PieceDepth);
            pieceObject.name = "piece_" + i.ToString();
            if (piece != null && piece.TopColorGroup != null)
            {
                pieceObject.GetComponent<Renderer>().material = PieceMaterial;
                pieceObject.GetComponent<Renderer>().material.color = Utility.ConvertToUnityColor((Rgb24)piece.TopColorGroup);
                //Debug.LogWarning("Piece " + i + " color: " + pieceObject.GetComponent<Renderer>().material.color);
            }
            y -= _PieceHeight;
        }

        //Add the robot
        _RobotObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        _RobotObject.transform.position = new Vector3(board.Robot.Location.X, 0.5f, board.Robot.Location.Y);
        _RobotObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        _RobotObject.name = "robot";
        _RobotObject.GetComponent<Renderer>().material.color = UnityEngine.Color.gray; //dark gray
    }

    // Update is called once per frame
    void Update()
    {
        if (_RobotActions != null && _RobotActions.Count > 0 && _ProcessingQueueItem == false)
        {
            _ProcessingQueueItem = true;
            //Get and process a robot action from the queue
            StartCoroutine(ProcessQueueItem(_RobotActions.Dequeue()));
        }
    }

    private IEnumerator ProcessQueueItem(RobotAction robotAction)
    {
        _ActionCount++;
        Debug.LogWarning("Action #" + _ActionCount + " processing");

        //Move to pickup zone
        if (robotAction.PathToPickup != null && robotAction.PathToPickup.Path.Count > 0)
        {
            yield return StartCoroutine(MoveToLocation(_RobotObject, robotAction.RobotPickupStartingLocation, robotAction.PathToPickup));
        }
        else
        {
            Debug.LogWarning("No pickup path for action " + _ActionCount);
        }

        //Pickup piece
        if (robotAction.PickupAction != null)
        {
            float startingY = GameObject.Find("piece_" + robotAction.PieceId).transform.position.y;
            if (startingY < _PieceHeight / 2f)
            {
                startingY = _PieceHeight / 2f;
            }
            yield return StartCoroutine(PickUpPiece(robotAction.PieceId, startingY, robotAction.PickupAction));
        }

        //Move to drop off zone
        if (robotAction.PathToDropoff != null && robotAction.PathToDropoff.Path.Count > 0)
        {
            yield return StartCoroutine(MoveToLocation(_RobotObject, robotAction.RobotDropoffStartingLocation, robotAction.PathToDropoff));
        }
        else
        {
            Debug.LogWarning("No drop off path for action " + _ActionCount);
        }

        //Drop piece
        if (robotAction.PickupAction != null)
        {
            float endingY = (_PieceHeight / 2f) + (_PieceHeight * robotAction.DropoffPieceCount) - _PieceHeight;
            yield return StartCoroutine(DropOffPiece(robotAction.PieceId, endingY, robotAction.DropoffAction));
        }
        _ProcessingQueueItem = false;
        yield return null;
    }

    private IEnumerator MoveToLocation(GameObject robotObject, System.Numerics.Vector2 startLocation, PathFindingResult path)
    {
        if (path != null && path.GetLastTile() != null)
        {
            //Debug.LogWarning("Moving from " + startLocation + " to location " + path.GetLastTile().Location.ToString());

            Movement movementScript = robotObject.GetComponent<Movement>();
            if (movementScript == null)
            {
                movementScript = robotObject.AddComponent<Movement>();
            }
            //Utility.LogWithTime("Starting movement");
            yield return StartCoroutine(movementScript.MoveRobot(robotObject, startLocation, path));
        }
        else
        {
            Debug.LogWarning("No movement needed - at end location");
            yield return null;
        }
    }

    private IEnumerator PickUpPiece(int pieceId, float startingY, ObjectInteraction pickupAction)
    {
        Debug.LogWarning("Picking up piece " + pickupAction.Location.ToString());
        GameObject pieceObject = GameObject.Find("piece_" + pieceId);
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
                //Move up, above pile
                new Vector3(pieceObject.transform.position.x, startingY, pieceObject.transform.position.z),
                //Move over, above robot
                new Vector3(pieceObject.transform.position.x, startingY, _RobotObject.transform.position.z),
                //Drop piece on robot, and attach to parent robot at y 1.25s
                new Vector3(pieceObject.transform.position.x, 1.25f, _RobotObject.transform.position.z)
            };
            yield return StartCoroutine(movementScript.MovePiece(pieceObject, path, _RobotObject.transform));
        }
        else
        {
            Debug.LogWarning("Piece " + pieceId + " not found");
        }
    }

    private IEnumerator DropOffPiece(int pieceId, float endingY, ObjectInteraction dropOffAction)
    {
        Debug.LogWarning("Dropping off piece " + dropOffAction.Location.ToString());
        GameObject pieceObject = GameObject.Find("piece_" + pieceId);
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
            new Vector3(pieceObject.transform.position.x, 1.25f, _RobotObject.transform.position.z),
            //raise piece off robot
            new Vector3(pieceObject.transform.position.x, endingY, _RobotObject.transform.position.z),
            //move above destination pile
            new Vector3(pieceObject.transform.position.x, endingY, pieceObject.transform.position.z),
            //drop to ground
            new Vector3(pieceObject.transform.position.x, endingY, pieceObject.transform.position.z)
        };
            yield return StartCoroutine(movementScript.MovePiece(pieceObject, path, null));
        }
        else
        {
            Debug.LogWarning("Piece " + pieceId + " not found");
        }
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

    private List<SortedDropZone> GetSortedDropZones(string[,] map, List<Rgb24> palette)
    {
        List<SortedDropZone> sortedDropZones = new List<SortedDropZone>();
        int width = map.GetLength(0);
        int height = map.GetLength(1);
        int totalBorders = (width * 2) + ((height * 2) - 4);

        if (totalBorders > palette.Count)
        {
            Debug.LogError("The map isn't big enough to handle this palette. (Map border size of " + width + "x" + height + ", generates " + totalBorders + " border tiles, but we need " + palette.Count + " tiles)");
        }
        int i = 0;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                {
                    sortedDropZones.Add(new SortedDropZone(palette[i], new(x, y)));
                    i++;
                }
            }
        }
        return sortedDropZones;
    }

    private List<Piece> GetPiecesFromImage(int subImageWidth, int subImageHeight, List<Rgb24> palette)
    {
        List<Piece> pieceList = new();

        //1. Read in input image
        //Texture2D sourceTexture = Resources.Load<Texture2D>(@"/Images/st-john-beach.jpg");
        ImageColorGroups imageProcessing = new(palette);
        //ImageStats? sourceImageStats = imageProcessing.ProcessStatsForImage(sourceImageLocation, null, false);

        //2. Split apart images/Crop the individual images next
        Image<Rgb24> sourceImg = Texture2Image(SourceTexture);
        List<Image<Rgb24>> images = ImageCropping.SplitImageIntoMultiplePieces(sourceImg, subImageWidth, subImageHeight);

        //Get image stats for each individual image and combine in one list
        List<ImageStats> subImages = new();
        foreach (Image<Rgb24> image in images)
        {
            ImageStats? subitemImageStats = imageProcessing.ProcessStatsForImage(null, image, true);
            if (subitemImageStats != null)
            {
                subImages.Add(subitemImageStats);
            }
        }

        int i = 0;
        foreach (ImageStats image in subImages)
        {
            i++;
            pieceList.Add(new Piece()
            {
                Id = i,
                Image = image.Image,
                ImageStats = image,
                Location = new System.Numerics.Vector2(2, 2)
            });
        }

        return pieceList;
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
        //SixLabors.ImageSharp.Image bmp2 = SixLabors.ImageSharp.Image.FromStream(ms);
        Image<Rgb24> myImage = SixLabors.ImageSharp.Image.Load<Rgb24>(ms.ToArray());

        //Close the stream, we no longer need it.
        ms.Close();
        ms = null;

        return (myImage);
    }

}
