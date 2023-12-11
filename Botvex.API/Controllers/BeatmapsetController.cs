using Botvex.DB.Models.Beatmapset;
using Botvex.DB.Repositories.Beatmapset.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Botvex.osu.Controllers;

[ApiController]
[Route("beatmapset")]
public class BeatmapsetController
{
    private readonly ILogger<BeatmapsetController> _logger;
    private readonly IBeatmapsetRepository _beatmapsetRepository;

    public BeatmapsetController(ILogger<BeatmapsetController> logger, IBeatmapsetRepository beatmapsetRepository)
    {
        _logger = logger;
        _beatmapsetRepository = beatmapsetRepository;
    }
    
    [HttpGet]
    [Route("getAllBeatmapsets")]
    public IEnumerable<Beatmapset> GetAllBeatmapsets()
    {
        return _beatmapsetRepository.GetAll();
    }
}