using PuzzleSolver.Processing;
using System.Collections.Generic;
using System.Numerics;

namespace PuzzleSolver
{
    public class RobotTickAction
    {
        public int RobotId { get; set; }
        public int? PieceId { get; set; }
        public List<Vector2> Movement { get; set; } = null;
        public ObjectInteraction PickupAction { get; set; } = null;
        public ObjectInteraction DropoffAction { get; set; } = null;

        public RobotTickAction(int robotId, int pieceId)
        {
            RobotId = robotId;
            PieceId = pieceId;
        }
    }
}