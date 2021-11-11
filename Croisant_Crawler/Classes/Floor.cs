using System;
using System.Collections.Generic;
using System.Linq;
using Croisant_Crawler.Data;

namespace Croisant_Crawler
{
    public class Floor
    {
        // public Vector2Int mapSize { get; }
        public RectRangeInt mapBounds { get; }
        public int level { get; }

        public int roomCount;

        // public Room[,] rooms;
        public readonly Dictionary<Vector2Int, Room> rooms = new();
        // public Room GetRoom(Vector2Int pos)
        //     => rooms[pos.x, pos.y];
        void SetRoom(Vector2Int pos, Room room)
            => rooms.Add(pos, room);
        void AddRoom(Vector2Int pos, Connections connections = new Connections())
        {
            SetRoom(pos, new Room(pos, connections));
        }

        public Vector2Int startRoomPos;

        public Floor(Vector2Int mapSize, int level = 1, int roomCount = 24)
        {
            this.mapBounds = new RectRangeInt(mapSize);
            this.level = level;

            rooms = new Room[mapSize.x, mapSize.y];
        }

        void GenerateRooms()
        {
            startRoomPos = mapBounds.RandomVector2Int;
            AddRoom(startRoomPos);

            for(int i = 1; i < roomCount; i++)
            {
                Room curr = rooms.Values.Where(room => room.connections.IsFull is false).;
                do{
                    curr = rooms.
                } while(curr.connections.IsFull is false);
            }
        }

        /// <summary>
        /// Calculates closest distance between nodes based on pathfinding.
        /// </summary>
        public int DistanceBetween(Vector2Int posA, Vector2Int posB)
        {
            if (mapBounds.IsInRange(posA) is false || mapBounds.IsInRange(posB) is false)
                throw new ArgumentException($"Provided positions are out of range: {{ mapSize: {mapBounds}, posA: {posA}, posB: {posB} }}");
            
            // Implementing A-Star algorithm.
            var costs = new int[mapBounds.x.max, mapBounds.y.max];
            var distances = new float[mapBounds.x.max, mapBounds.y.max];
            var parents = new Vector2Int[mapBounds.x.max, mapBounds.y.max];

            var open = new List<Vector2Int>();
            var closed = new List<Vector2Int>();

            Vector2Int curr = posA;
            open.Add(curr);

            while(open.Count is not 0 && !closed.Exists(pos => pos == posB))
            {
                // curr = open.Dequeue();
                curr = open.OrderByDescending(item => (costs[item.x, item.y] + distances[item.x, item.y])).First();
                open.Remove(curr);
                closed.Add(curr);

                foreach(Vector2Int roomPos in GetRoom(curr).GetWalkableRooms())
                {
                    if (closed.Contains(roomPos) is false
                        && open.Contains(roomPos) is false)
                    {
                        parents[roomPos.x, roomPos.y] = curr;
                        distances[roomPos.x, roomPos.y] = curr.DistanceTo(posB);
                        costs[roomPos.x, roomPos.y] = costs[curr.x, curr.y] + 1;
                        open.Add(curr);
                        // if(roomPos == posB)
                        //     goto EndPathfinding;
                        return costs[roomPos.x, roomPos.y];
                    }
                }
            }
            throw new Exception("Game bug: pathfinder cant find path between specified room. Game shouldn't generate inaccessible rooms");
            // EndPathfinding:
            // // If all good - return max cost
            // Node temp = ClosedList[ClosedList.IndexOf(current)];
            // if (temp == null) return null;
            // do
            // {
            //     Path.Push(temp);
            //     temp = temp.Parent;
            // } while (temp != start && temp != null) ;
            // return Path;

            // throw new NotImplementedException();
        }
    }
}