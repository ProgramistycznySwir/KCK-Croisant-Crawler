using System;

namespace Croisant_Crawler.Data
{
    public struct Vector2Int
    {
        public int x, y;

        public Vector2Int(int x, int y)
            => (this.x, this.y) = (x, y);

        public static Vector2Int Zero => new Vector2Int(0, 0);
        public static Vector2Int One => new Vector2Int(1, 1);
        public static Vector2Int Up => new Vector2Int(0, 1);
        public static Vector2Int Down => new Vector2Int(0, -1);
        public static Vector2Int Right => new Vector2Int(1, 0);
        public static Vector2Int Left => new Vector2Int(-1, 0);

        public float Magnitude => (float)Math.Sqrt((x * x) + (y * y));

        public float DistanceTo(Vector2Int other)
            => (this - other).Magnitude;
        public Vector2Int Scale(Vector2Int scalar)
            => new Vector2Int(x * scalar.x, y * scalar.y);
        public Vector2Int Scale(int x, int y)
            => new Vector2Int(this.x * x, this.y * y);

        public static implicit operator Vector2Int((int, int) tuple)
            => new Vector2Int(tuple.Item1, tuple.Item2);

        public static Vector2Int operator +(Vector2Int left, Vector2Int right)
            => new Vector2Int(left.x + right.x, left.y + right.y);
        public static Vector2Int operator -(Vector2Int left, Vector2Int right)
            => new Vector2Int(left.x - right.x, left.y - right.y);
        public static bool operator ==(Vector2Int left, Vector2Int right)
            => left.x == right.x && left.y == right.y;
        public static bool operator !=(Vector2Int left, Vector2Int right)
            => !(left == right);
        public static Vector2Int operator *(Vector2Int vector, float scalar)
            => new Vector2Int((int)(vector.x * scalar), (int)(vector.y * scalar));
    }
}