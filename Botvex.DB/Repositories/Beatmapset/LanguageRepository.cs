using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Models;
using Botvex.DB.Repositories.Beatmapset.Interfaces;

namespace Botvex.DB.Repositories.Beatmapset;

public class LanguageRepository : Repository<Language>, ILanguageRepository
{
    public LanguageRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}