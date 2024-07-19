using Transaction.RequestModel;
using Transaction.ResponseModel;

namespace Transaction.Interfaces.Services
{
    public interface IManagerService
    {
        BaseResponse AddManager(ManagerRequestModel managerRequestModel);
        BaseResponse DeleteManager(int id);
        ManagersResponse GetAllManagerResponse();
        ManagerResponse GetManagerById(int id);
        BaseResponse UpdateManager(int id, UpdateManagerRequestModel managerRequestModel);
    }
}