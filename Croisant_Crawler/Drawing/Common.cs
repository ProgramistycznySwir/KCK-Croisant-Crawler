using System;

namespace Croisant_Crawler.Drawing
{
    public static class Common
    {
        public static void DisplayPrompt(string actionPrompt)
        {
            // At bottom of screen.
            Draw.Over((0, 0), Console.BufferWidth, actionPrompt);
        }
    }
}