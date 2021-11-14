namespace Croisant_Crawler.Data
{
    public struct RectRangeInt
    {
        public RangeInt x, y;

        public Vector2Int MinCorner => (x.min, y.min);
        public Vector2Int MaxCorner => (x.max, y.max);

        public RectRangeInt(RangeInt x, RangeInt y) => (this.x, this.y) = (x, y);
        public RectRangeInt(RangeInt squareRange) => (this.x, this.y) = (squareRange, squareRange);
        public RectRangeInt(Vector2Int maxCorner) => (this.x, this.y) = (new RangeInt(maxCorner.x), new RangeInt(maxCorner.y));
        public RectRangeInt(Vector2Int minCorner, Vector2Int maxCorner)
            => (this.x, this.y) = (new RangeInt(minCorner.x, maxCorner.x), new RangeInt(minCorner.y, maxCorner.y));
        public RectRangeInt(int x, int y) => (this.x, this.y) = (new RangeInt(x), new RangeInt(y));
        // public RectRangeInt(int max) => (this.min, this.max) = (0, max);

        // public Vector2Int Evaluate(Vector2Int t) => Vector2Int.Lerp(x, y, t);
        // public float Percent(float value) => MyMath.InverseLerp(min, max, value);
        // public float Clamp(float value) => MyMath.Clamp(value, (float)min, (float)max);
        // public int Clamp(int value) => (int)MyMath.Clamp(value, min, max);
        public bool IsInRange(Vector2Int value) => (x.IsInRange(value.x) && y.IsInRange(value.y));
        // public bool IsInRange(int value)   => (value >= min && value <= max);

        public Vector2Int RandomVector2Int => new Vector2Int(x.RandomInt, y.RandomInt);

        public override string ToString() => $"SquareRangeInt: ({x}, {y})";
    }
}