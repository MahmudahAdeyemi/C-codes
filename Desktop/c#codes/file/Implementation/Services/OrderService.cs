using file.Entities;
using file.Interfaces.Repositoritories;
using file.Interfaces.Services;
using file.RequestModel;
using file.ResponseModel;

namespace file.Implementation.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IOrderRepository orderRepository,IProductRepository productRepository,ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public BaseResponse MakeOrder(OrderRequestModel orderRequest)
        {
            if ( AuthenticatedUser.UserName == null)
            {
                return new BaseResponse
                {
                    Message = "You need to login",
                    Status = false
                };
            }
            var customerId = _customerRepository.GetAllCustomers().Single(x => x.Name == AuthenticatedUser.UserName).Id;
            var lastorder = _orderRepository.GetAllOrders().LastOrDefault(x => x.CustomerId == customerId);
            if (lastorder != null)
            {
                if (lastorder.Status == OrderStatus.NotPaid)
                {
                    OrderLogic(lastorder,orderRequest,customerId);
                    return new BaseResponse
                    {
                        Message = "Order Created",
                        Status = true
                    };           
                }  
            } 
            Order order = new Order();
            OrderLogic(order,orderRequest,customerId);
            return new BaseResponse
                {
                    Message = "Order Created",
                    Status = true
                };
        }
        public BaseResponse Cancel()
        {
            var customerId = _customerRepository.GetAllCustomers().Single(x => x.Name == AuthenticatedUser.UserName).Id;
            var order1 = _orderRepository.GetAllOrders().LastOrDefault(x => x.CustomerId == customerId && x.Status == OrderStatus.NotPaid);
            if (order1 == null)
            {
                return new BaseResponse
                {
                    Message = "No order to cancel",
                    Status = false
                };
            }
            order1.Cancel();
            return new BaseResponse
            {
                Message = "Order has been cancelled",
                Status = true
            };
        }
        private void OrderLogic(Order order,OrderRequestModel orderRequest,int customerId)
        {
            foreach (var item in orderRequest.Orders)
            {
                OrderItem orderItem = new OrderItem
                {
                    ProductId = _productRepository.GetProductByName(item.Product).Id,
                    UnitPrice = _productRepository.GetProductByName(item.Product).SellingPrice,
                    Quantity = item.Quantity
                };
                order.AddItem(orderItem);
                order.CustomerId = customerId;
                var product = _productRepository.GetProduct(orderItem.ProductId);
                product.QuantityAvailable -= orderItem.Quantity;
                _productRepository.Delete(orderItem.ProductId);
                _productRepository.Add(product);

            }
        }
        public BaseResponse Pay(double TotalAmoutnInWallet)
        {
            var customerId = _customerRepository.GetAllCustomers().Single(x => x.Name == AuthenticatedUser.UserName).Id;
            var order = _orderRepository.GetAllOrders().LastOrDefault(x => x.CustomerId == customerId && x.Status == OrderStatus.NotPaid);
            var orderItems = order.OrderItems.ToList();
            double TotalPrice = 0;
            foreach (var item in orderItems)
            {
                TotalPrice += item.TotalPrice;
            }
            if (TotalAmoutnInWallet< TotalPrice)
            {
                return new BaseResponse
                {
                    Message = "Insufficient balance",
                    Status = false
                };
            }
            double amountleftinwallet = TotalAmoutnInWallet - TotalPrice;
            order.Paid();
            return new BaseResponse
            {
                Message = $"Amount left is {amountleftinwallet}",
                Status = true
            };

        }


    }
}