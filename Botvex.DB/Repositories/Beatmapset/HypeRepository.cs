using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Models.Beatmapset;
using Botvex.DB.Repositories.Beatmapset.Interfaces;

namespace Botvex.DB.Repositories.Beatmapset;

public class HypeRepository : Repository<Hype>, IHypeRepository
{
    public HypeRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}