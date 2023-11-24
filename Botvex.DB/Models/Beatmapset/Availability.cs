namespace Botvex.DB.Models.Beatmapset;

public class Availability
{
    public int? Beatmapset_id { get; set; }
    public bool Download_disabled { get; set; }
    public string More_information { get; set; }
}