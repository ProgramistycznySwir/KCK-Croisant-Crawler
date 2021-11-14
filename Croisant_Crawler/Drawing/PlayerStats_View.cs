using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public class PlayerStats_View
    {
        public Vector2Int PlayerStatsCorner;
        public bool IsActive;

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
        public void UpdateHP(PlayerStats player)
        {
            if(IsActive is false)
                return;

            Draw.At(PlayerStatsCorner + (1, 2), $"HP: {player.HP.value}/{player.HP.range.max}");
            Draw.Bar(PlayerStatsCorner + (1, 3), lenght: 10, value: player.HP, color: ConsoleColor.Red, addPercent: true);
        }
        public void UpdateVit(PlayerStats player)
        {
            if(IsActive)
                Draw.At(PlayerStatsCorner + (1, 4), $"Vit: {player.Vit}       ");
        }
        public void UpdateStr(PlayerStats player)
        {
            if(IsActive)
                Draw.At(PlayerStatsCorner + (1, 5), $"Str: {player.Str}       ");
        }
        public void UpdateAgi(PlayerStats player)
        {
            if(IsActive)
                Draw.At(PlayerStatsCorner + (1, 6), $"Agi: {player.Agi}       ");
        }
        public void UpdateDef(PlayerStats player)
        {
            if(IsActive)
                Draw.At(PlayerStatsCorner + (1, 7), $"Def: {player.Def}       ");
        }
        public void UpdateArm(PlayerStats player)
        {
            if(IsActive)
                Draw.At(PlayerStatsCorner + (1, 8), $"Arm: {player.Arm}       ");
        }

        public void DrawPlayerStats(PlayerStats player)
        {
            IsActive = true;

            RectRangeInt PlayerViewRect = new RectRangeInt(PlayerStatsCorner, PlayerStatsCorner + (20, 10));
            // Draw.HalfFrame(PlayerViewRect);
            Draw.Frame(PlayerViewRect);

            Draw.At(PlayerStatsCorner + (1, 1), " Hero's Stats:");
            UpdateHP(player);
            UpdateVit(player);
            UpdateAgi(player);
            UpdateDef(player);
            UpdateArm(player);
        }
    }
}