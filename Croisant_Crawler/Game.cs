using System;
using Croisant_Crawler.Drawing;

namespace Croisant_Crawler
{
    public static class Game
    {
        public static void Start()
        {
            Console.Clear();

            Floor floor = new Floor();

            Draw_Map.DrawMap(floor, drawAll: true);
            // Draw_Map.DrawMap(floor, drawAll: false);


        }
    }
}