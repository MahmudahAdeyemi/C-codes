using JWTAssignment.RequestModel;
using JWTAssignment.ResponseModel;

namespace JWTAssignment.Interfaces.Services
{
    public interface IUserService
    {
        Task<GetUserResponseModel> LoginAsync(LoginRequestModel request);
        Task<GetUsersResponseModel> GetAllUsers();
        Task<GetUserResponseModel> GetUser(int id);
        Task FetchApi();
        Task<BaseResponse> UpdateUser(int UserId,string newRole);
        Task<BaseResponse> DeleteUser(int id);
    }
}