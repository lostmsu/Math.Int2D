namespace Lost.Math.Int2D
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Represents direction on an integer 2D plane.
    /// One of: <see cref="Right"/>, <see cref="Down"/>, <see cref="Left"/>, and <see cref="Up"/>.
    /// </summary>
    public struct Direction: IEquatable<Direction>
    {
        readonly int value;

        public Direction(int value) => this.value = value & 3;

        public static readonly Direction Right = new Direction(0);
        public static readonly Direction Down = new Direction(1);
        public static readonly Direction Left = new Direction(2);
        public static readonly Direction Up = new Direction(3);

        [Pure]
        public Direction TurnLeft() => new Direction(this.value - 1);
        [Pure]
        public Direction TurnLeft(int times) => new Direction(this.value - times);
        [Pure]
        public Direction TurnRight() => new Direction(this.value + 1);
        [Pure]
        public Direction TurnRight(int times) => new Direction(this.value + times);

        /// <summary>
        /// How many times someone facing <see cref="Right"/> must <see cref="TurnRight"/> to face this way
        /// </summary>
        public static explicit operator int(Direction direction) => direction.value;

        /// <summary>
        /// Finds number of _right_ turns, needed to convert the second direction into the first direction.
        /// </summary>
        public static int operator -(Direction a, Direction b) => a.value - b.value;

        static readonly Vector[] Deltas = {
            // right
            new Vector(x: 1, y: 0),
            // down
            new Vector(x: 0, y: 1),
            // left
            new Vector(x: -1, y: 0),
            // up
            new Vector(x: 0, y: -1),
        };

        /// <summary>
        /// Returns vector of length 1 with the current direction.
        /// </summary>
        public Vector Vector => Deltas[this.value];

        #region Equality
        public bool Equals(Direction other) => this == other;
        public override bool Equals(object obj) => obj is Direction other ? other == this : false;
        public override int GetHashCode() => this.value.GetHashCode();
        /// <summary>
        /// Checks if two directions are equal
        /// </summary>
        public static bool operator ==(Direction a, Direction b) => a.value == b.value;

        /// <summary>
        /// Checks if two directions are not equal
        /// </summary>
        public static bool operator !=(Direction a, Direction b) => a.value != b.value;
        #endregion
    }
}
