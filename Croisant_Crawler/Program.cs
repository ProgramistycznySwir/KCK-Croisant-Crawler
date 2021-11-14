using System;
using Croisant_Crawler.Data;

namespace Croisant_Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Doodling();

            // var player = new PlayerStats(Data.Vector2Int.Zero);
            // Console.WriteLine(player.DamageReduction);

            Game.Start();
        }

        public static void Doodling()
        {
            Console.Clear();
            
            // float value = MyMath.Lerp(0, 1, 1f);
            ValueInRangeInt value = new ValueInRangeInt(0, 100, 100);
            Console.WriteLine(value.Percent);

            Console.ReadKey();
        }
    }
}
