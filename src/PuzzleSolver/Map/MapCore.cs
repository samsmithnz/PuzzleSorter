using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace PuzzleSolver.Map
{
    public static class MapCore
    {
        /// <summary>
        /// Initialize a map array
        /// </summary>
        /// <param name="xMax">x size</param>
        /// <param name="zMax">z size</param>
        /// <param name="initialString">The initial string to initialize the map with - usually ""</param>
        /// <returns>The populated map/array</returns>
        public static string[,] InitializeMap(int xMax, int zMax, string initialString = "")
        {
            string[,] map = new string[xMax, zMax];

            //Initialize the map
            int y = 0;
            for (int z = 0; z < zMax; z++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    map[x, z] = initialString;
                }
            }

            return map;
        }


        public static List<Vector2> GetMapArea(string[,] map, Vector2 sourceLocation, int range, bool lookingForFOV = true, bool includeSourceLocation = false)
        {
            int startingX = (int)sourceLocation.X;
            int startingZ = (int)sourceLocation.Y;

            //Use the range to find the borders in each primary direction from the starting location
            int minX = startingX - range;
            if (minX < 0)
            {
                minX = 0;
            }
            int maxX = startingX + range;
            if (maxX > map.GetLength(0) - 1)
            {
                maxX = map.GetLength(0) - 1;
            }
            int minZ = startingZ - range;
            if (minZ < 0)
            {
                minZ = 0;
            }
            int maxZ = startingZ + range;
            if (maxZ > map.GetLength(2) - 1)
            {
                maxZ = map.GetLength(2) - 1;
            }

            //Get a list of all border squares
            HashSet<Vector2> borderTiles = new HashSet<Vector2>();
            //Add the top and bottom rows
            for (int x = minX; x <= maxX; x++)
            {
                borderTiles.Add(new Vector2(x,minZ));
                borderTiles.Add(new Vector2(x,maxZ));
            }
            //Add the left and right sides
            for (int z = minZ; z < maxZ; z++)
            {
                borderTiles.Add(new Vector2(minX,z));
                borderTiles.Add(new Vector2(maxX,z));
            }

            //For each border tile, draw a line from the starting point to the border
            HashSet<Vector2> results = new HashSet<Vector2>();
            //foreach (Vector2 borderItem in borderTiles)
            //{
            //    List<Vector2> singleLineCheck = FieldOfView.GetPointsOnLine(new Vector2(startingX,startingZ), borderItem);
            //    if (singleLineCheck.Count > 0 &&
            //        singleLineCheck[singleLineCheck.Count - 1].X == startingX &&
            //        singleLineCheck[singleLineCheck.Count - 1].Z == startingZ)
            //    {
            //        //Reverse the list, so that items are in order from source to destination
            //        singleLineCheck.Reverse();
            //    }
            //    double lineLength = GetLengthOfLine(singleLineCheck[0], singleLineCheck[singleLineCheck.Count - 1], 1);
            //    double lineSegment = lineLength / singleLineCheck.Count;
            //    double currentLength = 0;
            //    for (int i = 0; i < singleLineCheck.Count; i++)
            //    {
            //        currentLength += lineSegment;
            //        Vector2 fovItem = singleLineCheck[i];
            //        if (fovItem.X >= 0 && fovItem.Y >= 0 && fovItem.Z >= 0)
            //        {
            //            //If we find an object, stop adding tiles
            //            if (lookingForFOV && map[(int)fovItem.X, (int)fovItem.Y, (int)fovItem.Z] == CoverType.FullCover)
            //            {
            //                //Add the wall
            //                results.Add(fovItem);
            //                //Then break!
            //                break;
            //            }
            //            else if ((int)fovItem.X == startingX && (int)fovItem.Z == startingZ)
            //            {
            //                //Don't add this one, it's the origin/ where the character is looking from
            //            }
            //            else
            //            {
            //                results.Add(fovItem);
            //            }
            //        }
            //        //We don't round, so this will extend the range a tiny part - but I think that is ok.
            //        if (currentLength >= range)
            //        {
            //            break;
            //        }
            //    }
            //}
            if (includeSourceLocation)
            {
                results.Add(sourceLocation);
            }

            return results.ToList();
        }

        public static double GetLengthOfLine(Vector2 start, Vector2 end, int decimals = 0)
        {
            double lineLength = Math.Sqrt(Math.Pow((end.X - start.X), 2) + Math.Pow((end.Y - start.Y), 2));
            return Math.Round(lineLength, decimals);
        }

        public static string GetMapString(string[,] map, bool stripOutBlanks = false)
        {
            int xMax = map.GetLength(0);
            int zMax = map.GetLength(2);
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            int y = 0;
            for (int z = zMax - 1; z >= 0; z--)
            {
                StringBuilder sbLine = new StringBuilder();
                for (int x = 0; x < xMax; x++)
                {
                    if (map[x, z] != "")
                    {
                        sbLine.Append(map[x, z] + " ");
                    }
                    else
                    {
                        sbLine.Append(". ");
                    }
                }
                sbLine.Append(Environment.NewLine);
                //If there is nothing on the map line, don't display it.
                //This optimizes the ASCII maps to remove white space
                if (stripOutBlanks)
                {
                    int dotCount = sbLine.ToString().Split('.').Count() - 1;
                    if (dotCount < xMax)
                    {
                        sb.Append(sbLine.ToString());
                    }
                }
                else
                {
                    sb.Append(sbLine.ToString());
                }
            }
            return sb.ToString();
        }

        public static string[,] ApplyListToMap(string[,] map, List<Vector2> list, string tile)
        {
            foreach (Vector2 item in list)
            {
                //Check that the square is empty - we don't want to overwrite something that exists and only put a tile on an unused tile
                if (map[(int)item.X, (int)item.Y] == "")
                {
                    map[(int)item.X, (int)item.Y] = tile;
                }
            }
            return map;
        }

        public static string[,] ApplyListToExistingMap(string[,] map, List<Vector2> list, string tile)
        {
            foreach (Vector2 item in list)
            {
                map[(int)item.X, (int)item.Y] = tile;
            }
            return map;
        }

        public static string GetMapStringWithItems(string[,] map, List<Vector2> list)
        {
            string[,] mapNew = MapCore.ApplyListToMap((string[,])map.Clone(), list, "o");
            string mapString = MapCore.GetMapString(mapNew);
            return mapString;
        }

        public static string GetMapStringWithItemLayers(string[,] map, List<Vector2> baseList, List<Vector2> overlayList)
        {
            string[,] mapNew = MapCore.ApplyListToMap((string[,])map.Clone(), baseList, "o");
            mapNew = MapCore.ApplyListToExistingMap(mapNew, overlayList, "O");

            string mapString = MapCore.GetMapString(mapNew);
            return mapString;
        }

        public static string GetMapStringWithMapMask(string[,] map, string[,] mapMask)
        {
            int xMax = map.GetLength(0);
            //int yMax = map.GetLength(1);
            int zMax = map.GetLength(2);
            int xMaskMax = map.GetLength(0);
            //int yMaskMax = map.GetLength(1);
            int zMaskMax = map.GetLength(2);
            if (xMax != xMaskMax && zMax != zMaskMax)
            {
                throw new Exception("Mask map is not the same size as the parent map");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            int y = 0;
            for (int z = zMax - 1; z >= 0; z--)
            {
                for (int x = 0; x < xMax; x++)
                {
                    if (mapMask[x, z] != "")
                    {
                        sb.Append(mapMask[x, z] + " ");
                    }
                    else
                    {
                        if (map[x, z] != "")
                        {
                            sb.Append(map[x, z] + " ");
                        }
                        else
                        {
                            sb.Append(". ");
                        }
                    }
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public static List<Vector2> FindAdjacentTile(string[,] map, Vector2 currentLocation, string tileToFind)
        {
            int width = map.GetLength(0);
            //int height = map.GetLength(1);
            int breadth = map.GetLength(2);
            List<Vector2> result = new List<Vector2>();

            //Make adjustments to ensure that the search doesn't go off the edges of the map
            int xMin = Convert.ToInt32(currentLocation.X) - 1;
            if (xMin < 0)
            {
                xMin = 0;
            }
            int xMax = Convert.ToInt32(currentLocation.X) + 1;
            if (xMax > width - 1)
            {
                xMax = width - 1;
            }
            int zMin = Convert.ToInt32(currentLocation.Y) - 1;
            if (zMin < 0)
            {
                zMin = 0;
            }
            int zMax = Convert.ToInt32(currentLocation.Y) + 1;
            if (zMax > breadth - 1)
            {
                zMax = breadth - 1;
            }

            //Get possible tiles, within constraints of map, including only square titles from current position (not diagonally)
            if (map[Convert.ToInt32(currentLocation.X), zMax] == tileToFind)
            {
                result.Add(new Vector2(currentLocation.X, zMax));
            }
            if (map[xMax, Convert.ToInt32(currentLocation.Y)] == tileToFind)
            {
                result.Add(new Vector2(xMax, currentLocation.Y));
            }
            if (map[Convert.ToInt32(currentLocation.X), zMin] == tileToFind)
            {
                result.Add(new Vector2(currentLocation.X, zMin));
            }
            if (map[xMin, Convert.ToInt32(currentLocation.Y)] == tileToFind)
            {
                result.Add(new Vector2(xMin, currentLocation.Y));
            }
            return result;
        }
    }
}
