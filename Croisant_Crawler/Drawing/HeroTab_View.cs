using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Drawing
{
    public static class HeroTab_View
    {
        static int MaxWidth => Console.BufferWidth;

        public static void DrawHeroTab(PlayerStats player)
        {
            Console.Clear();

            Draw.At((0, 1), "Welcome to Hero Tab:");
            // Draw.At((0, 1), $"")
            UpdateLvl(player);
            UpdateSkillPoints(player);
            UpdateHP(player);
            UpdateVit(player);
            UpdateStr(player);
            UpdateAgi(player);
            UpdateDef(player);
            UpdateArm(player);
        }

        public static void UpdateLvl(PlayerStats player)
        {
            Draw.Line(2, $"Level: {player.Lvl}");
            Draw.Line(3, $"  Experience: {player.Exp}");
            Draw.Line(4, $"  Experience for next level: {PlayerStats.ExpFormula(player.Lvl + 1)}");
            Draw.Line(5, $"  Progress: ");
            Draw.Bar((12, 5),
                    lenght: 20, 
                    value: new ValueInRangeInt( new RangeInt(PlayerStats.ExpFormula(player.Lvl), PlayerStats.ExpFormula(player.Lvl+1)), player.Exp), 
                    color: ConsoleColor.Yellow, 
                    addPercent: true);
        }

        public static void UpdateSkillPoints(PlayerStats player)
        {
            Draw.Line(6, $"You have {player.SkillPoints} skill points to distribute{(player.SkillPoints > 0 ? ", do it using [V]itality, [S]trenght, [A]gility keys" : "")}.");
        }

        public static void UpdateHP(PlayerStats player)
        {
            Draw.Line(7, $"Max Health Points: {player.HP.range.max}");
            Draw.Line(8, $"  Health Points: {player.HP.value}");
            Draw.Bar((2, 9),
                    lenght: 20,
                    value: player.HP,
                    color: ConsoleColor.Red,
                    addPercent: true);
        }

        public static void UpdateVit(PlayerStats player)
        {
            Draw.Line(10, $"Vitality: {player.Vit}");
        }

        public static void UpdateStr(PlayerStats player)
        {
            Draw.Line(11, $"Strenght: {player.Str}");
            Draw.Line(12, $"  Damage: {player.DamageRange.min}-{player.DamageRange.max}");
        }

        public static void UpdateAgi(PlayerStats player)
        {
            Draw.Line(13, $"Agility: {player.Agi}");
        }

        public static void UpdateDef(PlayerStats player)
        {
            Draw.Line(14, $"Defence: {player.Def}  (flat damage reduction)");
        }

        public static void UpdateArm(PlayerStats player)
        {
            Draw.Line(15, $"Armor: {player.Arm}");
            Draw.Line(16, $"  Damage reduction: {(int)(player.DamageReduction * 100)}%");
        }
    }
}