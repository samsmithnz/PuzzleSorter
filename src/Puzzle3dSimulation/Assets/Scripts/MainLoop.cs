using Assets.Scripts.Common;
using PuzzleSolver;
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
            UnsortedPieces = new Queue<Rgb24>(new[] {
                    SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>(),
                    SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>(),
                    SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>(),
                    SixLabors.ImageSharp.Color.Green.ToPixel<Rgb24>()
                }),
            SortedPieces = new Dictionary<Rgb24, SortedPiece>()
                {
                    { SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>(), new SortedPiece(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>(),new System.Numerics.Vector2(0, 0))},
                    { SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>(), new SortedPiece(SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>(),new System.Numerics.Vector2(0, 4))},
                    { SixLabors.ImageSharp.Color.Green.ToPixel<Rgb24>(), new SortedPiece(SixLabors.ImageSharp.Color.Green.ToPixel<Rgb24>(),new System.Numerics.Vector2(4, 0))},
                    { SixLabors.ImageSharp.Color.Yellow.ToPixel<Rgb24>(), new SortedPiece(SixLabors.ImageSharp.Color.Yellow.ToPixel<Rgb24>(),new System.Numerics.Vector2(4, 4))}
                },
            SortedPiecesCount = 0,
            Robot = new Robot(new System.Numerics.Vector2(2, 1))
        };

        //Setup map
        LevelSetup.SetupMap(gameObject, board.Map, _showLinesOnFloor, _showCoordOnFloor);

        //Add unsorted pieces
        float y = 0.5f;
        int i = 0;
        foreach (Rgb24 item in board.UnsortedPieces.ToList())
        {
            i++;
            GameObject newUnsortedObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newUnsortedObject.transform.position = new Vector3(2f, y, 2f);
            newUnsortedObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            newUnsortedObject.name = Utility.CreateName("piece_" + i.ToString(), newUnsortedObject.transform.position);
            y+=0.5f;
        }

        //Run the robot
        //_RobotActions = board.RunRobot();
    }

    // Update is called once per frame
    void Update()
    {
        if (_RobotActions != null)
        {

        }
    }
}
