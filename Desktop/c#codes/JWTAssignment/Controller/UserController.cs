using JWTAssignment.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAssignment.Controller
{
    [ApiController]
    [Route("api/users")]
    [Authorize(Roles = "admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute]int id)
        {
            var user = await _userService.GetUser(id);
            await _userService.FetchApi();
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]int id)
        {
            var response = await _userService.DeleteUser(id);
            return Ok(response.Message);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute]int id, [FromForm]string newRole)
        {
            var response = await _userService.UpdateUser(id, newRole);
            return Ok(response.Message);
        }


    }
}