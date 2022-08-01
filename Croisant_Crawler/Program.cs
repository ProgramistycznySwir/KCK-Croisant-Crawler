using System;
using Croisant_Crawler.Core;
using Croisant_Crawler.Core.Tools;
using Croisant_Crawler.Data;

namespace Croisant_Crawler;

class Program
{
    static void Main(string[] args)
    {
        // Doodling();

        // var player = new PlayerStats(Data.Vector2Int.Zero);
        // Console.WriteLine(player.DamageReduction);

        Game.Start();

        // Easter egg.
        Console.WriteLine("Thank you for playing Wing Commander.");
    }

    public static void Doodling()
    {
        Console.Clear();
        
        // float value = MyMath.Lerp(0, 1, 1f);
        ValueInRangeInt value = new ValueInRangeInt(100, 200, 150);
        Console.WriteLine(value.Percent);

        EnemyList_Tools.CreateExampleFile();

        Console.ReadKey();
    }
}