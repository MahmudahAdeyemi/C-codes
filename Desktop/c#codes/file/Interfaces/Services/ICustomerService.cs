using file.RequestModel;
using file.ResponseModel;

namespace file.Interfaces.Services
{
    public interface ICustomerService
    {
        BaseResponse Register(CustomerRequestModel customerRequestModel);
        BaseResponse CraeteAdmin();
        BaseResponse ChangeAddress(int id,string address);
        BaseResponse ChangePassword(ChangePasswordRequest changePasswordRequest);
        BaseResponse Login(LoginRequestModel loginRequestModel);
    }
}