using System.Collections.Generic;
using Croisant_Crawler.Data;

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
            int enemyCount = 1
                    + ((distanceFromStart > 3) ? 1 : 0)
                    + ((distanceFromStart > 5) ? 1 : 0)
                    + ((distanceFromStart > 8) ? 1 : 0);
            
            for(int i = 0; i < enemyCount; i++)
                enemies.Add(
                    EnemyList.GenerateEnemy(
                        MyMath.rng.Next(EnemyList.EnemyCount),
                        distanceFromStart / 2 + MyMath.rng.Next(1)));
        }
    }
}