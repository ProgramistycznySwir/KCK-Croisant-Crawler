using System;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public static class Draw_Map
    {
        public static readonly Vector2Int roomSize = new Vector2Int(5, 4);
        public static Vector2Int mapCorner { get; private set; }

        public static void DrawMap(Floor floor, Vector2Int cornerPos = default, bool drawAll = false)
        {
            mapCorner = cornerPos == default ? (1, 1) : cornerPos;
            
            foreach(Room room in floor.rooms.Values)
                UpdateRoom(room, ignoreExplored: drawAll);
        }

        public static void UpdateRoom(Room room, bool ignoreExplored = false)
        {
            // Dont't render not explored rooms.
            if(ignoreExplored is false && room.IsExplored is false)
                return;
            // Draw room.
            Vector2Int positionOnScreen = room.position.Scale(roomSize) + mapCorner;
            DrawMediumRect(positionOnScreen);
            // Draw connections.
            foreach(Room connection in room.connections)
            {
                Vector2Int relativePosition = room.position - connection.position;
                if(relativePosition == Vector2Int.Up)
                    Draw.At(positionOnScreen + Vector2Int.Down + Vector2Int.Right, "║", ConsoleColor.Gray);
                else if(relativePosition == Vector2Int.Right)
                    Draw.At(positionOnScreen + Vector2Int.Left + Vector2Int.Up, "═", ConsoleColor.Gray);
                else if(relativePosition == Vector2Int.Down)
                    Draw.At(positionOnScreen + Vector2Int.Up*(roomSize.y-1) + Vector2Int.Right, "║", ConsoleColor.Gray);
                else if(relativePosition == Vector2Int.Left)
                    Draw.At(positionOnScreen + Vector2Int.Right*(roomSize.x-1) + Vector2Int.Up, "═", ConsoleColor.Gray);
            }
        }

        static void DrawSmallRect(Vector2Int pos)
        {
            Draw.At(pos,               "┌┐");
            Draw.At(pos+Vector2Int.Up, "└┘");
        }
        static void DrawMediumRect(Vector2Int pos)
        {
            Draw.At(pos,                 "┌──┐");
            Draw.At(pos+Vector2Int.Up,   "│  │");
            Draw.At(pos+Vector2Int.Up*2, "└──┘");
        }
        static void DrawRect(RectRangeInt rect)
        {
            // Top and bottom frame:
            Draw.At((rect.x.min, rect.y.min), new string('─', rect.x.Lenght));
            Draw.At((rect.x.min, rect.y.max), new string('─', rect.x.Lenght));

            int x, y;
            // TODO: Finish.
            // while(x < rect.x.max)
            // {
                
            // }

        }
    }
}