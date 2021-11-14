using System.Collections.Generic;

namespace Croisant_Crawler.Core
{
    public class Fight
    {
        public const int MaxEnemiesCount = 4;
        public List<Stats> enemies = new();

        public Fight(int distanceFromStart)
        {
            GenerateFight(distanceFromStart);
        }

        void GenerateFight(int distanceFromStart)
        {
            // TODO MID: Implement propper enemies generation.
            enemies.Add(Enemies_Mockup.Slime(distanceFromStart / 2));
            enemies.Add(Enemies_Mockup.Slime(distanceFromStart / 2));
        }
    }
}