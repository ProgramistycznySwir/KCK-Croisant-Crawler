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
            view.DisplayPrompt("Fight has started press [any] key if you're ready.");
            Wait();

            // Fight loop:
            ConsoleKey key;
            while(true)
            {
                // view.DisplayPrompt("Choose action, accept with [D]");
                // view.DisplayActions(player);
                view.DisplayPrompt("For now you can only attack, proceed with [any] key.");

                view.DisplayPrompt("Choose target, accept with [D], back off action with [A].");
                while((key = TakeInput()) is not ConsoleKey.D or ConsoleKey.A)
                    view.EnemySelector.SetActive(true).UpdateCursor(key);
                view.EnemySelector.SetActive(false);

                // Deal damage to enemy:
                fight.enemies[view.EnemySelector.CursorIndex].TakeDamage(player.GetDamage());
            }
        }

        public static void Wait()
            => Console.ReadKey(true);
        public static ConsoleKey TakeInput()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if(key is ConsoleKey.Escape)
                System.Environment.Exit(0);
            return key;
        }
    }
}