using JWTAssignment.DTOs;
using JWTAssignment.Entities;
using JWTAssignment.Interfaces.Repositories;
using JWTAssignment.Interfaces.Services;
using JWTAssignment.RequestModel;
using JWTAssignment.ResponseModel;

namespace JWTAssignment.Implementation.Servives
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public async Task<GetAllOrdersResponse> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
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
        public async Task<GetOrderResponse> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            return new GetOrderResponse
            {
                Message = "Sucessfully returned",
                Status = true,
                Data = new OrderDTO
                {
                    Id = order.Id,
                    Date = order.Date,
                    CustomerName =  _customerRepository.GetCustomerById(order.CustomerId).Result.Name,
                    Orders = order.OrderItems.Select(  y => new UnitOrder
                    {
                        Product = _productRepository.GetProductById(y.ProductId).Result.Name,
                        Quantity = y.Quantity
                    }).ToList()
                }
            };
        }
        public async Task<BaseResponse> CreateOrder(int customerId,CreateOrderRequestModel request)
        {
            var order = new Order 
            {
                CustomerId = customerId
            };
            foreach( var item in request.Datas)
            {
                var orderItem = new OrderItem
                {
                    ProductId = _productRepository.GetProductByName(item.Name).Result.Id,
                    Quantity = item.Quantity,
                    UnitPrice = _productRepository.GetProductByName(item.Name).Result.SellingPrice,
                    OrderId = order.Id
                };
                await _productRepository.Delete(_productRepository.GetProductByName(item.Name).Result.Id);
                _productRepository.GetProductByName(item.Name).Result.QuantityAvailable -= item.Quantity;
                await _productRepository.CreateAsync(_productRepository.GetProductByName(item.Name).Result);
                order.AddItem(orderItem);
            }
            await _orderRepository.CreateAsync(order);
            return new BaseResponse
            {
                Message = "Sucessfully created",
                Status = true
            };
        }
        public async Task<BaseResponse> UpdateOrder(int customerId,CreateOrderRequestModel request)
        {
            var previousOrder = _orderRepository.GetAllAsync().Result.ToList().LastOrDefault(x => x.CustomerId == customerId && x.Status == OrderStatus.NotPaid);
            if (previousOrder == null)
            {
                return new BaseResponse
                {
                    Message = "No order to be updated",
                    Status = false
                };
            }
            foreach( var item in request.Datas)
            {
                var orderItem = new OrderItem
                {
                    ProductId = _productRepository.GetProductByName(item.Name).Result.Id,
                    Quantity = item.Quantity,
                    UnitPrice = _productRepository.GetProductByName(item.Name).Result.SellingPrice,
                    OrderId = previousOrder.Id
                };
                previousOrder.AddItem(orderItem);
                await _productRepository.Delete(previousOrder.Id);
                _productRepository.GetProductByName(item.Name).Result.QuantityAvailable -= item.Quantity;
                await _productRepository.CreateAsync(_productRepository.GetProductByName(item.Name).Result);
            }
            return new BaseResponse
            {
                Message = "Sucessfully updated",
                Status = true
            };
        }
        public async Task<BaseResponse> DeleteOrder(int customerId)
        {
            var previousOrder = _orderRepository.GetAllAsync().Result.ToList().LastOrDefault(x => x.CustomerId == customerId && x.Status == OrderStatus.NotPaid);
            if (previousOrder == null)
            {
                return new BaseResponse
                {
                    Message = "No order to be deleted",
                    Status = false
                };
            }
            foreach( var item in previousOrder.OrderItems)
            {
                _productRepository.GetProductById(item.ProductId).Result.QuantityAvailable += item.Quantity;
                _productRepository.Update(_productRepository.GetProductById(item.ProductId).Result);
            }
            return new BaseResponse
            {
                Message = "Sucessfully deleted",
                Status = true
            };
        }
        public async Task<BaseResponse> Pay(int customerId)
        {
            var previousOrder = _orderRepository.GetAllAsync().Result.ToList().LastOrDefault(x => x.CustomerId == customerId && x.Status == OrderStatus.NotPaid);
            if (previousOrder == null)
            {
                return new BaseResponse
                {
                    Message = "No order to pay for",
                    Status = false
                };
            }
            previousOrder.Paid();
            return new BaseResponse
            {
                Message = "Sucessfully paid for",
                Status = true
            };
        }

        
    }
}