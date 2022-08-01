using System;

namespace Croisant_Crawler.Data;

public readonly record struct Vector2(float x, float y)
{
    public static Vector2 Zero => new(0, 0);
    public static Vector2 One => new(1, 1);
    public static Vector2 Up => new(0, 1);
    public static Vector2 Down => new(0, -1);
    public static Vector2 Right => new(1, 0);
    public static Vector2 Left => new(-1, 0);

    public float Magnitude => (float)Math.Sqrt((x * x) + (y * y));

    public float DistanceTo(Vector2 other)
        => (this - other).Magnitude;
    public Vector2 Scale(Vector2 scalar)
        => new(x * scalar.x, y * scalar.y);
    public Vector2 Scale(float x, float y)
        => new(this.x * x, this.y * y);
    public Vector2 Scale(float scalar)
        => new(this.x * scalar, this.y * scalar);

    public static implicit operator Vector2((float, float) tuple)
        => new(tuple.Item1, tuple.Item2);

    public static Vector2 operator +(Vector2 left, Vector2 right)
        => new(left.x + right.x, left.y + right.y);
    public static Vector2 operator -(Vector2 left, Vector2 right)
        => new(left.x - right.x, left.y - right.y);
    public static Vector2 operator *(Vector2 vector, float scalar)
        => vector.Scale(scalar);
}