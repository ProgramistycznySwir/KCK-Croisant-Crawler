using System;
using System.Collections.Generic;
using System.Linq;
using Croisant_Crawler.Data;


namespace Croisant_Crawler.Core
{
    public class PlayerStats : Stats
    {
        public Vector2Int position;

        public Action<PlayerStats> HP_OnChange;

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
            : base("Hero", 5, 5, 5)
        {
            DEBUG_GiveBasicStuff();
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            HP_OnChange(this);
        }

        protected override void RecalculateHP(bool firstCalculation = false)
        {
            base.RecalculateHP(firstCalculation);

            if(firstCalculation is false)
                HP_OnChange(this);
        }

        public void DEBUG_GiveBasicStuff()
        {
            helm  = new Item("Leather cap",   ItemType.Helm,  1, 5, 0);
            shirt = new Item("Leather shirt", ItemType.Shirt, 2, 15, -2);
            pants = new Item("Leather pants", ItemType.Pants, 1, 5, -1);
            // accesories.Add(new Item("Iron ring", ItemType.Accesory, 1, 1, 1));
        }
    }
}