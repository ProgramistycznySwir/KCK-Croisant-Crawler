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

            // Init player stats view:
            PlayerStats_View player_View = new((0, 0));
            player_View.SubscribeToStatChanges(player);
            player_View.DrawPlayerStats(player);

            Fight fight = new Fight(room.distanceFromStart);

            Vector2Int enemyViewsCorner = (player_View.Width + 1, 0);
            List<Enemy_View> enemy_views = new();
            for(int i = 0; i < fight.enemies.Count; i++)
            {
                enemy_views.Add(new Enemy_View(enemyViewsCorner + (2, i*Enemy_View.Size.y), fight.enemies[i]));
            }

            foreach (Enemy_View view in enemy_views)
                view.DrawEnemy();

            // Fight loop:
            while(true)
            {
                
            }
        }
    }
}