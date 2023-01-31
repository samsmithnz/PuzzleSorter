using System;

namespace PuzzleSolver.Map
{
    public static class MapGeneration
    {
        public static string[,,] GenerateMap()
        {
            string[,,] map = MapCore.InitializeMap(5, 1, 5);
            int width = map.GetLength(0);
            int breadth = map.GetLength(2);
            int y = 0;
            for (int z = 0; z < breadth; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 && z == 0 ||
                        x == 0 && z == 2 ||
                        x == 0 && z == 4 ||
                        x == 2 && z == 0 ||
                        x == 2 && z == 4 ||
                        x == 4 && z == 0 ||
                        x == 4 && z == 2 ||
                        x == 4 && z == 4)
                    {
                        map[x, y, z] = "D"; //drop zone
                    }
                    else if (x == 2 && z == 2)
                    {
                        map[x, y, z] = "P"; //pickup zone
                    }
                }
            }
            return map;
        }

        public static void DebugPrintOutMap(string[,,] map)
        {
            int width = map.GetLength(0);
            int breadth = map.GetLength(1);
            int y = 0;
            for (int z = 0; z < breadth; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (map[x, y, z] != "")
                    {
                        Console.WriteLine(" this.map[" + x + ", " + z + "] = " + map[x, y, z] + ";");
                    }
                }
            }
        }


    }
}
