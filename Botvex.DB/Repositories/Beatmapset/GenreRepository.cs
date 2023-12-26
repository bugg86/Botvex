using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Models;
using Botvex.DB.Repositories.Beatmapset.Interfaces;

namespace Botvex.DB.Repositories.Beatmapset;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}