namespace Battle.Logic.Map
{
    public static class MapGeneration
    {
        public static string[,] GenerateMap(string[,] map)
        {
            int width = map.GetLength(0);
            int breadth = map.GetLength(2);
            int y = 0;
            for (int z = 0; z < breadth; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 && y == 0 ||
                        x == 0 && y == 2 ||
                        x == 0 && y == 4 ||
                        x == 2 && y == 0 ||
                        x == 2 && y == 4 ||
                        x == 4 && y == 0 ||
                        x == 4 && y == 2 ||
                        x == 4 && y == 4)
                    {
                        map[x, z] = "d"; //drop zone
                    }
                    else if (x == 2 && y == 2)
                    {
                        map[x, z] = "p"; //pickup zone
                    }
                }
            }
            return map;
        }

        public static void DebugPrintOutMap(string[,] map)
        {
            int width = map.GetLength(0);
            int breadth = map.GetLength(2);
            int y = 0;
            for (int z = 0; z < breadth; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (map[x, z] != "")
                    {
                        Console.WriteLine(" this.map[" + x + ", " + z + "] = " + map[x, z] + ";");
                    }
                }
            }
        }


    }
}
