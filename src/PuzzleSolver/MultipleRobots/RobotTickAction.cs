using PuzzleSolver.Map;
using PuzzleSolver.Processing;
using System.Collections.Generic;
using System.Numerics;

namespace PuzzleSolver
{
    public class RobotTickAction
    {
        public int RobotID {get;set;}
        public List<Vector2> Move { get; set; }
        public PathFindingResult PathToDropoff { get; set; }
        public ObjectInteraction DropoffAction { get; set; }
    }
}