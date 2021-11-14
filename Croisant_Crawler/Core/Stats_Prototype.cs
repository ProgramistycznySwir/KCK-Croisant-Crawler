using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croisant_Crawler.Core
{
    public class Stats_Prototype
    {
        //public int Level { get; set; }
        public string Name { get; set; }

        public virtual float Base_Vit { get; set; }
        public virtual float Level_Vit { get; set; }

        public virtual float Base_Str { get; set; }
        public virtual float Level_Str { get; set; }

        public virtual float Base_Agi { get; set; }
        public virtual float Level_Agi { get; set; }

        public virtual float Base_Def { get; set; }
        public virtual float Level_Def { get; set; }

        public virtual float Base_Arm { get; set; }
        public virtual float Level_Arm { get; set; }

        public Stats GenerateStats(int level)
            => new Stats(name: Name,
                    vit: (int)(Base_Vit + Level_Vit * level),
                    str: (int)(Base_Str + Level_Str * level),
                    agi: (int)(Base_Agi + Level_Agi * level),
                    def: (int)(Base_Def + Level_Def * level),
                    arm: (int)(Base_Arm + Level_Arm * level),
                    lvl: level
                    );
    }
}
