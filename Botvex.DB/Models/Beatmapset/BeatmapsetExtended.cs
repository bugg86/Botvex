using Botvex.DB.Enums;

namespace Botvex.DB.Models.Beatmapset;

public class BeatmapsetExtended : Beatmapset
{
    public float Bpm { get; set; }
    public bool Can_be_hyped { get; set; }
    public string Deleted_at { get; set; }
    public bool? Discussion_enabled { get; set; }
    public bool Discussion_locked { get; set; }
    public bool Is_scoreable { get; set; }
    public string Last_updated { get; set; }
    public string? Legacy_thread_url { get; set; }
    public RankStatus Ranked { get; set; }
    public string? Ranked_date { get; set; }
    public bool Storyboard { get; set; }
    public string? Submitted_date { get; set; }
    public string Tags { get; set; }
}