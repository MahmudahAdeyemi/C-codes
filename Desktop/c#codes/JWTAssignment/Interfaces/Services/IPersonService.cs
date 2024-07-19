using JWTAssignment.RequestModel;
using JWTAssignment.ResponseModel;

namespace JWTAssignment.Interfaces.Services
{
    public interface IPersonService
    {
        Task<BaseResponse> CreateCustomer(UserRequestModel userRequestModel);
        Task<BaseResponse> CreateManager(UserRequestModel userRequestModel);
        Task<BaseResponse> CreateSalesperson(UserRequestModel userRequestModel);
    }
}