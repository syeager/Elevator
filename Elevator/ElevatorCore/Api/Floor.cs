using System;

namespace ElevatorCore.Api
{
    public readonly struct Floor : IEquatable<Floor>
    {
        public static readonly Floor NotValid = new Floor(0, false);

        private readonly int value;
        private readonly bool isValid;

        public int AbsValue { get; }

        public Floor(int value)
            : this(value, true)
        {
        }

        private Floor(int value, bool isValid)
        {
            this.value = value;
            this.isValid = isValid;

            AbsValue = Math.Abs(value);
        }

        public bool Equals(Floor other)
        {
            return isValid && other.isValid && value == other.value;
        }

        public override bool Equals(object obj)
        {
            return obj is Floor other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(value, isValid);
        }

        public static int operator -(Floor a, Floor b)
        {
            return a.value - b.value;
        }
    }
}