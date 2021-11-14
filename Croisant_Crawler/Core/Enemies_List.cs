using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Croisant_Crawler.Core
{
    class Enemies_List
    {
        public Dictionary<string, Stats_Prototype> Enemy_list { get; set; }
        public string name { get; set; }

        public static void GenerateEnemies()
        {
            Enemies_List enemies_List = JsonSerializer.Deserialize<Enemies_List>("enemies.json");
        }
    }

}






