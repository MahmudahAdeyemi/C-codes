using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController(IdentityService identityService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody]UserDto user)
        {
            if(!identityService.IsCredentialsValid(user))
            {
                return Unauthorized();
            }
            else
            {
               var claims = new List<Claim>();
               var userNameClaim = new Claim(ClaimTypes.Name,user.UserName);
               claims.Add(userNameClaim);
                
            }

            return Ok();
            
        }

        [HttpGet]
        public IActionResult LogOut([FromBody]UserDto user)
        {
            HttpContext.Session.Remove("token");
            return Ok();
        }
    }
}
public class UserDto
{
    public required string UserName{get; set;}
    public required string PassWord{get; set;}

}