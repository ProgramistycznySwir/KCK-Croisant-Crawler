using System;
using Croisant_Crawler.Core;
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
            Draw.At(positionOnScreen + RoomSize - Vector2Int.One * 3, TypeToShape(room.type).shape, TypeToShape(room.type).color);
            // Draw connections:
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

        public static (string shape, ConsoleColor color) TypeToShape(RoomType type)
            => type switch{
                    RoomType.StartRoom => ("☀", ConsoleColor.Cyan),
                    RoomType.Fight     => ("⚔", ConsoleColor.Red),
                    RoomType.Chest     => ("⛶", ConsoleColor.DarkYellow),
                    RoomType.Vendor    => ("⛀", ConsoleColor.DarkGreen),
                    _                  => (" ", ConsoleColor.White)
                };

        // public static explicit operator string(RoomType type)
        //     => type switch{
        //             RoomType.None => " "
        //         };
    }
}