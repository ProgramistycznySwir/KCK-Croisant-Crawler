using System;
using System.Collections.Generic;
using System.Linq;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Core
{
    public class Floor
    {
        // public Vector2Int mapSize { get; }
        public RectRangeInt mapBounds { get; }
        public int level { get; }

        public int roomCount;

        // Room[,] rooms;
        // List<Room> roomList;
        public readonly Dictionary<Vector2Int, Room> rooms = new();

        public Room GetStartRoom()
            => rooms[startRoomPos];
        // public Room GetRoom(Vector2Int pos)
        //     => rooms[pos.x, pos.y];
        // void SetRoom(Vector2Int pos, Room room)
        //     => rooms[pos.x, pos.y] = room;
        void CreateRoom(Vector2Int pos, int distanceFromStart, RoomType? overrideType = null, List<Room> connections = null)
        {
            // SetRoom(pos, new Room(pos, connections));
            rooms.Add(pos, new Room(pos, distanceFromStart, overrideType, connections));
        }

        public readonly Vector2Int startRoomPos;

        public Floor(Vector2Int mapSize = default, int level = 1, int roomCount = 24)
        {
            // Normalizing.
            mapSize = mapSize == default ? Vector2Int.One * 6 : mapSize;
            mapSize -= Vector2Int.One;
            this.mapBounds = new RectRangeInt(mapSize);
            this.level = level;
            this.roomCount = Math.Min(roomCount, (mapSize.x * mapSize.y));

            startRoomPos = mapBounds.RandomVector2Int;

            // rooms = new Room[mapSize.x, mapSize.y];
            // roomList = new List<Room>(roomCount);
            GenerateRooms();
        }

        void GenerateRooms()
        {
            // Kickstart room placement:
            CreateRoom(startRoomPos, 0, overrideType: RoomType.StartRoom);
            rooms[startRoomPos].IsExplored = true;

            // Room placement:
            for(int i = 1; i < roomCount; i++)
            {
                Room curr;
                List<Vector2Int> candidatePositions = new(3);
                // List<Room> candidates = rooms.Values.Where(room => room.connections.IsFull is false).ToList();
                while(true)
                {
                    // TODO LOW:  introduce cache'ing...
                    // Pick random room with not all connections full:
                    do{
                        curr = rooms.Values.Skip(MyMath.rng.Next(i - 1)).Take(1).First();
                        // curr = rooms.Values[MyMath.rng.Next(i - 1)];
                    } while(curr.connections.Count == 4);
                    
                    // Get all possible adjacent positions:
                    if(rooms.ContainsKey(curr.position + Vector2Int.Up) is false && mapBounds.IsInRange(curr.position + Vector2Int.Up))
                        candidatePositions.Add(curr.position + Vector2Int.Up);
                    if(rooms.ContainsKey(curr.position + Vector2Int.Right) is false && mapBounds.IsInRange(curr.position + Vector2Int.Right))
                        candidatePositions.Add(curr.position + Vector2Int.Right);
                    if(rooms.ContainsKey(curr.position + Vector2Int.Down) is false && mapBounds.IsInRange(curr.position + Vector2Int.Down))
                        candidatePositions.Add(curr.position + Vector2Int.Down);
                    if(rooms.ContainsKey(curr.position + Vector2Int.Left) is false && mapBounds.IsInRange(curr.position + Vector2Int.Left))
                        candidatePositions.Add(curr.position + Vector2Int.Left);

                    if(candidatePositions.Count is 0)
                        continue;
                    break;
                }

                // Get random possible adjacent position
                Vector2Int newRoomPos = candidatePositions[MyMath.rng.Next(candidatePositions.Count)];
                CreateRoom(newRoomPos, curr.distanceFromStart + 1, connections: new List<Room>{curr});
                curr.connections.Add(rooms[newRoomPos]);
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

                foreach(Vector2Int roomPos in rooms[curr].GetWalkableRooms())
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