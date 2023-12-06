namespace Botvex.DB.Models.Beatmapset;

public class Genre
{
    public BeatmapsetExtended Beatmapset { get; set; }
    public int? Beatmapset_Id { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
}