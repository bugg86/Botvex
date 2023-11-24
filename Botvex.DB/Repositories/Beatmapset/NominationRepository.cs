using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Models.Beatmapset;
using Botvex.DB.Repositories.Beatmapset.Interfaces;

namespace Botvex.DB.Repositories.Beatmapset;

public class NominationRepository : Repository<Nomination>, INominationRepository
{
    public NominationRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}