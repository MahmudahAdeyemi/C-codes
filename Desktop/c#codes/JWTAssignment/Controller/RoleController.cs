using JWTAssignment.DTOs;
using JWTAssignment.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAssignment.Controller
{
    [ApiController]
    [Route("api/roles")]
    [Authorize(Roles = "admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await  _roleService.GetAllRoles();
            return Ok(roles);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetRole([FromRoute]int Id)
        {
            var role = await _roleService.GetRole(Id);
            return Ok(role);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole([FromRoute] int id, [FromBody] UpdateRoleDto updateRoleDto)
        {
            var role = await _roleService.UpdateRole(id, updateRoleDto.Description);
            return Ok(role);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            var output = await _roleService.DeleteRole(id);
            return Ok(output);
        }

    }
}