using System;

namespace Croisant_Crawler.Core
{
    public enum ItemType { Helm, Shirt, Pants, Accesory }

    public class Item
    {
        public string Name { get; }
        public ItemType Type { get; }

        public int Def { get; }
        public int Arm { get; }
        public int Agi { get; }

        public Item(string name, ItemType type, int def, int arm, int agi)
            => (Name, Type, Def, Arm, Agi) = (name, type, def, arm, agi);
    }
}
