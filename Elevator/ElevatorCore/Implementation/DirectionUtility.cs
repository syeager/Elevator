using ElevatorCore.Api;

namespace ElevatorCore.Implementation
{
    public static class DirectionUtility
    {
        public static Direction GetDirection(Floor current, Floor target)
        {
            var delta = target - current;
            if(delta == 0)
            {
                return Direction.None;
            }

            return delta < 0 ? Direction.Down : Direction.Up;
        }
    }
}