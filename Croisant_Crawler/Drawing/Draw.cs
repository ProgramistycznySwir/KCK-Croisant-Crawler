using System;
using System.Text;
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

        public static void Over(Vector2Int pos, int space, string word)
        {
            if(word.Length > space)
                throw new OverflowException($"Text \"{word}\" is too long for it's space: {space}");
            At(pos, new string(' ', space));
            At(pos, word);
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

        public static void Bar(Vector2Int position, int lenght, ValueInRangeInt value, ConsoleColor color, bool addPercent = false)
        {
            string shapes = " ░▒▓█";
            RangeInt range = new RangeInt(0, shapes.Length - 1);

            StringBuilder bob = new StringBuilder();
            int value_normalized = (int)(lenght * shapes.Length * value.Percent);
            while(value_normalized > 0)
            {
                bob.Append(shapes[range.Clamp(value_normalized -1)]);
                value_normalized -= shapes.Length;
            }
            Draw.At(position, "▐");
            Draw.At(position + (1, 0), bob.ToString(), color);
            Draw.At(position + (lenght + 1, 0), "▌");
            Draw.At(position + (lenght + 2, 0), $"{(int)(value.Percent * 100)}%  ");
        }
    }
}