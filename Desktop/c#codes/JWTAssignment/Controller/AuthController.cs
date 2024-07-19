using JWTAssignment.Interfaces.Services;
using JWTAssignment.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAssignment.Controller
{
    [ApiController]
    [Route("api/[controller]")]


    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        private readonly IPersonService _personService;


        public AuthController(IAuthService authService, IUserService userService, IConfiguration config,IPersonService personService)
        {
            _authService = authService;
            _userService = userService;
            _personService = personService;
            _config = config;

        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> LogIn([FromForm] LoginRequestModel model)
        {
            var user = await _userService.LoginAsync(model);

            if (user.Status == true)
            {
                user.Data.Token = _authService.GenerateToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), user.Data);
                return Ok(user.Data.Token);
            }
            else
            {
                return StatusCode(400, user);
            }
        }
        
        
        [HttpPost("RegisterManger")]
        public async Task<IActionResult> RegisterManger([FromForm]UserRequestModel userRequestModel)
        {
            var response =await _personService.CreateManager(userRequestModel);
            if (response.Status == true)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("AddSalesPerson")]
        public async Task<IActionResult> RegisterSalesPerson([FromForm]UserRequestModel userRequestModel)
        {
            var response =await _personService.CreateSalesperson(userRequestModel);
            if (response.Status == true)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }
    }
}