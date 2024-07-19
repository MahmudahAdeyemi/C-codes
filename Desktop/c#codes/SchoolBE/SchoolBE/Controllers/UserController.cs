

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SchoolBE.Core.Application.Dtos;
using SchoolBE.Core.Application.Interfaces.Services;

namespace SchoolBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public UserController(IAuthService authService, IUserService userService, IConfiguration config)
        {
            _authService = authService;
            _userService = userService;
            _config = config;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> LogIn([FromForm] LoginRequestModel model)
        {
            var user = await _userService.LoginAsync(model);
            
            if (user.Status == true)
            {
                user.Data.Token = _authService.GenerateToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), user.Data);
                return Ok(user);
            }
            else
            {
                return StatusCode(400, user);
            }
        }
    }
}
