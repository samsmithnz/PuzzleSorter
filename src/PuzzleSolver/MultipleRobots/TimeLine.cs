using System.Collections.Generic;

namespace PuzzleSolver.MultipleRobots
{
    public class TimeLine
    {
        public List<Tick> Ticks { get; set; }

        public TimeLine()
        {
            Ticks = new List<Tick>();
        }
    }
}
