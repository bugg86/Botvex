using Botvex.DB.Models.Beatmap;
using Botvex.DB.Models.Beatmapset;

namespace Botvex.DB.Models.User;

public class User
{
    public string Avatar_url { get; set; }
    public string Country_code { get; set; }
    public string? Default_group { get; set; }
    public int Id { get; set; }
    public bool Is_active { get; set; }
    public bool Is_bot { get; set; }
    public bool Is_deleted { get; set; }
    public bool Is_online { get; set; }
    public bool Is_supporter { get; set; }
    public string? Last_visit { get; set; }
    public bool Pm_friends_only { get; set; }
    public string? Profile_colour { get; set; }
    public string Username { get; set; }
    public IEnumerable<Beatmap.Beatmap>? Beatmaps { get; set; }
    public IEnumerable<Beatmapset.Beatmapset> Beatmapsets { get; set; }
}