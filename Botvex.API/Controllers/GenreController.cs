using Botvex.DB.Models;
using Botvex.DB.Repositories.Beatmapset.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Botvex.osu.Controllers;

[ApiController]
[Route("genre")]
public class GenreController
{
    private readonly ILogger<GenreController> _logger;
    private readonly IGenreRepository _genreRepository;

    public GenreController(ILogger<GenreController> logger, IGenreRepository genreRepository)
    {
        _logger = logger;
        _genreRepository = genreRepository;
    }
    
    [HttpGet]
    [Route("getAllGenres")]
    public IEnumerable<Genre> GetAllGenres()
    {
        return _genreRepository.GetAll();
    }
}