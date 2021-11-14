using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croisant_Crawler.Core
{
    class Stats_Prototype
    {
        //public int Level { get; set; }
        public string Name { get; protected set; }

        public virtual int Base_Vit { get; set; }
        public virtual float Level_Vit { get; set; }

        public virtual int Base_Str { get; set; }
        public virtual float Level_Str { get; set; }

        public virtual int Base_Agi { get; set; }
        public virtual float Level_Agi { get; set; }

        public virtual int Base_Def { get; set; }
        public virtual float Level_Def { get; set; }

        public virtual int Base_Arm { get; set; }
        public virtual float Level_Arm { get; set; }

    }
}
