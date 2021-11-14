using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Croisant_Crawler.Core
{
    class Enemies_List
    {
        public List<Stats_Prototype> Enemy_list { get; set; }
        // public string name { get; set; }

        public static void GenerateEnemies()
        {
            using (StreamReader r = new StreamReader("enemies.json"))
            {
                string jason = r.ReadToEnd();
                Enemies_List enemies_List = JsonSerializer.Deserialize<Enemies_List>(jason);
            }
        }
    }

}






