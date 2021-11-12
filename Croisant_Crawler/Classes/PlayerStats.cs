using System;
using System.Collections.Generic;
using System.Linq;
using Croisant_Crawler.Data;


namespace Croisant_Crawler
{
    public class PlayerStats : Stats
    {
        public Vector2Int position;

        public override int Def => helm.Def + shirt.Def + pants.Def;
                // + (accesories?.Select(item => item.Def)?.Aggregate((sum, curr) => sum + curr)) ?? 0;
        public override int Arm => helm.Arm + shirt.Arm + pants.Arm;
                // + (accesories?.Select(item => item.Arm)?.Aggregate((sum, curr) => sum + curr)) ?? 0;

        public Item helm;
        public Item shirt;
        public Item pants;
        public List<Item> accesories = new(4);

        public PlayerStats(Vector2Int position)
            : base("Hero", 5, 5, 5)
        {
            DEBUG_GiveBasicStuff();
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