using System;

namespace Croisant_Crawler.Data;

public readonly record struct Vector2Int(int x, int y)
{
    public static Vector2Int Zero => new(0, 0);
    public static Vector2Int One => new(1, 1);
    public static Vector2Int Up => new(0, 1);
    public static Vector2Int Down => new(0, -1);
    public static Vector2Int Right => new(1, 0);
    public static Vector2Int Left => new(-1, 0);

    public float Magnitude => (float)Math.Sqrt((x * x) + (y * y));

    public float DistanceTo(Vector2Int other)
        => (this - other).Magnitude;
    public Vector2Int Scale(Vector2Int scalar)
        => new(x * scalar.x, y * scalar.y);
    public Vector2Int Scale(int x, int y)
        => new(this.x * x, this.y * y);
    public Vector2Int Scale(int scalar)
        => new(this.x * scalar, this.y * scalar);

    public static implicit operator Vector2Int((int, int) tuple)
        => new(tuple.Item1, tuple.Item2);

    public static Vector2Int operator +(Vector2Int left, Vector2Int right)
        => new(left.x + right.x, left.y + right.y);
    public static Vector2Int operator -(Vector2Int left, Vector2Int right)
        => new(left.x - right.x, left.y - right.y);
    public static Vector2 operator *(Vector2Int vector, float scalar)
        => new(vector.x * scalar, vector.y * scalar);
    public static Vector2Int operator *(Vector2Int vector, int scalar)
        => vector.Scale(scalar);
}