namespace Lost.Math.Int2D
{
    using System;
    public struct Vector : IEquatable<Vector>
    {
        public Vector(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public int X { get; }
        public int Y { get; }

        #region Equality
        public static bool operator ==(Vector a, Vector b) {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Vector a, Vector b) {
            return a.X != b.X || a.Y != b.Y;
        }

        public bool Equals(Vector other) {
            return this.X == other.X && this.Y == other.Y;
        }

        public override bool Equals(object obj) {
            if (obj is Vector) {
                return this.Equals((Vector)obj);
            }

            return false;
        }

        public override int GetHashCode() => (this.X + 12347).GetHashCode() ^ this.Y.GetHashCode();
        #endregion

        public bool IsAdjacentTo(Vector other) {
            int dx = Math.Abs(this.X - other.X), dy = Math.Abs(this.Y - other.Y);
            return (dx == 0 && dy == 1)
                || (dx == 1 && dy == 0);
        }

        public override string ToString() => this.X + "; " + this.Y;

        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y);

        public Vector Direction => new Vector(Math.Sign(this.X), Math.Sign(this.Y));

        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);
    }
}
