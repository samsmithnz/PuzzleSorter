﻿using PuzzleSolver.Map;

namespace PuzzleSolver
{
    public class RobotAction
    {
        public PathFindingResult PathToPickup { get; set; }
        public ObjectInteraction PickupAction { get; set; }
        public PathFindingResult PathToDropoff { get; set; }
        public ObjectInteraction DropoffAction { get; set; }
    }
}