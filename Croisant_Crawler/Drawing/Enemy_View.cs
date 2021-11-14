using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public class Enemy_View
    {
        public static readonly Vector2Int Size = (20, 3);

        public RectRangeInt ViewRect { get; private set; }
        public Vector2Int Corner => ViewRect.MinCorner;
        public int Width => ViewRect.x.Lenght;

        public readonly Stats Stats;

        public Enemy_View(Vector2Int corner, Stats stats)
        {
            ViewRect = new RectRangeInt(corner, corner + Size);
            Stats = stats;
            SubscribeToStatChanges(stats);
        }
        public void SubscribeToStatChanges(Stats stats)
        {
            stats.HP_OnChange  += this.UpdateHP;
        }

        public void DrawEnemy()
        {
            Draw.At(Corner + (0, 0), $"{Stats.Name} <{Stats.Lvl}>:");
            UpdateHP(Stats);
        }

        public void UpdateHP(Stats stats)
        {
            Draw.Over(Corner + (2, 1), Width - 1, $"HP: {stats.HP.value}/{stats.HP.range.max}");
            Draw.Bar(Corner + (2, 2), lenght: 10, value: stats.HP, color: ConsoleColor.Red, addPercent: true);
        }
    }
}