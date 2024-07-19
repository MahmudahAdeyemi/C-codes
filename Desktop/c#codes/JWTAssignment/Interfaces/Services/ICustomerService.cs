using JWTAssignment.RequestModel;
using JWTAssignment.ResponseModel;

namespace JWTAssignment.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<GetAllCustomersResponse> GetAllCustomer();
        Task<GetCustomerResponse> GetCustomer(int id);
        Task<BaseResponse> UpdateCustomer(int customerId, UserRequestModel userRequestModel);
        Task<BaseResponse> DeleteCustomer(int customerId);
        Task<GetAllOrdersResponse> GetCustomerOrders(int customerid);
    }
}