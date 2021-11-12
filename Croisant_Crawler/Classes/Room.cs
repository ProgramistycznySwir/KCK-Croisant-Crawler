using System.Collections.Generic;
using System.Linq;
using Croisant_Crawler.Data;

namespace Croisant_Crawler
{
    public class Room
    {
        public Vector2Int position { get; }
        
        // Whether this room has connection with room { up, right, down, left }.
        public List<Room> connections;

        public readonly int distanceFromStart;

        public bool IsExplored;

        public Room(Vector2Int position, int distanceFromStart, List<Room> connections = null)
        {
            this.position = position;
            this.connections = connections ?? new List<Room>(4);
            this.distanceFromStart = distanceFromStart;
        }

        public Vector2Int[] GetWalkableRooms()
            => connections.Select(room => position).ToArray();
        // {
        //     var result = new List<Vector2Int>(4);
            
        //     return result.ToArray();
        // }
    }
}