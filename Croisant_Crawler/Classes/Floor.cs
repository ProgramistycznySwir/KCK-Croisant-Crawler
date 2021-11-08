using Croisant_Crawler.Data;

namespace Croisant_Crawler
{
    public class Floor
    {
        public Vector2Int mapSize { get; }
        public int level { get; }

        public Room[,] rooms;
        

        public Floor(Vector2Int mapSize, int level)
        {
            this.mapSize = mapSize;
            this.level = level;

            rooms = new Room[mapSize.x, mapSize.y];
        }

        void GenerateRooms()
        {
            
        }
    }
}