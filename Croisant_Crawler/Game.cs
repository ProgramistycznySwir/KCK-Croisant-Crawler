using System;
using System.Linq;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;
using Croisant_Crawler.Drawing;

namespace Croisant_Crawler
{
    /// <summary>
    /// Main class that glues everything together.
    /// </summary>
    public static class Game
    {
        public static void Start()
        {
            // Initializing screen:
            Console.CursorVisible = false;

            // Initializing player data.
            PlayerStats player = new PlayerStats();

            // Generating level data.
            Floor floor = new Floor((6, 6));
            // Place player in level.
            player.position = floor.startRoomPos;

            // Init Map_View.
            Map_View.Init(player: player, floor: floor);
            // Drawing first view.
            Map_View.ReRenderMapView(floor, player, drawAll: false);

            /// Game loop:
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
                // Move player to new room:
                player.position = newRoom.position;
                if(newRoom.IsExplored is false)
                    RunSummary.IncExploredRooms();
                newRoom.IsExplored = true;
                // DEBUG.
                // player.TakeDamage(5);
                // player.ReceiveExp(45);
                if(newRoom.IsDangerous)
                {
                    Map_View.SetActive(false);
                    FightResult fightResult = Fight_Game.StartFight(player, newRoom);
                    if(fightResult is FightResult.TPK)
                    {
                        Summary(player);
                        return;
                    }
                    Map_View.ReRenderMapView(floor, player);
                }

                // Render changes:
                Room_View.UpdateRoom(newRoom);
                Player_View.UpdatePlayerOnMap(player);
            }
        }

        public static void Summary(PlayerStats player)
        {
            Console.Clear();
            Console.WriteLine("Run summary: ");
            Console.WriteLine($"Explored rooms: {RunSummary.ExploredRooms}");
            Console.WriteLine($"Defeated enemies: {RunSummary.DefeatedEnemies}");
            Console.WriteLine($"Highest level: { player.Lvl }");
        }
    }
}