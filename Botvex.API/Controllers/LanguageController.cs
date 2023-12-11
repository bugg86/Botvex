using Botvex.DB.Models.Beatmapset;
using Botvex.DB.Repositories.Beatmapset.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Botvex.osu.Controllers;

[ApiController]
[Route("language")]
public class LanguageController
{
    private readonly ILogger<LanguageController> _logger;
    private readonly ILanguageRepository _languageRepository;

    public LanguageController(ILogger<LanguageController> logger, ILanguageRepository languageRepository)
    {
        _logger = logger;
        _languageRepository = languageRepository;
    }
    
    [HttpGet]
    [Route("getAllLanguages")]
    public IEnumerable<Language> GetAllLanguages()
    {
        return _languageRepository.GetAll();
    }
}