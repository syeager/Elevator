namespace ElevatorCore.Api
{
    internal interface IElevator
    {
        Direction Direction { get; }
        int Target { get; }
        int Current { get; }

        void RequestFloor(int floor);
    }
}