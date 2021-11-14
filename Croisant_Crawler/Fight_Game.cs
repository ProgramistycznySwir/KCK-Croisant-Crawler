using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Drawing;

namespace Croisant_Crawler
{
    public static class Fight_Game
    {
        public static void StartFight(in PlayerStats player, in Room room)
        {
            Console.Clear();

            // Init player stats view:
            PlayerStats_View playerStats_View = new();
            playerStats_View.SetCorner((0, 0));
            playerStats_View.SubscribeToStatChanges(player);
            playerStats_View.DrawPlayerStats(player);

            Fight fight = new Fight(room.distanceFromStart);

            // Fight loop:
            while(true)
            {
                
            }
        }
    }
}