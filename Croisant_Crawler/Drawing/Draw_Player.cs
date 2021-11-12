using System;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public static class Draw_Player
    {
        public const string PlayerShape = "@";
        public const ConsoleColor PlayerColor = ConsoleColor.DarkCyan;

        static Vector2Int lastPlayerPos;

        public static void DrawPlayer(PlayerStats player)
        {
            Draw.At(lastPlayerPos.Scale(Draw_Map.roomSize) + Draw_Map.mapCorner + Vector2Int.One, " ");
            Draw.At(player.position.Scale(Draw_Map.roomSize) + Draw_Map.mapCorner + Vector2Int.One, PlayerShape, PlayerColor);
            lastPlayerPos = player.position;
        }
    }
}