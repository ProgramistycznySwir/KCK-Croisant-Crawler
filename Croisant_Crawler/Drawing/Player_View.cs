using System;
using System.Text;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public static class Player_View
    {
        static Vector2Int RoomSize => Map_View.roomSize;
        static Vector2Int MapCorner => Map_View.mapCorner;
        static Vector2Int PlayerStatsCorner => Map_View.playerStatsCorner;

        public const string PlayerShape = "@";
        public const ConsoleColor PlayerColor = ConsoleColor.DarkCyan;

        static Vector2Int lastPlayerPos;

        public static void UpdatePlayerOnMap(PlayerStats player)
        {
            Draw.At(lastPlayerPos.Scale(RoomSize) + MapCorner + Vector2Int.One, " ");
            Draw.At(player.position.Scale(RoomSize) + MapCorner + Vector2Int.One, PlayerShape, PlayerColor);
            lastPlayerPos = player.position;
        }

        public static void UpdateHP(PlayerStats player)
        {
            if(Map_View.IsActive is false)
                return;

            Draw.At(PlayerStatsCorner + (1, 2), $"HP: {player.HP.value}/{player.HP.range.max} ({(int)(player.HP.Percent * 100)}%)");
            DrawBar(PlayerStatsCorner + (1, 3), lenght: 10, value: player.HP);            
        }
        public static void UpdateVit(PlayerStats player)
        {
            if(Map_View.IsActive)
                Draw.At(PlayerStatsCorner + (1, 4), $"Vit: {player.Vit}");
        }
        public static void UpdateStr(PlayerStats player)
        {
            if(Map_View.IsActive)
                Draw.At(PlayerStatsCorner + (1, 5), $"Str: {player.Str}");
        }
        public static void UpdateAgi(PlayerStats player)
        {
            if(Map_View.IsActive)
                Draw.At(PlayerStatsCorner + (1, 6), $"Agi: {player.Agi}");
        }
        public static void UpdateDef(PlayerStats player)
        {
            if(Map_View.IsActive)
                Draw.At(PlayerStatsCorner + (1, 7), $"Def: {player.Def}");
        }
        public static void UpdateArm(PlayerStats player)
        {
            if(Map_View.IsActive)
                Draw.At(PlayerStatsCorner + (1, 8), $"Arm: {player.Arm}");
        }

        public static void DrawPlayerStats(PlayerStats player)
        {
            RectRangeInt PlayerViewRect = new RectRangeInt(PlayerStatsCorner, PlayerStatsCorner + Vector2Int.One.Scale(8, 12));
            Draw.HalfFrame(PlayerViewRect);

            Draw.At(PlayerStatsCorner + (1, 1), " Hero's Stats:");
            UpdateHP(player);
            UpdateVit(player);
            UpdateAgi(player);
            UpdateDef(player);
            UpdateArm(player);
        }

        static void DrawBar(Vector2Int position, int lenght, ValueInRangeInt value)
        {
            string shapes = " ░▒▓█";
            RangeInt range = new RangeInt(0, shapes.Length - 1);

            StringBuilder bob = new StringBuilder();
            int value_normalized = (int)(lenght * shapes.Length * value.Percent);
            while(value_normalized > 0)
            {
                bob.Append(shapes[range.Clamp(value_normalized)]);
                value_normalized -= shapes.Length;
            }
            Draw.At(position, "▐");
            Draw.At(position + (1, 0), bob.ToString(), ConsoleColor.Red);
            Draw.At(position + (lenght + 1, 0), "▌");
        }
    }
}