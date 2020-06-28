using System;
using System.Collections.Generic;
using ElevatorCore.Api;

namespace ElevatorCore.Implementation
{
    internal class Elevator : IElevator
    {
        public Direction Direction { get; private set; }
        public int Target { get; private set; }
        public int Current { get; private set; }

        private readonly List<int> queuedFloors = new List<int>();

        public void RequestFloor(int floor)
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
                    if(Math.Abs(floor) > Math.Abs(Target))
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