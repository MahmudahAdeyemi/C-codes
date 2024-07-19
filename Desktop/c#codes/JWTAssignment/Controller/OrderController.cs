using JWTAssignment.Interfaces.Services;
using JWTAssignment.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAssignment.Controller
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [Authorize(Roles = "manager,salesperson")]
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }
        
        [Authorize(Roles = "manager,salesperson")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder([FromRoute]int id)
        {
            var order = await _orderService.GetOrder(id);
            return Ok(order);
        }
        [Authorize(Roles = "salesperson")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromQuery] int customerId,[FromBody] CreateOrderRequestModel model )
        {
            var response = await _orderService.CreateOrder(customerId,model);
            return Ok(response.Message);
        }
        [Authorize(Roles = "salesperson")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id,[FromBody] CreateOrderRequestModel model )
        {
            var response = await _orderService.UpdateOrder(id,model);
            return Ok(response.Message);
        }
        
        [Authorize(Roles = "salesperson")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var response = await _orderService.DeleteOrder(id);
            return Ok(response.Message);
        }

        [Authorize(Roles = "salesperson")]
        [HttpPut("Pay")]
        public async Task<IActionResult> Pay([FromRoute]int customerId)
        {
            var response = await _orderService.Pay(customerId);
            return Ok(response.Message);
        }


    }
}