using System.Collections.Generic;

namespace PuzzleSolver.Actions
{
    public class TimeLine
    {
        public List<Turn> Turns { get; set; }

        public TimeLine()
        {
            Turns = new List<Turn>();
        }
    }
}
