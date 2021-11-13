using System;

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
            Console.WriteLine("Line1");
            Console.WriteLine("Line2");
            Console.WriteLine("Line3");
            Console.WriteLine("Line4");
            Drawing.Draw.At(Data.Vector2Int.Right, " \n \n \n ");
            Console.ReadKey();
        }
    }
}
