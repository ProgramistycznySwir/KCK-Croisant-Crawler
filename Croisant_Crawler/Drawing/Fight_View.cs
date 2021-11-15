using System;
using System.Collections.Generic;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public class Fight_View
    {
        PlayerStats_View PlayerView;

        public Vector2Int EnemyViewCorner;
        List<Enemy_View> EnemyViews;
        public Selector EnemySelector;

        Log_View LogView;

        public Fight_View(PlayerStats player, Fight fight)
        {
            // Init player stats view:
            PlayerView = new PlayerStats_View((0, 1))
                    .SubscribeToStatChanges(player)
                    .DrawPlayerStats(player);

            EnemyViewCorner = (PlayerView.Width + 1, 1);

            EnemyViews = new();
            for(int i = 0; i < fight.enemies.Count; i++)
                EnemyViews.Add(new Enemy_View(EnemyViewCorner + (3, i*Enemy_View.Size.y), fight.enemies[i]));

            foreach (Enemy_View view in EnemyViews)
                view.DrawEnemy();
            
            EnemySelector = new Selector(EnemyViewCorner, spacing: 3, itemCount: EnemyViews.Count, shape: "->", isReactingToNumberInput: false);

            Vector2Int logViewCorner = PlayerView.ViewRect.MaxCorner.Scale(0, 1) + (0, 1);
            LogView = new Log_View("Battle log", new RectRangeInt(logViewCorner, logViewCorner + (52, 12)));
        }

        public void DisplayPrompt(string actionPrompt)
            => Common.DisplayPrompt(actionPrompt);

        public void Log(string log)
            => LogView.AddLog(log);
        public void DelimitTurn(int turn)
            => LogView.AddDelimiter($"Turn {turn}");
    }
}