using System.Numerics;

namespace PuzzleSolver.Processing
{
    public class Robot
    {
        public int RobotId { get; set; }
        public Vector2 Location { get; set; }
        public Piece Piece { get; set; }

        public Robot(int robotId, Vector2 location)
        {
            RobotId = robotId;
            Location = location;
        }
    }
}
