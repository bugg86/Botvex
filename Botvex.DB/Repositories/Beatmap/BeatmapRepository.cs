using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Repositories.Beatmap.Interfaces;

namespace Botvex.DB.Repositories.Beatmap;

public class BeatmapRepository : Repository<Models.Beatmap>, IBeatmapRepository
{

    public BeatmapRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}