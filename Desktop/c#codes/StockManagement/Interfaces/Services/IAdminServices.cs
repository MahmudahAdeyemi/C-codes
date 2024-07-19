using StockManagement.ReponseModel;
using StockManagement.RequestModels;

namespace StockManagement.Interfaces.Services
{
    public interface IAdminServices
    {
        BaseResponse ChangePassword(int id, ChangePasswordModel changePasswordModel);
    }
}