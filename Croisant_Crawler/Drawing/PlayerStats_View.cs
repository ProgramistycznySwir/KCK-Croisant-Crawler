using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public class PlayerStats_View
    {
        public static readonly Vector2Int Size = (20, 11);

        public RectRangeInt ViewRect { get; private set; }
        public Vector2Int Corner => ViewRect.MinCorner;
        public int Width => ViewRect.x.Lenght;

        public bool IsActive;

        public PlayerStats_View(Vector2Int corner)
        {
            ViewRect = new RectRangeInt(corner, corner + Size);
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

        public void UpdateExp(PlayerStats player)
        {
            if(IsActive is false)
                return;
            // Draw.Over(Corner + (1, 2), Width - 2, $"Lvl: {player.Lvl}");
            // Draw.Over(Corner + (1, 3), Width - 2, $"Exp: {player.Exp}");
            // Draw.Bar(Corner + (1, 3), lenght: 10, value: new ValueInRangeInt(0, ), color: ConsoleColor.Yellow, addPercent: true);
        }
        // public void UpdateHP(PlayerStats player)
        public void UpdateHP(Stats stats)
        {
            if(IsActive is false)
                return;

            Draw.Over(Corner + (1, 2), Width - 2, $"HP: {stats.HP.value}/{stats.HP.range.max}");
            Draw.Bar(Corner + (1, 3), lenght: 10, value: stats.HP, color: ConsoleColor.Red, addPercent: true);
        }
        public void UpdateVit(PlayerStats player)
        {
            if(IsActive)
                Draw.Over(Corner + (1, 4), Width - 2, $"Vit: {player.Vit}");
        }
        public void UpdateStr(PlayerStats player)
        {
            if(IsActive)
                Draw.Over(Corner + (1, 5), Width - 2, $"Str: {player.Str}");
        }
        public void UpdateAgi(PlayerStats player)
        {
            if(IsActive)
                Draw.Over(Corner + (1, 6), Width - 2, $"Agi: {player.Agi}");
        }
        public void UpdateDef(PlayerStats player)
        {
            if(IsActive)
                Draw.Over(Corner + (1, 7), Width - 2, $"Def: {player.Def}");
        }
        public void UpdateArm(PlayerStats player)
        {
            if(IsActive)
                Draw.Over(Corner + (1, 8), Width - 2, $"Arm: {player.Arm}");
        }

        public void DrawPlayerStats(PlayerStats player)
        {
            IsActive = true;
            // Draw.HalfFrame(PlayerViewRect);
            Draw.Frame(ViewRect);

            Draw.At(Corner + (1, 1), " Hero's Stats:");
            UpdateHP(player);
            UpdateVit(player);
            UpdateStr(player);
            UpdateAgi(player);
            UpdateDef(player);
            UpdateArm(player);
        }
    }
}