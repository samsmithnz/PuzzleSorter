using PuzzleSolver.Map;
using System.Numerics;

namespace PuzzleSolver
{
    public class RobotAction
    {
        public int PieceId { get; set; }
        
        public Vector2 RobotPickupStartingLocation { get; set; }
        public PathFindingResult PathToPickup { get; set; }
        public ObjectInteraction PickupAction { get; set; }
        public Vector2 RobotPickupEndingLocation { get; set; }

        public Vector2 RobotDropoffStartingLocation { get; set; }
        public PathFindingResult PathToDropoff { get; set; }
        public ObjectInteraction DropoffAction { get; set; }
        public Vector2 RobotDropoffEndingLocation { get; set; }
    }
}
