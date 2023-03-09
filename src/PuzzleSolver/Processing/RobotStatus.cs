namespace PuzzleSolver.Processing
{
    public class RobotStatus
    {
        public enum RobotStatusEnum
        {
            NoAction = 0,
            MovingToPickup = 1,
            PickingUp = 2,
            MovingToDropoff = 3,
            DroppingOff = 4
        }
    }
}
