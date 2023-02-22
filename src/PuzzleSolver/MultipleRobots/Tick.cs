using System.Collections.Generic;

namespace PuzzleSolver
{
    public class Tick
    {
        public int TickNumber;
        public List<RobotTickAction> RobotActions;

        public Tick(int tickNumber)
        {
            TickNumber = tickNumber;
            RobotActions = new List<RobotTickAction>();
        }
    }
}