using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Drawing;

namespace Croisant_Crawler
{
    public static class HeroTab
    {
        public static void Open(PlayerStats player)
        {
            HeroTab_View.DrawHeroTab(player);

            Common.DisplayPrompt("This is hero tab exit with [Q].");
            ConsoleKey key;
            while(true)
            {
                key = TakeInput();
                if(key is ConsoleKey.Q)
                    return;
                if(player.SkillPoints <= 0)
                    continue;

                if(key is ConsoleKey.V)
                {
                    player.UpgradeVit();
                    HeroTab_View.UpdateVit(player);
                    HeroTab_View.UpdateHP(player);
                }
                else if(key is ConsoleKey.S)
                {
                    player.UpgradeStr();
                    HeroTab_View.UpdateStr(player);
                }
                else if(key is ConsoleKey.A)
                {
                    player.UpgradeAgi();
                    HeroTab_View.UpdateAgi(player);
                }

                HeroTab_View.UpdateSkillPoints(player);
            }
        }

        public static void Wait()
        {
            while(Console.ReadKey(true).Key is not ConsoleKey.Enter);
        }
        public static ConsoleKey TakeInput()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if(key is ConsoleKey.Escape)
                System.Environment.Exit(0);
            return key;
        }
    }
}