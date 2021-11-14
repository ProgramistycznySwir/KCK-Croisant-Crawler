using System;
using System.Collections.Generic;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public class Fight_View
    {
        PlayerStats_View PlayerView;
        List<Enemy_View> EnemyViews;
        public Selector EnemySelector;
        public Vector2Int EnemyViewCorner;

        public Fight_View(PlayerStats player, Fight fight)
        {
            // Init player stats view:
            PlayerView = new PlayerStats_View((0, 0))
                    .SubscribeToStatChanges(player)
                    .DrawPlayerStats(player);

            EnemyViewCorner = (PlayerView.Width + 1, 0);

            EnemyViews = new();
            for(int i = 0; i < fight.enemies.Count; i++)
                EnemyViews.Add(new Enemy_View(EnemyViewCorner + (3, i*Enemy_View.Size.y), fight.enemies[i]));

            foreach (Enemy_View view in EnemyViews)
                view.DrawEnemy();
            
            EnemySelector = new Selector(EnemyViewCorner, spacing: 3, itemCount: EnemyViews.Count, shape: "->", isReactingToNumberInput: false);
        }

        public void DisplayPrompt(string actionPrompt)
        {
            // At bottom of screen.
            Draw.Over((0, Console.BufferHeight - 10), Console.BufferWidth, actionPrompt);
        }
    }
}