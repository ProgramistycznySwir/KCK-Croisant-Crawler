using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public class PlayerStats_View
    {
        public RectRangeInt PlayerViewRect { get; private set; }
        public Vector2Int PlayerStatsCorner => PlayerViewRect.MinCorner;
        public int Width => PlayerViewRect.x.Lenght;

        public bool IsActive;

        public void SetCorner(Vector2Int corner)
        {
            PlayerViewRect = new RectRangeInt(corner, corner + (20, 10));
        }

        public void SubscribeToStatChanges(PlayerStats player)
        {
            player.HP_OnChange  += this.UpdateHP;
            player.Vit_OnChange += this.UpdateVit;
            player.Str_OnChange += this.UpdateStr;
            player.Agi_OnChange += this.UpdateAgi;
            player.Def_OnChange += this.UpdateDef;
            player.Arm_OnChange += this.UpdateArm;
        }

        // public void UpdateHP(PlayerStats player)
        public void UpdateHP(Stats stats)
        {
            if(IsActive is false)
                return;

            Draw.Over(PlayerStatsCorner + (1, 2), Width - 2, $"HP: {stats.HP.value}/{stats.HP.range.max}");
            Draw.Bar(PlayerStatsCorner + (1, 3), lenght: 10, value: stats.HP, color: ConsoleColor.Red, addPercent: true);
        }
        public void UpdateVit(Stats stats)
        {
            if(IsActive)
                Draw.Over(PlayerStatsCorner + (1, 4), Width - 2, $"Vit: {stats.Vit}");
        }
        public void UpdateStr(Stats stats)
        {
            if(IsActive)
                Draw.Over(PlayerStatsCorner + (1, 5), Width - 2, $"Str: {stats.Str}");
        }
        public void UpdateAgi(Stats stats)
        {
            if(IsActive)
                Draw.Over(PlayerStatsCorner + (1, 6), Width - 2, $"Agi: {stats.Agi}");
        }
        public void UpdateDef(Stats stats)
        {
            if(IsActive)
                Draw.Over(PlayerStatsCorner + (1, 7), Width - 2, $"Def: {stats.Def}");
        }
        public void UpdateArm(Stats stats)
        {
            if(IsActive)
                Draw.Over(PlayerStatsCorner + (1, 8), Width - 2, $"Arm: {stats.Arm}");
        }

        public void DrawPlayerStats(PlayerStats player)
        {
            IsActive = true;
            // Draw.HalfFrame(PlayerViewRect);
            Draw.Frame(PlayerViewRect);

            Draw.At(PlayerStatsCorner + (1, 1), " Hero's Stats:");
            UpdateHP(player);
            UpdateVit(player);
            UpdateStr(player);
            UpdateAgi(player);
            UpdateDef(player);
            UpdateArm(player);
        }
    }
}