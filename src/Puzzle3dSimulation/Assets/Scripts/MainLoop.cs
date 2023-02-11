using Assets.Scripts.Common;
using PuzzleSolver;
using PuzzleSolver.Images;
using PuzzleSolver.Map;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainLoop : MonoBehaviour
{

    private readonly bool _showCoordOnFloor = true;
    private readonly bool _showLinesOnFloor = true;
    Queue<RobotAction> _RobotActions = null;

    // Start is called before the first frame update
    void Start()
    {
        //Setup board
        Board board = new()
        {
            Map = MapGeneration.GenerateMap(),
            UnsortedPiecesLocation = new System.Numerics.Vector2(2, 2),
            UnsortedPieces = new Queue<Piece>(new Piece[] {
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
                    }}),
            SortedDropZones = new()
            {
                new SortedDropZone(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>(),new(0, 4)),
                new SortedDropZone(SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>(),new(4, 0)),
                new SortedDropZone(SixLabors.ImageSharp.Color.Green.ToPixel<Rgb24>(),new(4, 4)),
                //new SortedDropZone(Color.Yellow.ToPixel<Rgb24>(),new(4, 4)),
            },
            Robot = new Robot(new System.Numerics.Vector2(2, 1))
        };

        //Setup map
        LevelSetup.SetupMap(gameObject, board.Map, _showLinesOnFloor, _showCoordOnFloor);

        //Add unsorted pieces
        float y = 0.25f;
        int i = 0;
        foreach (Piece piece in board.UnsortedPieces.ToList())
        {
            i++;
            GameObject newUnsortedObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newUnsortedObject.transform.position = new Vector3(2f, y, 2f);
            newUnsortedObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            newUnsortedObject.name = Utility.CreateName("piece_" + i.ToString(), newUnsortedObject.transform.position);
            //Renderer renderer = new Renderer();
            //renderer.material.color = new Color(item.R, item.G, item.B);
            if (piece != null && piece.TopColorGroup != null)
            {
                Color newColor = Utility.ConvertToUnityColor((Rgb24)piece.TopColorGroup);
                Debug.LogWarning("Color" + newColor.ToString());
                newUnsortedObject.AddComponent<Renderer>().material.color = newColor;
            }
            else
            {
                if (piece == null)
                {
                    Debug.LogWarning("Piece was null!!");
                }
                else
                {
                    Debug.LogWarning("Color was null!!");
                }
            }
            y += 0.5f;
        }

        //Run the robot
        //_RobotActions = board.RunRobot();
    }

    // Update is called once per frame
    void Update()
    {
        //if (_RobotActions != null)
        //{

        //}
    }
}
