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

            // Initializing list of enemy.
            EnemyList.LoadFromJson();

            // Initializing player data.
            PlayerStats player = new PlayerStats();
            // DEBUG:
            player.ReceiveExp(5000);

            // Generating level data.
            Floor floor = new Floor((6, 6));
            // Place player in level.
            player.position = floor.startRoomPos;

            // Init Map_View.
            Map_View.Init(player: player, floor: floor);
            // Drawing first view.
            Map_View.ReRenderMapView(floor, player, drawAll: false);


            Map_View.DisplayPrompt("Welcome to Croisant_Crawler, find exit out of dungeon, press [enter] to start game.");
            Wait();

            /// Game loop:
            ConsoleKey key;
            while(true)
            {
                Map_View.DisplayPrompt("Move through rooms using [W], [A], [S], [D]. [Q] to open Hero Tab");
                key = TakeInput();

                if(key is ConsoleKey.Q)
                {
                    Map_View.SetActive(false);
                    HeroTab.Open(player);
                    Map_View.ReRenderMapView(floor, player);
                }

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
                    Map_View.DisplayPrompt("You've encountered enemies in this room, press [enter] to start combat.");
                    Map_View.AlertPlayer(player, "[ENTER]");
                    Wait();

                    Map_View.SetActive(false);
                    FightResult fightResult = Fight_Game.StartFight(player, newRoom);
                    if(fightResult is FightResult.TPK)
                    {
                        Summary(player);
                        return;
                    }
                    newRoom.IsDangerous = false;
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

        public static void Wait()
        {
            while(Console.ReadKey(true).Key is not ConsoleKey.Enter);
        }
        public static ConsoleKey TakeInput()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if(key is ConsoleKey.Escape)
                System.Environment.Exit(0);
            return key;
        }
    }
}