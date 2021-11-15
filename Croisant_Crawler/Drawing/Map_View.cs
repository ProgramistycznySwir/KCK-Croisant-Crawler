using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public static class Map_View
    {
        public static bool IsActive;

        public static readonly Vector2Int roomSize = (5, 4);
        public static readonly Vector2Int mapCorner = (1, 2);
        public static Vector2Int playerStatsCorner => CurrentMapViewBounds.MaxCorner.Scale((1, 0)) + (1, 1);

        public static RectRangeInt CurrentMapViewBounds { get; private set; }

        static PlayerStats_View playerStats_View;

        public static void Init(PlayerStats player, Floor floor)
        {
            CurrentMapViewBounds = new RectRangeInt((0, 1), floor.mapBounds.MaxCorner.Scale(roomSize + Vector2Int.One));

            playerStats_View ??= new PlayerStats_View(playerStatsCorner);
            playerStats_View.SubscribeToStatChanges(player);
        }

        public static void ReRenderMapView(Floor floor, PlayerStats player, bool drawAll = false)
        {
            SetActive(true);
            // Update properties:

            // Render:
            Console.Clear();
            Draw.Frame(CurrentMapViewBounds);
            Floor_View.DrawMap(floor, drawAll: drawAll);
            Player_View.UpdatePlayerOnMap(player);
            playerStats_View.DrawPlayerStats(player);
        }

        internal static void SetActive(bool active)
        {
            IsActive = active;
            playerStats_View.IsActive = active;
        }

        public static void DisplayPrompt(string actionPrompt)
            => Common.DisplayPrompt(actionPrompt);

        public static void AlertPlayer(PlayerStats player, string alertMessage)
        {
            Draw.At(player.position.Scale(roomSize) + mapCorner + Vector2Int.One, alertMessage, ConsoleColor.Red);
        }
    }
}