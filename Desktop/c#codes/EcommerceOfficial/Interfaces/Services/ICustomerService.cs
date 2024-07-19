using EcommerceOfficial.RequestModel;
using EcommerceOfficial.ResponseModel;

namespace EcommerceOfficial.Interfaces.Services
{
    public interface ICustomerService
    { 
        Task<BaseResponseModel> Register(RegisterUserRequestModel model);
        Task<string> Logout();
        
    }
}