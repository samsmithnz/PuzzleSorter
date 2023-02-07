using PuzzleSolver;
using PuzzleSolver.Map;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Board board = new Board()
        {
            Map = MapGeneration.GenerateMap(),
            UnsortedPiecesLocation = new System.Numerics.Vector2(2, 2),
            UnsortedPieces = new Queue<Rgb24>(new[] {
                    SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>(),
                    SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>(),
                    SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>(),
                    SixLabors.ImageSharp.Color.Green.ToPixel<Rgb24>() }),
            SortedPieces = new Dictionary<Rgb24, SortedPiece>()
                {
                    { SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>(), new(SixLabors.ImageSharp.Color.Red.ToPixel<Rgb24>(),new System.Numerics.Vector2(0, 0))},
                    { SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>(), new(SixLabors.ImageSharp.Color.Blue.ToPixel<Rgb24>(),new System.Numerics.Vector2(0, 4))},
                    { SixLabors.ImageSharp.Color.Green.ToPixel<Rgb24>(), new(SixLabors.ImageSharp.Color.Green.ToPixel<Rgb24>(),new System.Numerics.Vector2(4, 0))},
                    { SixLabors.ImageSharp.Color.Yellow.ToPixel<Rgb24>(), new(SixLabors.ImageSharp.Color.Yellow.ToPixel<Rgb24>(),new System.Numerics.Vector2(4, 4))}
                },
            SortedPiecesCount = 0,
            Robot = new Robot(new System.Numerics.Vector2(2, 1))
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
