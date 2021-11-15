using System;
using System.Collections.Generic;
using System.Linq;
using Croisant_Crawler.Data;


namespace Croisant_Crawler.Core
{
    public class PlayerStats : Stats
    {
        public Vector2Int position;

        // public Action<PlayerStats> HP_OnChange;
        // For now formula is flat
        // public float Lvl => 1 + (Exp / 50);
        public int Exp {get; private set;}
        public Action<PlayerStats> Exp_OnChange;
        public const int ExpPerLevel = 50;

        public int SkillPoints { get; private set; }
        public const int SkillPointsPerLevel = 5;

        public int Vit_base { get => base.Vit; set => base.Vit = value; }
        public int Vit_eq { get; private set; }
        public override int Vit => Vit_base + Vit_eq;
        public Action<PlayerStats> Vit_OnChange;

        public int Str_base { get => base.Str; set => base.Str = value; }
        public int Str_eq { get; private set; }
        public override int Str => Str_base + Str_eq;
        public Action<PlayerStats> Str_OnChange;

        public int Agi_base { get => base.Agi; set => base.Agi = value; }
        public int Agi_eq { get; private set; }
        public override int Agi => Agi_base + Agi_eq;
        public Action<PlayerStats> Agi_OnChange;

        public override int Def => helm.Def + shirt.Def + pants.Def;
                // + (accesories?.Select(item => item.Def)?.Aggregate((sum, curr) => sum + curr)) ?? 0;
        public Action<PlayerStats> Def_OnChange;

        public override int Arm => helm.Arm + shirt.Arm + pants.Arm;
                // + (accesories?.Select(item => item.Arm)?.Aggregate((sum, curr) => sum + curr)) ?? 0;
        public Action<PlayerStats> Arm_OnChange;

        public Item helm;
        public Item shirt;
        public Item pants;
        public List<Item> accesories = new(4);

        public PlayerStats()
            : base("Hero", 10, 10, 10, lvl: 1)
        {
            DEBUG_GiveBasicStuff();
        }

        public void ReceiveExp(int amount)
        {
            Exp += amount;
            while(Exp >= ExpFormula(Lvl + 1))
                LevelUp();
            if(Exp_OnChange is not null)
                Exp_OnChange(this);
            // 500 * (level ^ 2) - (500 * level)
        }
        public static int ExpFormula(int level)
            => (ExpPerLevel / 2) * level * (level - 1);
        void LevelUp()
        {
            Lvl += 1;
            SkillPoints += SkillPointsPerLevel;
        }
        public static int ExpGainFormula(PlayerStats player, Stats enemy)
            => 25 + Math.Min((enemy.Lvl - player.Lvl) * 10, 0);

        public void UpgradeVit()
        {
            if(SkillPoints <= 0)
                throw new ApplicationException("Game bug, game shouldn't allow to upgrade stats without skill points.");
            Vit_base += 1;
            SkillPoints -= 1;
            if(Vit_OnChange is not null)
                Vit_OnChange(this);
            RecalculateHP();
        }

        public void UpgradeStr()
        {
            if(SkillPoints <= 0)
                throw new ApplicationException("Game bug, game shouldn't allow to upgrade stats without skill points.");
            Str_base += 1;
            SkillPoints -= 1;
            if(Str_OnChange is not null)
                Str_OnChange(this);
            RecalculateDamageRange();
        }

        public void UpgradeAgi()
        {
            if(SkillPoints <= 0)
                throw new ApplicationException("Game bug, game shouldn't allow to upgrade stats without skill points.");
            Agi_base += 1;
            SkillPoints -= 1;
            if(Agi_OnChange is not null)
                Agi_OnChange(this);
            RecalculateDamageRange();
        }


        // public override void TakeDamage(int damage)
        // {
        //     base.TakeDamage(damage);
        //     HP_OnChange(this);
        // }

        // protected override void RecalculateHP(bool firstCalculation = false)
        // {
        //     base.RecalculateHP(firstCalculation);

        //     if(firstCalculation is false)
        //         HP_OnChange(this);
        // }

        public void DEBUG_GiveBasicStuff()
        {
            helm  = new Item("Leather cap",   ItemType.Helm,  1, 5, 0);
            shirt = new Item("Leather shirt", ItemType.Shirt, 2, 15, -2);
            pants = new Item("Leather pants", ItemType.Pants, 1, 5, -1);
            // accesories.Add(new Item("Iron ring", ItemType.Accesory, 1, 1, 1));
        }
    }
}