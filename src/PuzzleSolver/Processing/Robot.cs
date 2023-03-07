using System.Numerics;

namespace PuzzleSolver.Processing
{
    public class Robot
    {
        public int RobotId { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 PickupLocation { get; set; }
        public Piece Piece { get; set; }
        public RobotStatusEnum RobotStatus { get; set; } = RobotStatusEnum.None;

        public Robot(int robotId, Vector2 pickupLocation, Vector2 location)
        {
            RobotId = robotId;
            PickupLocation = pickupLocation;
            Location = location;
        }

        public enum RobotStatusEnum
        {
            None,
            MovingToPickup,
            PickingUp,
            MovingToDropoff,
            DroppingOff
        }
    }
}
