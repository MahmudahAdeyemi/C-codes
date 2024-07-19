using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolBE.Core.Application.Dtos;
using SchoolBE.Core.Application.Interfaces.Services;

namespace SchoolBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardianController : ControllerBase
    {
        private readonly IGuardianService _guardianService;

        public GuardianController(IGuardianService guardianService)
        {
            _guardianService = guardianService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGuardians()
        {
            var guardians = await _guardianService.GetAllAsync();
            return Ok(guardians.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuardian([FromRoute] string id)
        {
            var guardian = await _guardianService.GetAsync(id);
            if(guardian.Status == false)
            {
                return NotFound();
            }
            return Ok(guardian.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuardian([FromBody] GuardianRequest request)
        {
            var guardian = await _guardianService.CreateAsync(request);
            if(guardian.Status == false)
            {
                return BadRequest();
            }
            return Ok(guardian.Data);
        }
    }
}
