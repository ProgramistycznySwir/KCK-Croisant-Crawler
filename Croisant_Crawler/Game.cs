using System;
using System.Linq;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;
using Croisant_Crawler.Drawing;

namespace Croisant_Crawler
{
    public static class Game
    {
        public static void Start()
        {
            // Initializing screen:
            Console.Clear();
            Console.CursorVisible = false;

            // Initializing game data:
            Floor floor = new Floor((6, 6));
            // Floor floor = new Floor((20,10), 1, 9999);
            PlayerStats player = new PlayerStats(floor.startRoomPos);

            // Drawing first view:
            Map_View.ReRenderMapView(floor, player);

            ConsoleKey key;
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
                // Move player to new room.
                player.position = newRoom.position;
                newRoom.IsExplored = true;
                // Draw_Map.DrawMap(floor);
                Room_View.UpdateRoom(newRoom);
                Player_View.DrawPlayerOnMap(player);
            }
        }
    }
}