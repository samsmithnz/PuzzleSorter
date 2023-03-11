using PuzzleSolver.Map;
using System.Numerics;
using static PuzzleSolver.Actions.RobotStatus;

namespace PuzzleSolver.Actions
{
    public class RobotAction
    {
        public int RobotId { get; set; }
        public int PieceId { get; set; }
        public RobotStatusEnum RobotStatus { get; set; }
        public Vector2 RobotPickupStartingLocation { get; set; }
        public PathFindingResult PathToPickup { get; set; }
        public ObjectInteraction PickupAction { get; set; }
        public Vector2 RobotPickupEndingLocation { get; set; }
        public Vector2 RobotDropoffStartingLocation { get; set; }
        public PathFindingResult PathToDropoff { get; set; }
        public ObjectInteraction DropoffAction { get; set; }
        public int DropoffPieceCount { get; set; }
        public Vector2 RobotDropoffEndingLocation { get; set; }
    }
}
