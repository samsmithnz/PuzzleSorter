using System.Collections.Generic;

namespace PuzzleSolver.Actions
{
    public class Turn
    {
        public int TurnNumber { get; set; }
        public List<RobotTurnAction> RobotActions { get; set; }

        public Turn(int turnNumber)
        {
            TurnNumber = turnNumber;
            RobotActions = new List<RobotTurnAction>();
        }

        public RobotTurnAction GetRobotTurnAction(int robotId)
        {
            RobotTurnAction result = null;
            foreach (RobotTurnAction item in RobotActions)
            {
                if (item.RobotId == robotId)
                {
                    result = item;
                    break;
                }
            }
            return result;
        }
    }
}