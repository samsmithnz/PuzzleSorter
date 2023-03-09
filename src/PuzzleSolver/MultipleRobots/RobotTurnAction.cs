using PuzzleSolver.Processing;
using System.Collections.Generic;
using System.Numerics;
using static PuzzleSolver.Processing.RobotStatus;

namespace PuzzleSolver
{
    public class RobotTurnAction
    {
        public int RobotId { get; set; }
        public int? PieceId { get; set; }
        public RobotStatusEnum RobotStatus { get; set; } = RobotStatusEnum.NoAction;
        public List<Vector2> Movement { get; set; } = null;
        public ObjectInteraction PickupAction { get; set; } = null;
        public ObjectInteraction DropoffAction { get; set; } = null;

        public RobotTurnAction(int robotId, int? pieceId)
        {
            RobotId = robotId;
            PieceId = pieceId;
        }

    }
}