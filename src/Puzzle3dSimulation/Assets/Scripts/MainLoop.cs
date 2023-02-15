using Assets.Scripts.Common;
using PuzzleSolver;
using PuzzleSolver.Images;
using PuzzleSolver.Map;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainLoop : MonoBehaviour
{

    private readonly bool _ShowCoordOnFloor = true;
    private readonly bool _ShowLinesOnFloor = true;
    private Queue<RobotAction> _RobotActions = null;
    private GameObject _RobotObject = null;
    private bool _ProcessingQueueItem = false;
    private int _ActionCount = 0;
    private Board _Board = null;

    // Start is called before the first frame update
    void Start()
    {
        //Setup board
        _Board = new(MapGeneration.GenerateMap(),
            new System.Numerics.Vector2(2, 2),
            ColorPalettes.Get3ColorPalette(),
            new List<Piece>() {
                    new Piece() {
                        Id = 1,
                        Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>()),
                        Location = new(2, 2)
                    },
                    new Piece() {
                        Id = 2,
                        Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>()),
                        Location = new(2, 2)
                    },
                    new Piece() {
                        Id = 3,
                        Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>()),
                        Location = new(2, 2)
                    },
                    new Piece() {
                        Id = 4,
                        Image = ImageCropping.CreateImage(SixLabors.ImageSharp.Color.Green.ToPixel<Rgb24>()),
                        Location = new(2, 2)
                    }
            },
            new()
            {
                new SortedDropZone(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>(), new(0, 4)),
                new SortedDropZone(SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>(), new(4, 0)),
                new SortedDropZone(SixLabors.ImageSharp.Color.Yellow.ToPixel<Rgb24>(), new(4, 4)),
                //new SortedDropZone(Color.Yellow.ToPixel<Rgb24>(),new(4, 4)),
            },
            new Robot(new System.Numerics.Vector2(2, 1)));

        //Setup map
        LevelSetup.SetupMap(gameObject, _Board.Map, _ShowLinesOnFloor, _ShowCoordOnFloor);

        Piece[] unsortedList = new Piece[_Board.UnsortedPieces.Count];
        _Board.UnsortedPieces.ToList().CopyTo(unsortedList);

        //Get the robot actions
        _RobotActions = _Board.RunRobot();

        //Add unsorted pieces
        float y = 0.25f + (0.5f * unsortedList.Length) - 0.5f; //Add the pieces in reverse, so the first item in the queue is also the top of the stack
        int i = 0;
        Debug.LogWarning("There are " + unsortedList.Count().ToString() + " unsorted pieces to process");
        foreach (Piece piece in unsortedList)
        {
            i++;
            //Debug.LogWarning("Adding piece " + piece.Id);
            GameObject pieceObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            pieceObject.transform.position = new Vector3(2f, y, 2f);
            pieceObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            pieceObject.name = "piece_" + i.ToString();
            if (piece != null && piece.TopColorGroup != null)
            {
                Color newColor = Utility.ConvertToUnityColor((Rgb24)piece.TopColorGroup);
                //Debug.LogWarning("Color" + newColor.ToString());
                pieceObject.GetComponent<Renderer>().material.color = newColor;
            }
            y -= 0.5f;
        }

        //Add the robot
        _RobotObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        _RobotObject.transform.position = new Vector3(_Board.Robot.Location.X, 0.5f, _Board.Robot.Location.Y);
        _RobotObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        _RobotObject.name = "robot";
        _RobotObject.GetComponent<Renderer>().material.color = Color.gray; //dark gray
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
            if (startingY < 0.25f)
            {
                startingY = 0.25f;
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
            float endingY = 0.25f + (0.5f * robotAction.DropoffPieceCount) -0.5f;
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
            new Vector3(pieceObject.transform.position.x, 1.25f, _RobotObject.transform.position.z),
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
        float midPointY = 2f;
        if (endingY > midPointY)
        {
            midPointY = endingY;
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
            new Vector3(pieceObject.transform.position.x, 1.25f, _RobotObject.transform.position.z),
            //raise piece off robot
            new Vector3(pieceObject.transform.position.x, midPointY, _RobotObject.transform.position.z),
            //move above destination pile
            new Vector3(pieceObject.transform.position.x, midPointY, pieceObject.transform.position.z),
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

}
