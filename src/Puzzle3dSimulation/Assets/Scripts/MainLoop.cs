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

    private readonly bool _showCoordOnFloor = true;
    private readonly bool _showLinesOnFloor = true;
    private Queue<RobotAction> _RobotActions = null;
    private GameObject _RobotObject = null;

    // Start is called before the first frame update
    void Start()
    {
        //Setup board
        Board board = new(MapGeneration.GenerateMap(),
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
        LevelSetup.SetupMap(gameObject, board.Map, _showLinesOnFloor, _showCoordOnFloor);

        Piece[] unsortedList = new Piece[board.UnsortedPieces.Count];
        board.UnsortedPieces.ToList().CopyTo(unsortedList);

        //Get the robot actions
        _RobotActions = board.RunRobot();

        //Add unsorted pieces
        float y = 0.25f;
        int i = 0;
        Debug.LogWarning("There are " + unsortedList.Count().ToString() + " unsorted pieces to process");
        foreach (Piece piece in unsortedList)
        {
            i++;
            //Debug.LogWarning("Adding piece " + piece.Id);
            GameObject newUnsortedObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newUnsortedObject.transform.position = new Vector3(2f, y, 2f);
            newUnsortedObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            newUnsortedObject.name = Utility.CreateName("piece_" + i.ToString(), newUnsortedObject.transform.position);
            if (piece != null && piece.TopColorGroup != null)
            {
                Color newColor = Utility.ConvertToUnityColor((Rgb24)piece.TopColorGroup);
                //Debug.LogWarning("Color" + newColor.ToString());
                newUnsortedObject.GetComponent<Renderer>().material.color = newColor;
            }
            y += 0.5f;
        }

        //Add the robot
        _RobotObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        _RobotObject.transform.position = new Vector3(board.Robot.Location.X, 0.5f, board.Robot.Location.Y);
        _RobotObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        _RobotObject.name = "robot";
        _RobotObject.GetComponent<Renderer>().material.color = Color.gray; //dark gray

        //objects carried at at y 1.25


        if (_RobotActions != null && _robotActionInProgress == false)
        {
            if (_RobotActions.Count > 0 &&
                _MovingToPickup == false &&
                _PickingUpAction == false &&
                _MovingToDropoff == false &&
                _DroppingOffAction == false)
            {
                while (_RobotActions.Count > 0)
                {
                    //Get a robot action from the queue
                    _robotAction = _RobotActions.Dequeue();
                    _ActionCount++;
                    Debug.LogWarning("Action #" + _ActionCount + " processing");

                    //Move to pickup zone
                    _MovingToPickup = true;
                    StartCoroutine(MoveToLocation(_RobotObject, _robotAction.PathToPickup));
                    _MovingToPickup = false;

                    //Pickup piece
                    _PickingUpAction = true;
                    PickUpPiece(_robotAction.PickupAction);
                    _PickingUpAction = false;

                    //Move to drop off zone
                    _MovingToDropoff = true;
                    StartCoroutine(MoveToLocation(_RobotObject, _robotAction.PathToDropoff));
                    _MovingToDropoff = false;

                    //Drop piece
                    _DroppingOffAction = true;
                    DropOffPiece(_robotAction.DropoffAction);
                    _DroppingOffAction = false;

                }
            }
        }
    }

    private bool _robotActionInProgress = false;
    private RobotAction _robotAction = null;
    private bool _MovingToPickup = false;
    private bool _PickingUpAction = false;
    private bool _MovingToDropoff = false;
    private bool _DroppingOffAction = false;
    private int _ActionCount = 0;

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator MoveToLocation(GameObject robotObject, System.Numerics.Vector2 startLocation, PathFindingResult path)
    {
        if (path != null && path.GetLastTile() != null)
        {
            Debug.LogWarning("Moving to location " + path.GetLastTile().Location.ToString());

            Movement movementScript = robotObject.GetComponent<Movement>();
            if (movementScript == null)
            {
                movementScript = robotObject.AddComponent<Movement>();
            }
            Utility.LogWithTime("Starting movement");
            yield return StartCoroutine(movementScript.MoveRobot(robotObject, startLocation, path));
        }
        else
        {
            Debug.LogWarning("No movement needed - at end location");
        }
    }

    private void PickUpPiece(ObjectInteraction pickupAction)
    {
        Debug.LogWarning("Picking up piece " + pickupAction.Location.ToString());
    }

    private void DropOffPiece(ObjectInteraction dropOffAction)
    {
        Debug.LogWarning("Dropping off piece " + dropOffAction.Location.ToString());
    }

}
