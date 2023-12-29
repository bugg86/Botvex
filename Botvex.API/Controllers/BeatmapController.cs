using Botvex.DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Botvex.DB.Repositories.Beatmap.Interfaces;
using Botvex.DB.Repositories.Beatmapset.Interfaces;
using Botvex.DB.Repositories.User.Interfaces;
using Botvex.osu.Services.Interfaces;
using Microsoft.Identity.Client;

namespace Botvex.osu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeatmapController : ControllerBase
    {
        private readonly IBeatmapRepository _beatmapRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBeatmapsetRepository _beatmapsetRepository;
        private readonly IOsuApiService _osuApiService;

        public BeatmapController(IBeatmapRepository beatmapRepository, IUserRepository userRepository, IBeatmapsetRepository beatmapsetRepository, IOsuApiService osuApiService)
        {
            _beatmapRepository = beatmapRepository;
            _userRepository = userRepository;
            _beatmapsetRepository = beatmapsetRepository;
            _osuApiService = osuApiService;
        }

        // GET: api/Beatmap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beatmap>>> GetBeatmaps()
        {
            return await _beatmapRepository.GetAll().ToListAsync();
        }

        // GET: api/Beatmap/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Beatmap>> GetBeatmap(int id)
        {
            var beatmap = await _beatmapRepository.GetByCondition(e => e.Id == id).FirstOrDefaultAsync();

            if (beatmap == null)
            {
                return NotFound();
            }

            return beatmap;
        }

        // PUT: api/Beatmap/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutBeatmap(int id, Beatmap beatmap)
        {
            if (id != beatmap.Id)
            {
                return BadRequest();
            }

            await PreprocessBeatmap(beatmap);
            
            var oldBeatmap = await _beatmapRepository.GetByCondition(e => e.Id == id).FirstOrDefaultAsync();
            
            if (oldBeatmap == null)
            {
                _beatmapRepository.Add(beatmap);
            }
            else
            {
                _beatmapRepository.Update(beatmap, oldBeatmap);
            }
            
            try
            {
                await _beatmapRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_beatmapRepository.GetSingle(e => e.Id == id) is null)
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Beatmap
        [HttpPost]
        public async Task<ActionResult<Beatmap>> PostBeatmap(Beatmap beatmap)
        {
            await PreprocessBeatmap(beatmap);
            _beatmapRepository.Add(beatmap);
            
            try
            {
                await _beatmapRepository.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (_beatmapRepository.GetSingle(e => e.Id == beatmap.Id) is null)
                {
                    return Conflict();
                }
            }

            return CreatedAtAction("GetBeatmap", new { id = beatmap.Id }, beatmap);
        }

        // DELETE: api/Beatmap/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBeatmap(int id)
        {
            var beatmap = await _beatmapRepository.GetByCondition(e => e.Id == id).FirstOrDefaultAsync();
            
            if (beatmap == null)
            {
                return NotFound();
            }

            _beatmapRepository.Remove(beatmap);

            await _beatmapRepository.SaveChangesAsync();

            return NoContent();
        }

        private async Task PreprocessBeatmap(Beatmap beatmap)
        {
            await UpdateUser(beatmap.User_Id);
            await UpdateBeatmapset(beatmap.Beatmapset);
        }

        private async Task UpdateUser(int id)
        {
            var oldUser = await _userRepository.GetByCondition(e => e.Id == id).FirstOrDefaultAsync();
            
            var currentUser = await _osuApiService.GetUser(id);
            
            if (oldUser == null)
            {
                _userRepository.Add(currentUser);
            }
            else
            {
                _userRepository.Update(currentUser, oldUser);
            }
            
            try
            {
                await _userRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_userRepository.GetSingle(e => e.Id == id) is null)
                {
                    NotFound();
                    return;
                }
                else
                {
                    throw;
                }
            }

            NoContent();
        }

        private async Task UpdateBeatmapset(Beatmapset beatmapset)
        {
            var oldBeatmapset = await _beatmapsetRepository.GetByCondition(e => e.Id == beatmapset.Id).FirstOrDefaultAsync();
            
            if (oldBeatmapset == null)
            {
                _beatmapsetRepository.Add(beatmapset);
            }
            else
            {
                _beatmapsetRepository.Update(beatmapset, oldBeatmapset);
            }
            
            try
            {
                await _beatmapsetRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_beatmapsetRepository.GetSingle(e => e.Id == beatmapset.Id) is null)
                {
                    NotFound();
                    return;
                }
                else
                {
                    throw;
                }
            }

            NoContent();
        }
    }
}
