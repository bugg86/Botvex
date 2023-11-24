using Botvex.DB.Models.Beatmapset;

namespace Botvex.DB.Models.Beatmap;

public class Beatmap
{
    public int Beatmapset_Id { get; set; }
    public float Difficulty_Rating { get; set; }
    public int Id { get; set; }
    public string Mode { get; set; }
    public string Status { get; set; }
    public int Total_Length { get; set; }
    public int User_Id { get; set; }
    public string Version { get; set; }
    public BeatmapsetExtended Beatmapset { get; set; }
    public string? Checksum { get; set; }
    public Failtime Failtimes { get; set; }
    public int Max_combo { get; set; }
}