using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Models.Beatmap;
using Botvex.DB.Repositories.Beatmap.Interfaces;

namespace Botvex.DB.Repositories.Beatmap;

public class BeatmapRepository : Repository<BeatmapExtended>, IBeatmapRepository
{
    public BeatmapRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}