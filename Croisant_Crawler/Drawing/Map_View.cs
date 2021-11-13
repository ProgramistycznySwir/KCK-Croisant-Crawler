using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public static class Map_View
    {
        public static readonly Vector2Int roomSize = (5, 4);
        public static readonly Vector2Int mapCorner = (1, 1);

        public static void ReRenderMapView(Floor floor, PlayerStats player)
        {
            Console.Clear();
            Floor_View.DrawMap(floor, drawAll: false);
            Player_View.DrawPlayerOnMap(player);
        }
    }
}