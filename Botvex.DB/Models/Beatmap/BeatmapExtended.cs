using Botvex.DB.Enums;

namespace Botvex.DB.Models.Beatmap;

public class BeatmapExtended : Beatmap
{
    public float Accuracy { get; set; }
    public float Ar { get; set; }
    public float? Bpm { get; set; }
    public bool Convert { get; set; }
    public int Count_circles { get; set; }
    public int Count_sliders { get; set; }
    public int Count_spinners { get; set; }
    public float Cs { get; set; }
    public string? Deleted_at { get; set; }
    public float Drain { get; set; }
    public int Hit_length { get; set; }
    public bool Is_scoreable { get; set; }
    public string Last_updated { get; set; }
    public int Mode_int { get; set; }
    public int Passcount { get; set; }
    public int Playcount { get; set; }
    public RankStatus Ranked { get; set; }
    public string Url { get; set; }
}