using System;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public static class Draw
    {
        public static void At(int x, int y, string word)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(word);
        }
        public static void At(Vector2Int pos, string word)
            => At(pos.x, pos.y, word);
        public static void At(Vector2Int pos, string word, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            At(pos, word);
            Console.ResetColor();
        }


        public static void SmallRect(Vector2Int pos)
        {
            Draw.At(pos,               "┌┐");
            Draw.At(pos+Vector2Int.Up, "└┘");
        }
        public static void MediumRect(Vector2Int pos)
        {
            Draw.At(pos,                 "┌──┐");
            Draw.At(pos+Vector2Int.Up,   "│  │");
            Draw.At(pos+Vector2Int.Up*2, "└──┘");
        }
        public static void Frame(RectRangeInt rect)
        {
            // Top and bottom frame:
            Draw.At((rect.x.min, rect.y.min), new string('─', rect.x.Lenght));
            Draw.At((rect.x.min, rect.y.max), new string('─', rect.x.Lenght));

            int y = rect.y.min;
            // TODO: Finish.
            while(y < rect.y.max)
            {
                Draw.At((rect.x.min, y), "│");
                Draw.At((rect.x.max, y), "│");
                y++;
            }
        }
    }
}