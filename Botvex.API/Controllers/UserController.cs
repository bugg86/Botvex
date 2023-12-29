using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Botvex.DB.Models;
using Botvex.DB.Repositories.User.Interfaces;

namespace Botvex.osu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userRepository.GetAll().ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetByCondition(e => e.Id == id).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            
            var oldUser = await _userRepository.GetByCondition(e => e.Id == id).FirstOrDefaultAsync();

            if (oldUser == null)
            {
                _userRepository.Add(user);
            }
            else
            {
                _userRepository.Update(user, oldUser);
            }
            
            try
            {
                await _userRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_userRepository.GetSingle(e => e.Id == id) is null)
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _userRepository.Add(user);
            try
            {
                await _userRepository.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (_userRepository.GetSingle(e => e.Id == user.Id) is null)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByCondition(e => e.Id == id).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Remove(user);

            await _userRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
