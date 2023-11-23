namespace Botvex.DB.Models.Beatmapset;

public class Nomination
{
    public int? Beatmapset_id { get; set; }
    public string? Rulesets { get; set; }
    public string? Reset { get; set; }
    public int? User_id { get; set; }
}