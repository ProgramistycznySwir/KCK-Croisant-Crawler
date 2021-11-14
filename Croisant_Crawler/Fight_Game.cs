using System;
using System.Collections.Generic;
using System.Linq;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;
using Croisant_Crawler.Drawing;

namespace Croisant_Crawler
{
    public static class Fight_Game
    {
        public static void StartFight(in PlayerStats player, in Room room)
        {
            Console.Clear();


            Fight fight = new Fight(room.distanceFromStart);

            Fight_View view = new(player, fight);

            // Fight loop:
            ConsoleKey key;
            while((key = Console.ReadKey(true).Key) is not ConsoleKey.Escape)
            {
                view.EnemySelector.SetActive(true).UpdateCursor(key);
            }
        }
    }
}