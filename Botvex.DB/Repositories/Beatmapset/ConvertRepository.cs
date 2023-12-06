using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Repositories.Beatmapset.Interfaces;
using Convert = Botvex.DB.Models.Beatmap.Convert;

namespace Botvex.DB.Repositories.Beatmapset;

public class ConvertRepository : Repository<Convert>, IConvertRepository
{
    public ConvertRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}