using System;
using Croisant_Crawler.Data;

public class Stats
{
    public int Level { get; set; }

    public string Name { get; protected set; }

    public ValueInRangeInt HP { get; set; }
    // public int HP { get; set; }
    // public int MaxHP { get; set; }

    public int Vit { get; set; } // R
    public int Str { get; set; } // Y
    public int Agi { get; set; } // G

    // Flat damage reduction.
    public virtual int Def { get; set; }
    // AV / (AV + 100)
    public virtual int Arm { get; set; }
    public float DamageReduction => Arm / (Arm + 100f);

    public Stats(string name, int vit, int str, int agi, int def = 0, int arm = 0)
        => (Name, Vit, Str, Agi, Def, Arm) = (name, vit, str, agi, def, arm);

    public int CalculateDamage(int baseDamage)
    {
        return (int)Math.Max(baseDamage * (1-DamageReduction) - Def, 1);
    }
}