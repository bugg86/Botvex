using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Models.Beatmapset;
using Botvex.DB.Repositories.Beatmapset.Interfaces;

namespace Botvex.DB.Repositories.Beatmapset;

public class AvailabilityRepository : Repository<Availability>, IAvailabilityRepository
{
    public AvailabilityRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}