using SchoolBE.Core.Application.Dtos;

namespace SchoolBE.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<BaseResponse<UserDto>> LoginAsync(LoginRequestModel request);
        Task<BaseResponse<UserDto>> GetAsync(string id);
        Task<BaseResponse<ICollection<UserDto>>> GetUsers();
    }
}
