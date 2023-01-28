using System.Collections.Generic;
using System.Numerics;

namespace Battle.Logic.Map
{
    public static class MovementPossibileTiles
    {
        public static List<KeyValuePair<Vector2, int>> GetMovementPossibileTiles(string[,,] map, Vector2 sourceLocation, int range, int actionPoints)
        {
            List<KeyValuePair<Vector2, int>> results = new List<KeyValuePair<Vector2, int>>();
            List<Vector2> verifiedTiles = new List<Vector2>();
            //Loop through the action points from 1 to n
            for (int i = 1; i <= actionPoints; i++)
            {
                //Get a list of possible tiles for this range
                List<Vector2> possibleTiles = MapCore.GetMapArea(map, sourceLocation, range * i, false);
                foreach (Vector2 item in possibleTiles)
                {
                    //Find a path to this target location
                    PathFindingResult result = PathFinding.FindPath(map, sourceLocation, item);
                    //If we could find a path, the cost of the path is within the range, and we haven't already identified a route to this tile, add it
                    if (result.Tiles.Count > 0 && result.Tiles[result.Tiles.Count - 1].TraversalCost <= range * i && !verifiedTiles.Contains(item))
                    {
                        //The current tile isn't tracked, add it as a verified tile
                        verifiedTiles.Add(item);
                        //Add the verified tile and the action points to reach the tile
                        results.Add(new KeyValuePair<Vector2, int>(item, i));
                    }
                }
            }
            return results;
        }

        //Convert the key value pair of location and action points to a list of locations (stripping off the action points)
        public static List<Vector2> ExtractVectorListFromKeyValuePair(List<KeyValuePair<Vector2, int>> list, int filter = 0)
        {
            List<Vector2> results = new List<Vector2>();
            foreach (KeyValuePair<Vector2, int> item in list)
            {
                if (filter == 0)
                {
                    results.Add(item.Key);
                }
                else if (item.Value == filter)
                {
                    results.Add(item.Key);
                }
            }
            return results;
        }
    }
}
