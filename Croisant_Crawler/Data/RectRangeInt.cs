namespace Croisant_Crawler.Data;

public readonly record struct RectRangeInt(RangeInt x, RangeInt y)
{

    public Vector2Int MinCorner => (x.min, y.min);
    public Vector2Int MaxCorner => (x.max, y.max);

    // public RectRangeInt(RangeInt x, RangeInt y) => (this.x, this.y) = (x, y);
    public RectRangeInt(RangeInt squareRange) : this(squareRange, squareRange) { }
    public RectRangeInt(Vector2Int maxCorner) : this(new RangeInt(maxCorner.x), new RangeInt(maxCorner.y)) { }
    public RectRangeInt(Vector2Int minCorner, Vector2Int maxCorner)
        : this(new RangeInt(minCorner.x, maxCorner.x), new RangeInt(minCorner.y, maxCorner.y))
        { }

    public Vector2Int Clamp(Vector2Int vec) => new(MyMath.Clamp(vec.x, x.min, x.max), MyMath.Clamp(vec.y, y.min, y.max));
    public bool IsInRange(Vector2Int value) => (x.IsInRange(value.x) && y.IsInRange(value.y));

    public Vector2Int RandomVector2Int => new(x.RandomInt, y.RandomInt);

    public override string ToString() => $"RectRangeInt: ({x}, {y})";
}