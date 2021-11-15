using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public class PlayerStats_View
    {
        public static readonly Vector2Int Size = (20, 13);

        public RectRangeInt ViewRect { get; private set; }
        public Vector2Int Corner => ViewRect.MinCorner;
        public int Width => ViewRect.x.Lenght;

        public bool IsActive;

        public PlayerStats_View(Vector2Int corner)
        {
            ViewRect = new RectRangeInt(corner, corner + Size);
        }

        public PlayerStats_View SubscribeToStatChanges(PlayerStats player)
        {
            player.Exp_OnChange += this.UpdateExp;
            player.HP_OnChange  += this.UpdateHP;
            player.Vit_OnChange += this.UpdateVit;
            player.Str_OnChange += this.UpdateStr;
            player.Agi_OnChange += this.UpdateAgi;
            player.Def_OnChange += this.UpdateDef;
            player.Arm_OnChange += this.UpdateArm;
            player.Dmg_OnChange += this.UpdateDmg;
            
            // For chaining setup methods.
            return this;
        }

        public PlayerStats_View UnsubscribeToStatChanges(PlayerStats player)
        {
            player.Exp_OnChange -= this.UpdateExp;
            player.HP_OnChange  -= this.UpdateHP;
            player.Vit_OnChange -= this.UpdateVit;
            player.Str_OnChange -= this.UpdateStr;
            player.Agi_OnChange -= this.UpdateAgi;
            player.Def_OnChange -= this.UpdateDef;
            player.Arm_OnChange -= this.UpdateArm;
            player.Dmg_OnChange -= this.UpdateDmg;
            
            // For chaining setup methods.
            return this;
        }

        public void UpdateExp(PlayerStats player)
        {
            if(IsActive is false)
                return;
            Draw.Over(Corner + (1, 2), Width - 2, $"Lvl: {player.Lvl}");
            Draw.Over(Corner + (1, 3), Width - 2, $"  Exp: {player.Exp} / {PlayerStats.ExpFormula(player.Lvl+1)}");
            // TODO MID: Bar is bugged and does not display propperly when lvl > 1.
            Draw.Bar(Corner + (1, 4), lenght: 10, value: new ValueInRangeInt( new RangeInt(PlayerStats.ExpFormula(player.Lvl), PlayerStats.ExpFormula(player.Lvl+1)), player.Exp), color: ConsoleColor.Yellow, addPercent: true);
        }
        // public void UpdateHP(PlayerStats player)
        public void UpdateHP(Stats stats)
        {
            if(IsActive is false)
                return;

            Draw.Over(Corner + (1, 5), Width - 2, $"HP: {stats.HP.value}/{stats.HP.range.max}");
            Draw.Bar(Corner + (1, 6), lenght: 10, value: stats.HP, color: ConsoleColor.Red, addPercent: true);
        }
        public void UpdateVit(PlayerStats player)
        {
            if(IsActive)
                Draw.Over(Corner + (1, 7), Width - 2, $"Vit: {player.Vit}");
        }
        public void UpdateStr(PlayerStats player)
        {
            if(IsActive)
                Draw.Over(Corner + (1, 8), Width - 2, $"Str: {player.Str}");
        }
        public void UpdateAgi(PlayerStats player)
        {
            if(IsActive)
                Draw.Over(Corner + (1, 9), Width - 2, $"Agi: {player.Agi}");
        }
        public void UpdateDef(PlayerStats player)
        {
            if(IsActive)
                Draw.Over(Corner + (1, 10), Width - 2, $"Def: {player.Def}");
        }
        public void UpdateArm(PlayerStats player)
        {
            if(IsActive)
                Draw.Over(Corner + (1, 11), Width - 2, $"Arm: {player.Arm} ({(int)(player.DamageReduction*100)}%)");
        }
        public void UpdateDmg(Stats stats)
        {
            if(IsActive)
                Draw.Over(Corner + (1, 12), Width - 2, $"Dmg: {stats.DamageRange.min}-{stats.DamageRange.max}");
        }
        public PlayerStats_View DrawPlayerStats(PlayerStats player)
        {
            IsActive = true;
            // Draw.HalfFrame(PlayerViewRect);
            Draw.Frame(ViewRect);

            Draw.At(Corner + (1, 1), $" {player.Name}'s Stats:");
            UpdateExp(player);
            UpdateHP(player);
            UpdateVit(player);
            UpdateStr(player);
            UpdateAgi(player);
            UpdateDef(player);
            UpdateArm(player);
            UpdateDmg(player);

            // For chaining setup methods.
            return this;
        }
    }
}