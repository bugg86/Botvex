using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Models.Beatmapset;
using Botvex.DB.Repositories.Beatmapset.Interfaces;

namespace Botvex.DB.Repositories.Beatmapset;

public class DescriptionRepository : Repository<Description>, IDescriptionRepository
{
    public DescriptionRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}