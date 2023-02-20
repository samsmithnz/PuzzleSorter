using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace PuzzleSolver
{
    public class SortedDropZone
    {
        public Rgb24 Color { get; set; }
        public Vector2 Location { get; set; }
        public int Count { get; set; }

        public SortedDropZone(Rgb24 color, Vector2 location)
        {
            Color = color;
            Location = location;
            Count = 0;
        }

        public List<SortedDropZone> GetSortedDropZones(string[,] map, List<Rgb24> palette)
        {
            List<SortedDropZone> sortedDropZones = new List<SortedDropZone>();
            int width = map.GetLength(0);
            int height = map.GetLength(1);
            int totalBorderTiles = (width * 2) + ((height * 2) - 4 - 4);

            if (totalBorderTiles < palette.Count)
            {
                throw new Exception("The map isn't big enough to handle this palette. (Map border size of " + width + "x" + height + ", generates " + totalBorderTiles + " border tiles, but we need " + palette.Count + " tiles)");
            }
            int i = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //Find a border tile, that is NOT a corner.
                    if ((x == 0 || y == 0 || x == width - 1 || y == height - 1) &&
                        x != 0 && y != 0 &&
                        x != 0 && y != height - 1 &&
                        x != width - 1 && y != 0 &&
                        x != width - 1 && y != height - 1)
                    {
                        sortedDropZones.Add(new SortedDropZone(palette[i], new(x, y)));
                        i++;
                    }
                    if (i >= palette.Count)
                    {
                        break;
                    }
                }
            }
            return sortedDropZones;
        }
    }
}
