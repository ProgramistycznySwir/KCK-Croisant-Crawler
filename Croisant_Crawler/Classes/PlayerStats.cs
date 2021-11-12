using System;
using Croisant_Crawler.Data;

public class PlayerStats : Stats
{
    public Vector2Int position;

    public PlayerStats(Vector2Int position)
        => this.position = position;
}