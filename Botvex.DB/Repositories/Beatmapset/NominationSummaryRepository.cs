using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Models.Beatmapset;
using Botvex.DB.Repositories.Beatmapset.Interfaces;

namespace Botvex.DB.Repositories.Beatmapset;

public class NominationSummaryRepository : Repository<Nomination_Summary>, INominationSummaryRepository
{
    public NominationSummaryRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}