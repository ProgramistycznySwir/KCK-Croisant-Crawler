using System;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public static class Room_View
    {
        static Vector2Int RoomSize => Map_View.roomSize;
        static Vector2Int MapCorner => Map_View.mapCorner;

        public static void UpdateRoom(Room room, bool ignoreExplored = false)
        {
            // Dont't render not explored rooms.
            if(ignoreExplored is false && room.IsExplored is false)
                return;
            // Draw room.
            Vector2Int positionOnScreen = room.position.Scale(RoomSize) + MapCorner;
            Draw.MediumRect(positionOnScreen);
            // Draw connections.
            foreach(Room connection in room.connections)
            {
                Vector2Int relativePosition = room.position - connection.position;
                if(relativePosition == Vector2Int.Up)
                    Draw.At(positionOnScreen + Vector2Int.Down + Vector2Int.Right, "║", ConsoleColor.Gray);
                else if(relativePosition == Vector2Int.Right)
                    Draw.At(positionOnScreen + Vector2Int.Left + Vector2Int.Up, "═", ConsoleColor.Gray);
                else if(relativePosition == Vector2Int.Down)
                    Draw.At(positionOnScreen + Vector2Int.Up*(RoomSize.y-1) + Vector2Int.Right, "║", ConsoleColor.Gray);
                else if(relativePosition == Vector2Int.Left)
                    Draw.At(positionOnScreen + Vector2Int.Right*(RoomSize.x-1) + Vector2Int.Up, "═", ConsoleColor.Gray);
            }
        }
    }
}