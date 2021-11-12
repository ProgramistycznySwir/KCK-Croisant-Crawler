using System;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public static class Draw_Map
    {
        public static void DrawMap(Floor floor, Vector2Int cornerPos = default, bool drawAll = false)
        {
            cornerPos = cornerPos == default ? (1, 1) : cornerPos;
            
            foreach(Room room in floor.rooms.Values)
                UpdateRoom(room, cornerPos, ignoreExplored: drawAll);
        }

        public static void UpdateRoom(Room room, Vector2Int cornerPos, bool ignoreExplored = false)
        {
            // Dont't render not explored rooms.
            if(ignoreExplored is false && room.IsExplored is false)
                return;
            // Draw room.
            Vector2Int positionOnScreen = room.position * 3 + cornerPos;
            DrawSmallRect(positionOnScreen);
            // Draw connections.
            foreach(Room connection in room.connections)
            {
                Vector2Int relativePosition = room.position - connection.position;
                if(relativePosition == Vector2Int.Up)
                {
                    Draw.At(positionOnScreen + Vector2Int.Down, "││", ConsoleColor.Gray);
                }
                else if(relativePosition == Vector2Int.Right)
                {
                    Draw.At(positionOnScreen + Vector2Int.Left, "─", ConsoleColor.Gray);
                    Draw.At(positionOnScreen + Vector2Int.Left + Vector2Int.Up, "─", ConsoleColor.Gray);
                }
                else if(relativePosition == Vector2Int.Down)
                {
                    Draw.At(positionOnScreen + Vector2Int.Up*2, "││", ConsoleColor.Gray);
                }
                else if(relativePosition == Vector2Int.Left)
                {
                    Draw.At(positionOnScreen + Vector2Int.Right*2, "─", ConsoleColor.Gray);
                    Draw.At(positionOnScreen + Vector2Int.Right*2 + Vector2Int.Up, "─", ConsoleColor.Gray);
                }
            }
        }

        static void DrawSmallRect(Vector2Int pos)
        {
            Draw.At(pos,               "┌┐");
            Draw.At(pos+Vector2Int.Up, "└┘");
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