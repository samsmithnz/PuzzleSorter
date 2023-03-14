namespace PuzzleSolver.Actions
{
    public class RobotStatus
    {
        public enum RobotStatusEnum
        {
            LookingForJob = 0,
            MovingToPickupLocation = 1,
            PickingUpPackage = 2,
            MovingToDeliveryLocation = 3,
            DeliveringPackage = 4
        }
    }
}
