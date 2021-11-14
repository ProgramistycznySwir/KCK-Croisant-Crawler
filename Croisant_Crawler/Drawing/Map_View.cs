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

        public static void ReRenderMapView(Floor floor, PlayerStats player, bool drawAll = false)
        {
            IsActive = true;
            // Update properties:
            CurrentMapViewBounds = new RectRangeInt(floor.mapBounds.MaxCorner.Scale(roomSize + Vector2Int.One) - Vector2Int.Up);

            // Render:
            Console.Clear();
            Draw.Frame(CurrentMapViewBounds);
            Floor_View.DrawMap(floor, drawAll: drawAll);
            Player_View.UpdatePlayerOnMap(player);
            Player_View.DrawPlayerStats(player);
        }

        public static void SubscribeToStatChanges(PlayerStats player)
        {
            player.HP_OnChange += Player_View.UpdateHP;
            player.Vit_OnChange += Player_View.UpdateVit;
            player.Str_OnChange += Player_View.UpdateStr;
            player.Agi_OnChange += Player_View.UpdateAgi;
            player.Def_OnChange += Player_View.UpdateDef;
            player.Arm_OnChange += Player_View.UpdateArm;
        }
    }
}