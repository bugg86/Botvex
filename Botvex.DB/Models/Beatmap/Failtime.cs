namespace Botvex.DB.Models.Beatmap;

public class Failtime
{
    public int? Beatmap_id { get; set; }
    public int[]? Exit { get; set; }
    public int[]? Fail { get; set; }
}