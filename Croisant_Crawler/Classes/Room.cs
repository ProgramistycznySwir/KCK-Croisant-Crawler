using Croisant_Crawler.Data;

namespace Croisant_Crawler
{
    public class Room
    {
        public Vector2Int position;
        
        // Whether this room has connection with room { up, right, down, left }.
        public bool[] connections = new bool[4];
    }
}