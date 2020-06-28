using ElevatorCore.Api;

namespace ElevatorCore.Implementation
{
    internal class Elevator: IElevator
    {
        public Direction Direction { get; private set; }
        public int Target { get; private set; }
        public int Current { get; private set; }

        public void RequestFloor(int floor)
        {
            Target = floor;
            Direction = DirectionUtility.GetDirection(Current, Target);
        }
    }
}