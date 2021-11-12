using System;
using System.Linq;
using Croisant_Crawler.Data;
using Croisant_Crawler.Drawing;

namespace Croisant_Crawler
{
    public static class Game
    {
        public static void Start()
        {
            Console.Clear();
            Console.CursorVisible = false;

            // Floor floor = new Floor();
            Floor floor = new Floor((20,10), 1, 9999);

            Draw_Map.DrawMap(floor, drawAll: true);
            // Draw_Map.DrawMap(floor, drawAll: false);
            PlayerStats player = new PlayerStats(floor.startRoomPos);
            Draw_Player.DrawPlayer(player);

            // floor.rooms.TryGetValue(currPos + Vector2Int.Right, out room)
            ConsoleKey key = new();
            while((key = Console.ReadKey(true).Key) is not ConsoleKey.Escape)
            {
                var nextPos = player.position + key switch{
                    ConsoleKey.W => Vector2Int.Down,
                    ConsoleKey.D => Vector2Int.Right,
                    ConsoleKey.S => Vector2Int.Up,
                    ConsoleKey.A => Vector2Int.Left,
                    _ => Vector2Int.Zero
                };
                if(nextPos == player.position)
                    continue;
                var newRoom = floor.rooms[player.position].connections
                        .Where(room => room.position == nextPos)
                        .FirstOrDefault();
                if(newRoom is null)
                    continue;
                player.position = newRoom.position;
                newRoom.IsExplored = true;
                // Draw_Map.DrawMap(floor);
                Draw_Map.UpdateRoom(newRoom);
                Draw_Player.DrawPlayer(player);
            }
        }
    }
}