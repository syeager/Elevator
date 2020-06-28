using ElevatorCore.Api;
using ElevatorCore.Implementation;
using NUnit.Framework;

namespace ElevatorCore.Test
{
    public class ElevatorTest
    {
        private Elevator testObj;

        [SetUp]
        public void SetUp()
        {
            testObj = new Elevator();
        }

        // request floor, non-empty stack + same direction + after target, queue floor
        // request floor, non-empty stack + different direction, queue floor
        // request floor, same floor, don't queue

        [Test]
        public void RequestFloor_Empty_MoveToFloor()
        {
            const int targetFloor = 1;

            testObj.RequestFloor(targetFloor);

            Assert.AreEqual(Direction.Up, testObj.Direction);
            Assert.AreEqual(targetFloor, testObj.Target);
        }

        [TestCase(1)]
        [TestCase(-1)]
        public void RequestFloor_NotEmptySameDirectionBeforeTarget_ChangeTarget(int floor)
        {
            var initialFloor = floor * 2;
            
            testObj.RequestFloor(initialFloor);
            testObj.RequestFloor(floor);

            Assert.AreEqual(floor, testObj.Target);
        }
    }
}