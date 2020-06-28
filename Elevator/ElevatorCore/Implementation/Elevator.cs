using System.Collections.Generic;
using ElevatorCore.Api;

namespace ElevatorCore.Implementation
{
    internal class Elevator : IElevator
    {
        public Direction Direction { get; private set; }
        public Floor Target { get; private set; }
        public Floor Current { get; private set; }

        private readonly List<Floor> queuedFloors = new List<Floor>();

        public void RequestFloor(Floor floor)
        {
            var direction = DirectionUtility.GetDirection(Current, floor);
            if(Direction == Direction.None)
            {
                Direction = direction;
                Target = floor;
            }
            else
            {
                if(direction == Direction)
                {
                    if(floor.AbsValue > Target.AbsValue)
                    {
                        queuedFloors.Add(floor);
                    }
                    else
                    {
                        queuedFloors.Add(Target);
                        Target = floor;
                    }
                }
                else
                {
                    queuedFloors.Add(floor);
                }
            }
        }
    }
}