using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAssignment.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserEmail { get; set;}
        public string UserName { get; set;}
        public string Password { get; set;}
        public string Token {get; set;}
        
        public List<RoleDTO> Roles { get; set; } = new List<RoleDTO>();
 
    }
}