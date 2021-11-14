using System.Collections.Generic;
using System.Linq;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Core
{
    public class Room
    {
        public Vector2Int position { get; }
        // Whether this room has connection with room { up, right, down, left }.
        public List<Room> connections;

        public readonly int distanceFromStart;

        public readonly RoomType type;

        public bool IsExplored;
        public bool IsDangerous;
        public List<Stats> enemies;

        public const float EnemyChance = .5f;
        public const int SafeZoneDistance = 1; // 0 means only startRoom is safe.
        public const int MaxEnemyCount = 4;

        public Room(Vector2Int position, int distanceFromStart, RoomType? overrideType = null, List<Room> connections = null)
        {
            this.position = position;
            this.connections = connections ?? new List<Room>(4);
            this.distanceFromStart = distanceFromStart;

            if(distanceFromStart > SafeZoneDistance)
                IsDangerous = MyMath.RandomFloat < EnemyChance;

            if(overrideType is not null)
                type = overrideType.Value;
            else if(IsDangerous)
                type = RoomType.Fight;

            // if(distanceFromStart > SafeZoneDistance)
            //     enemies = MyMath.RandomFloat < EnemyChance ? new List<Stats>(4) : null;
            // if(IsDangerous)
            // {
            //     int enemyCount = MyMath.rng.Next(MaxEnemyCount) + 1;
                
            // }
        }

        public Vector2Int[] GetWalkableRooms()
            => connections.Select(room => position).ToArray();
        // {
        //     var result = new List<Vector2Int>(4);
            
        //     return result.ToArray();
        // }
    }

    public enum RoomType { None, StartRoom, Fight, Chest, Vendor }
}