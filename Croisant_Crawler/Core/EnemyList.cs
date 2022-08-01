using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Core;

// Singleton.
public static class EnemyList
{
    public static Dictionary<string, Stats_Prototype> Enemies { get; set; }
    public static int EnemyCount => Enemies.Count;

    public static Stats GenerateEnemy(int index, int level)
        => Enemies.Values.Skip(index).First().GenerateStats(level);
    public static Stats GenerateEnemy(string name, int level)
        => Enemies[name].GenerateStats(level);

    public static void LoadFromJson()
        => Enemies = JsonSerializer
                .Deserialize<List<Stats_Prototype>>(File.ReadAllText(Settings.EnemyListFilePath))
                .ToDictionary(item => item.Name);
}