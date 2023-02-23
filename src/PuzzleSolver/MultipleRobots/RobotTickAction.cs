using PuzzleSolver.Map;
using PuzzleSolver.Processing;
using System.Collections.Generic;
using System.Numerics;

namespace PuzzleSolver
{
    public class RobotTickAction
    {
        public int RobotID { get; set; }
        public List<Vector2> Movement { get; set; } = null;
        public ObjectInteraction Action { get; set; } = null;
    }
}