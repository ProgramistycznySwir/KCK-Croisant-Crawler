

public class Stats
{
    public int Level { get; set; }

    public string Name { get; set; }

    public int HP { get; set; }
    public int MaxHP { get; set; }

    // Flat damage reduction.
    public int Defence { get; set; }
    // AV / (AV + 100)
    public int ArmorValue { get; set; }
    public float DamageReduction => ArmorValue / (ArmorValue + 100);
}