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

        public static readonly Vector Zero = new Vector();

        #region Equality
        public static bool operator ==(Vector a, Vector b) => a.X == b.X && a.Y == b.Y;

        public static bool operator !=(Vector a, Vector b) => a.X != b.X || a.Y != b.Y;

        public bool Equals(Vector other) => this.X == other.X && this.Y == other.Y;

        public override bool Equals(object obj) => obj is Vector && this.Equals((Vector)obj);

        public override int GetHashCode() => (this.X + 12347).GetHashCode() ^ this.Y.GetHashCode();
        #endregion

        /// <summary>
        /// Checks if distance to <paramref name="other"/> is exactly 1 (means its next horizontally or vertically)
        /// </summary>
        public bool IsAdjacentTo(Vector other) {
            int dx = Math.Abs(this.X - other.X), dy = Math.Abs(this.Y - other.Y);
            return (dx == 0 && dy == 1)
                || (dx == 1 && dy == 0);
        }

        public override string ToString() => this.X + "; " + this.Y;
        public string ToString(IFormatProvider format) => string.Format(format, "{0};{1}", this.X, this.Y);

        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y);
        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);
        public static Vector operator *(Vector a, int scale) => new Vector(a.X * scale, a.Y * scale);
    }
}
