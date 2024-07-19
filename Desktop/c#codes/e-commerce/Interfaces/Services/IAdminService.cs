using e_commerce.RequestModel;
using e_commerce.ResponseModel;

namespace e_commerce.Interfaces.Services
{
    public interface IAdminService
    {
        BaseResponse AddManager(AdminRequestModel AdminRequestModel);
        BaseResponse UpdateManager(int id, AdminRequestModel adminRequestModel);
    }
}