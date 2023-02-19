using System;
using System.Numerics;

namespace PuzzleSolver.Map
{
    public static class MapGeneration
    {
        public static string[,] GenerateMap(int width = 5, int height = 5)
        {
            string[,] map = MapCore.InitializeMap(width, height);
            //get the center
            Vector2 centerPointLocation = GetCenterPointLocation(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //if (x == 0 && y == 0 ||
                    //    x == 0 && y == 2 ||
                    //    x == 0 && y == 4 ||
                    //    x == 2 && y == 0 ||
                    //    x == 2 && y == 4 ||
                    //    x == 4 && y == 0 ||
                    //    x == 4 && y == 2 ||
                    //    x == 4 && y == 4)
                    //{
                    //    //map[x, y] = "D"; //drop zone
                    //}
                    //else 
                    if (x == centerPointLocation.X && y == centerPointLocation.Y)
                    {
                        map[x, y] = "P"; //pickup zone
                    }
                }
            }
            return map;
        }

        public static void DebugPrintOutMap(string[,] map)
        {
            int width = map.GetLength(0);
            int height = map.GetLength(1);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (map[x, y] != "")
                    {
                        Console.WriteLine(" this.map[" + x + ", " + y + "] = " + map[x, y] + ";");
                    }
                }
            }
        }

        public static Vector2 GetCenterPointLocation(int width, int height)
        {
            int centerX = (int)Math.Floor(width / 2M);
            int centerY = (int)Math.Floor(height / 2M);
            return new Vector2(centerX, centerY);
        }


    }
}
