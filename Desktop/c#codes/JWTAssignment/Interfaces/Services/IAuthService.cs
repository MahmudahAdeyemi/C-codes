using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAssignment.DTOs;

namespace JWTAssignment.Interfaces.Services
{
    public interface IAuthService
    {
        string GenerateToken(string key, string issuer, UserDTO user);
        bool IsTokenValid(string key, string issuer, string token);
    }
}