using System.Collections.Generic;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Core;

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
        // Logic for enemy count in battle.
        int enemyCount_ = 1
                + ((distanceFromStart > 3) ? 1 : 0)
                + ((distanceFromStart > 5) ? 1 : 0)
                + ((distanceFromStart > 8) ? 1 : 0);
        
        // Randomizing enemies.
        enemies = Enumerable.Range(0, enemyCount_)
                .Map(_ => EnemyList.GenerateEnemy(
                        index: MyMath.rng.Next(EnemyList.EnemyCount),
                        level: distanceFromStart / 2 + MyMath.rng.Next(1)))
                .ToList();
    }
}