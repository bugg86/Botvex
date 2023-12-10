using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Botvex.DB.Models.Beatmap;
using Botvex.DB.Repositories.Beatmap.Interfaces;

namespace Botvex.osu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeatmapController : ControllerBase
    {
        private readonly IBeatmapRepository _beatmapRepository;

        public BeatmapController(IBeatmapRepository beatmapRepository)
        {
            _beatmapRepository = beatmapRepository;
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
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Beatmap
        [HttpPost]
        public async Task<ActionResult<Beatmap>> PostBeatmap(Beatmap beatmap)
        {
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
                else
                {
                    throw;
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
    }
}
