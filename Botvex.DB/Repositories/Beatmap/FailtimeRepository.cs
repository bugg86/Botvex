using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Models.Beatmap;
using Botvex.DB.Repositories.Beatmap.Interfaces;

namespace Botvex.DB.Repositories.Beatmap;

public class FailtimeRepository : Repository<Failtime>, IFailtimeRepository
{
    public FailtimeRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}