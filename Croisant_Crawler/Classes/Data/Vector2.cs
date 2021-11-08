namespace Croisant_Crawler.Data
{
    public struct Vector2Int
    {
        public int x, y;

        public Vector2Int(int x, int y)
            => (this.x, this.y) = (x, y);

        public static readonly Vector2Int Zero = new Vector2Int(0, 0);
        public static readonly Vector2Int One = new Vector2Int(1, 1);
    }
}