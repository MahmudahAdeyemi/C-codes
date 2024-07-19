using SchoolBE.Core.Application.Dtos;

namespace SchoolBE.Core.Application.Interfaces.Services
{
    public interface IAuthService
    {
        string GenerateToken(string key, string issuer, UserDto user);
        bool IsTokenValid(string key, string issuer, string token);
    }
}
