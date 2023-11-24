using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Models.Beatmap;
using Botvex.DB.Models.Beatmapset;
using Botvex.DB.Repositories.Beatmapset.Interfaces;

namespace Botvex.DB.Repositories.Beatmapset;

public class BeatmapsetRepository : Repository<BeatmapsetExtended>, IBeatmapsetRepository
{
    public BeatmapsetRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}