using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public static class Floor_View
    {
        static Vector2Int MapCorner => Map_View.mapCorner;

        public static void DrawMap(Floor floor, bool drawAll = false)
        {
            foreach(Room room in floor.rooms.Values)
                Room_View.UpdateRoom(room, ignoreExplored: drawAll);
        }
    }
}