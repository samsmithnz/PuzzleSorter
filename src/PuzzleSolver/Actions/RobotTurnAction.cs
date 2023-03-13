using System.Collections.Generic;
using System.Numerics;
using static PuzzleSolver.Actions.RobotStatus;

namespace PuzzleSolver.Actions
{
    public class RobotTurnAction
    {
        public int RobotId { get; set; }
        public int? PieceId { get; set; }
        public RobotStatusEnum RobotStatus { get; set; } = RobotStatusEnum.LookingForJob;
        public List<Vector2> Movement { get; set; } = null;
        public List<Vector2> PathRemaining { get; set; } = null;
        public ObjectInteraction PickupAction { get; set; } = null;
        public ObjectInteraction DropoffAction { get; set; } = null;

        public RobotTurnAction(int robotId, RobotStatusEnum robotStatus, int? pieceId)
        {
            RobotId = robotId;
            RobotStatus = robotStatus;
            PieceId = pieceId;
        }

    }
}