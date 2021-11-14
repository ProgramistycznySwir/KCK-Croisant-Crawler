using System;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    /// <summary>
    /// Collection of common rendering functions.
    /// </summary>
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
        public static void At(Vector2Int pos, string word, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
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
            // Draw horizontal lines:
            Draw.At((rect.x.min, rect.y.min), new string('─', rect.x.Lenght));
            Draw.At((rect.x.min, rect.y.max), new string('─', rect.x.Lenght));

            // Draw vertical lines:
            for(int y = rect.y.min; y < rect.y.max; y++)
            {
                Draw.At((rect.x.min, y), "│");
                Draw.At((rect.x.max, y), "│");
            }

            // Draw corners:
            Draw.At((rect.x.min, rect.y.min), "┌");
            Draw.At((rect.x.max, rect.y.min), "┐");
            Draw.At((rect.x.min, rect.y.max), "└");
            Draw.At((rect.x.max, rect.y.max), "┘");
        }
        public static void HalfFrame(RectRangeInt rect)
        {
            // Draw horizontal line.
            Draw.At((rect.x.min, rect.y.min), new string('─', rect.x.Lenght));

            // Draw vertical line.
            for(int y = rect.y.min; y < rect.y.max; y++)
                Draw.At((rect.x.min, y), "│");

            // Draw corner:
            Draw.At((rect.x.min, rect.y.min), "┌");
        }
    }
}