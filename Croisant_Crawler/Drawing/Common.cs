using System;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public static class Draw
    {
        public static void At(Vector2Int pos, string word)
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(word);
        }
        public static void At(Vector2Int pos, string word, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            At(pos, word);
            Console.ResetColor();
        }
    }
}