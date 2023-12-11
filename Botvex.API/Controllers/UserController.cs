using Botvex.DB.Models.User;
using Botvex.DB.Repositories.User.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Botvex.osu.Controllers;

[ApiController]
[Route("user")]
public class UserController
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _userRepository;

    public UserController(ILogger<UserController> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }
    
    [HttpGet]
    [Route("getAllUsers")]
    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }
}