using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Repositories.Beatmapset.Interfaces;

namespace Botvex.DB.Repositories.Beatmapset;

public class BeatmapsetRepository : Repository<Models.Beatmapset>, IBeatmapsetRepository
{
    public BeatmapsetRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}