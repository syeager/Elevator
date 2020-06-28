namespace ElevatorCore.Api
{
    internal interface IElevator
    {
        Direction Direction { get; }
        Floor Target { get; }
        Floor Current { get; }

        void RequestFloor(Floor floor);
    }
}