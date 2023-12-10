using Botvex.DB.Models.Beatmap;
using Botvex.DB.Models.User;
using Convert = Botvex.DB.Models.Beatmap.Convert;

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
    public IEnumerable<Beatmap.Beatmap>? Beatmaps { get; set; }
    public IEnumerable<Convert>? Converts { get; set; }
    // public string? Description { get; set; }
    public bool? Has_favourited { get; set; }
    public Genre? Genre { get; set; }
    public Language? Language { get; set; }
    public IEnumerable<User.User> Related_users { get; set; }
    public User.User User { get; set; }
    public int Track_id { get; set; }
}