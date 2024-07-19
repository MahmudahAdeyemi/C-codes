using JWTAssignment.RequestModel;
using JWTAssignment.ResponseModel;

namespace JWTAssignment.Interfaces.Services
{
    public interface IOrderService
    {
        Task<GetAllOrdersResponse> GetAllOrders();
        Task<GetOrderResponse> GetOrder(int id);
        Task<BaseResponse> CreateOrder(int customerId,CreateOrderRequestModel request);
        Task<BaseResponse> UpdateOrder(int customerId,CreateOrderRequestModel request);
        Task<BaseResponse> DeleteOrder(int customerId);
        Task<BaseResponse> Pay(int customerId);
    }
}