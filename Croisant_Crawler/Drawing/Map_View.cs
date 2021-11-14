using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public static class Map_View
    {
        public static bool IsActive;

        public static readonly Vector2Int roomSize = (5, 4);
        public static readonly Vector2Int mapCorner = (1, 1);
        public static Vector2Int playerStatsCorner => CurrentMapViewBounds.MaxCorner.Scale((1, 0)) + Vector2Int.Right;

        public static RectRangeInt CurrentMapViewBounds { get; private set; }

        static PlayerStats_View playerStats_View;

        public static void Init(PlayerStats player, Floor floor)
        {
            CurrentMapViewBounds = new RectRangeInt(floor.mapBounds.MaxCorner.Scale(roomSize + Vector2Int.One) - Vector2Int.Up);

            playerStats_View ??= new PlayerStats_View();
            playerStats_View.PlayerStatsCorner = playerStatsCorner;
            playerStats_View.SubscribeToStatChanges(player);
        }

        public static void ReRenderMapView(Floor floor, PlayerStats player, bool drawAll = false)
        {
            IsActive = true;
            // Update properties:

            // Render:
            Console.Clear();
            Draw.Frame(CurrentMapViewBounds);
            Floor_View.DrawMap(floor, drawAll: drawAll);
            Player_View.UpdatePlayerOnMap(player);
            playerStats_View.DrawPlayerStats(player);
        }
    }
}