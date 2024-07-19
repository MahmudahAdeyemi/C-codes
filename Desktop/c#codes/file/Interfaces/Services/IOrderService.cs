using file.RequestModel;
using file.ResponseModel;

namespace file.Interfaces.Services
{
    public interface IOrderService
    {
        BaseResponse MakeOrder(OrderRequestModel orderRequest);
        BaseResponse Cancel();
        BaseResponse Pay(double TotalAmoutnInWallet);
        
    }
}