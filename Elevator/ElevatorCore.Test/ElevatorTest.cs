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

        [Test]
        public void RequestFloor_Empty_MoveToFloor()
        {
            var targetFloor = new Floor(1);

            testObj.RequestFloor(targetFloor);

            Assert.AreEqual(Direction.Up, testObj.Direction);
            Assert.AreEqual(targetFloor, testObj.Target);
        }

        [Test]
        public void RequestFloor_SameFloor_DontAccept()
        {
            testObj.RequestFloor(testObj.Current);

            Assert.AreEqual(Floor.NotValid, testObj.Target);
        }

        [TestCase(1)]
        [TestCase(-1)]
        public void RequestFloor_NotEmptySameDirectionBeforeTarget_ChangeTarget(int floor)
        {
            var initial = new Floor(floor * 2);
            var target = new Floor(floor);
            
            testObj.RequestFloor(initial);
            testObj.RequestFloor(target);

            Assert.AreEqual(target, testObj.Target);
        }

        [TestCase(1)]
        [TestCase(-1)]
        public void RequestFloor_NotEmptySameDirectionAfterTarget_QueueFloor(int floor)
        {
            var initial = new Floor(floor);
            var target = new Floor(floor * 2);

            testObj.RequestFloor(initial);
            testObj.RequestFloor(target);

            Assert.AreEqual(initial, testObj.Target);
        }
        
        [TestCase(1)]
        [TestCase(-1)]
        public void RequestFloor_NotEmptyDifferentDirection_QueueFloor(int floor)
        {
            var initial = new Floor(floor);
            var target = new Floor(-floor);

            testObj.RequestFloor(initial);
            testObj.RequestFloor(target);

            Assert.AreEqual(initial, testObj.Target);
        }
    }
}