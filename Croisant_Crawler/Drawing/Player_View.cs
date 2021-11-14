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
    }
}