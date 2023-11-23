using Botvex.DB.Models.Beatmap;
using Botvex.DB.Models.User;

namespace Botvex.DB.Models.Beatmapset;

public class Beatmapset
{
    public string Artist { get; set; }
    public string Artist_unicode { get; set; }
    public string Covers { get; set; }
    public string Creator { get; set; }
    public int Favourite_count { get; set; }
    public int Id { get; set; }
    public bool Nsfw { get; set; }
    public int Offset { get; set; }
    public int Play_count { get; set; }
    public string Preview_url { get; set; }
    public string Source { get; set; }
    public string Status { get; set; }
    public bool Spotlight { get; set; }
    public string Title { get; set; }
    public string Title_unicode { get; set; }
    public int User_id { get; set; }
    public bool Video { get; set; }
    public List<BeatmapExtended>? Beatmaps { get; set; }
    public List<BeatmapExtended>? Converts { get; set; }
    public List<Nomination>? Current_nomination { get; set; }
    public List<dynamic>? Current_user_attributes { get; set; }
    public Description? Description { get; set; }
    public bool? Has_favourited { get; set; }
    public Genre? Genre { get; set; }
    public Language? Language { get; set; }
    public List<string>? Pack_tags { get; set; }
    public List<int>? Ratings { get; set; }
    public List<UserExtended> Related_users { get; set; }
    public UserExtended User { get; set; }
    public int Track_id { get; set; }
}