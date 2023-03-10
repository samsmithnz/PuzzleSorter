using System.Collections.Generic;

namespace PuzzleSolver.Actions
{
    public class Turn
    {
        public int TurnNumber;
        public List<RobotTurnAction> RobotActions;

        public Turn(int turnNumber)
        {
            TurnNumber = turnNumber;
            RobotActions = new List<RobotTurnAction>();
        }
    }
}