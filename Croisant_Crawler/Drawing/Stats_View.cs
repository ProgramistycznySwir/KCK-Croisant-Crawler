using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    // For simple displaying enemy stats during fights.
    public static class Stats_View
    {
        public static readonly Vector2Int Size = (15, 9);

        public static RectRangeInt ViewRect { get; private set; }
        public static Vector2Int Corner => ViewRect.MinCorner;
        public static int Width => ViewRect.x.Lenght;

        public static void Init(Vector2Int corner)
        {
            ViewRect = new RectRangeInt(corner, corner + Size);
            Draw.Frame(ViewRect);
        }

        public static void DrawStats(Stats stats)
        {
            Draw.Over(Corner + (1, 1), Width - 2, "Target:");
            Draw.Over(Corner + (1, 2), Width - 2, $"Name: {stats.Name}");
            Draw.Over(Corner + (1, 3), Width - 2, $"HP: {stats.HP.value}/{stats.HP.range.max}");
            Draw.Bar(Corner + (1, 4),
                    lenght: Width - 4 - 4,
                    value: stats.HP,
                    color: ConsoleColor.Red,
                    addPercent: true);
            Draw.Over(Corner + (1, 5), Width - 2, $"Agi: {stats.Agi}");
            Draw.Over(Corner + (1, 6), Width - 2, $"Def: {stats.Def}");
            Draw.Over(Corner + (1, 7), Width - 2, $"Arm: {stats.Arm} ({(int)(stats.DamageReduction*100)}%)");
            Draw.Over(Corner + (1, 8), Width - 2, $"Dmg: {stats.DamageRange.min}-{stats.DamageRange.max}");
        }
    }
}