namespace Croisant_Crawler.Core
{
    public static class RunSummary
    {
        public static int DefeatedEnemies { get; private set; }
        public static void IncKilledEnemies(int amount = 1)
            => DefeatedEnemies += amount;
        public static int ExploredRooms { get; private set; }
        public static void IncExploredRooms(int amount = 1)
            => ExploredRooms += amount;
    }
}