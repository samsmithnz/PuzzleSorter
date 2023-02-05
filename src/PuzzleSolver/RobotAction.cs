using PuzzleSolver.Map;

namespace PuzzleSolver
{
    public class RobotAction
    {
        public ObjectInteraction PickupAction { get; set; }
        public PathFindingResult MovementPath { get; set; }
        public ObjectInteraction DropoffAction { get; set; }
    }
}
