using JWTAssignment.DTOs;
using JWTAssignment.Interfaces.Repositories;
using JWTAssignment.Interfaces.Services;
using JWTAssignment.RequestModel;
using JWTAssignment.ResponseModel;

namespace JWTAssignment.Implementation.Servives
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly  IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public CustomerService(ICustomerRepository customerRepository,IOrderRepository orderRepository , IProductRepository productRepository )
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<GetAllCustomersResponse> GetAllCustomer()
        {
            var customer = await _customerRepository.GetAllAsync();
            return new GetAllCustomersResponse
            {
                Data = customer.ToList().Select(x => new CustomerDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Address = x.Address,
                    UserId = x.UserId,
                }).ToList(),
                Message = "Sucessfully returned",
                Status = true
            };
        }

        public async Task<GetCustomerResponse> GetCustomer(int id)
        {
            var customer =await _customerRepository.GetCustomerById(id);
            return new GetCustomerResponse
            {
                Data = new CustomerDTO
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    Address = customer.Address,
                    UserId = customer.UserId                   
                }
            };
        }

        public async Task<BaseResponse> UpdateCustomer(int customerId, UserRequestModel userRequestModel)
        {
            var customer = await _customerRepository.GetCustomerById(customerId);
            await _customerRepository.Delete(customer.Id);
            customer.Name = userRequestModel.Name;
            customer.Email = userRequestModel.Email;
            customer.Address = userRequestModel.Address;
            await _customerRepository.CreateAsync(customer);
            return new BaseResponse
            {
                Message = "Sucessfully updated",
                Status = true
            };
        }
        public async Task<BaseResponse> DeleteCustomer(int customerId)
        {
            await _customerRepository.Delete(customerId);
            return new BaseResponse
            {
                Message = "Sucessfully deleted",
                Status = true
            };
        }
        public async Task<GetAllOrdersResponse> GetCustomerOrders(int customerid)
        {
            var orders = _orderRepository.GetAllAsync().Result.Where( x => x.CustomerId == customerid );
            return new GetAllOrdersResponse
            {
                Message = "Sucessfully returned",
                Status = true,
                Data = orders.ToList().Select(  x => new OrderDTO
                {
                    Id = x.Id,
                    Date = x.Date,
                    CustomerName =  _customerRepository.GetCustomerById(x.CustomerId).Result.Name,
                    Orders = x.OrderItems.Select(  y => new UnitOrder
                    {
                        Product = _productRepository.GetProductById(y.ProductId).Result.Name,
                        Quantity = y.Quantity
                    }).ToList()

                }).ToList()
            };
        }

    }
}