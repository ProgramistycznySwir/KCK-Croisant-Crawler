namespace Croisant_Crawler.Core
{
    public static class Enemies_Mockup
    {
        public static Stats Goblin(int level)
            => new Stats(
                name: "Goblin",
                vit: (int)(3 + (1.5 * level)),
                str: (int)(2 + (1 * level)),
                agi: (int)(4 + (2 * level)),
                def: 0,
                arm: 0
            );
        public static Stats Golem(int level)
            => new Stats(
                name: "Golem",
                vit: (int)(3 + (2 * level)),
                str: (int)(3 + (1.5 * level)),
                agi: (int)(1 + (0.5 * level)),
                def: (int)(0.5 + (0.5 * level)),
                arm: (int)(20 + (10 * level))
            );
        public static Stats Orc(int level)
            => new Stats(
                name: "Golem",
                vit: (int)(3 + (2 * level)),
                str: (int)(3 + (1.5 * level)),
                agi: (int)(1.5 + (1 * level)),
                def: (int)(2 + (0.5 * level)),
                arm: (int)(2 + (1 * level))
            );
        // {
        //     Stats stats = new();
        //     stats.Name = "Goblin";
        //     stats.Vit = (int)(3 + (1.5 * level));
        //     stats.Str = (int)(2 + (1 * level));
        //     stats.Agi = (int)(4 + (2 * level));
        //     return stats;
        // }
    }
}