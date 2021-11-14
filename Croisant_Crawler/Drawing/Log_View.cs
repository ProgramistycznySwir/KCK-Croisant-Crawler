using System.Collections.Generic;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public class Log_View
    {
        public string Name { get; private set; }

        public RectRangeInt ViewRect { get; private set; }
        public Vector2Int Corner => ViewRect.MinCorner;
        public int Width => ViewRect.x.Lenght;
        public int InnerWidth => Width - 2;
        public int Height => ViewRect.y.Lenght;
        public int InnerHeight => Height - 2;

        List<string> LogItems = new();

        public Log_View(string name, RectRangeInt viewRect)
        {
            Name = name;
            ViewRect = viewRect;

            DrawLogWindow();
        }

        void DrawLogWindow()
        {
            Draw.Frame(ViewRect);
            Draw.At(Corner + (3, 0), Name);
            ReRenderLogs();
        }

        void ReRenderLogs()
        {
            // if(LogItems.C)

            for(int i = 0; i < InnerHeight && i < LogItems.Count; i++)
                Draw.Over(Corner + (1, i + 1), InnerWidth, LogItems[^(i + 1)]);
        }

        public void AddLog(string log)
        {
            LogItems.Add(log);
            ReRenderLogs();
        }

        public void AddDelimiter(string name)
            => AddLog($"---({name})" + new string('-', InnerWidth - 5 - name.Length));
    }
}