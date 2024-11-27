using CarRentalSystem.Models;
using CarRentalSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid User data");
            }

            try
            {
                await _userService.RegisterUser(user);
                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //login and token 
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest req)
        {
            if (req == null)
            {
                return BadRequest("Invalid Login Request");
            }
            try
            {
                var token = await _userService.AuthenticateUser(req.Email, req.Password);
                return Ok(new { token });
            }
            catch (UnauthorizedAccessException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
