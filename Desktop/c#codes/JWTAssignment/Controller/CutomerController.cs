using JWTAssignment.Interfaces.Services;
using JWTAssignment.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAssignment.Controller
{
    [ApiController]
    [Route("api/customers")]
    public class CutomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IPersonService _personService; 

        public CutomerController(ICustomerService customerService, IPersonService personService)
        {
            _customerService = customerService;
            _personService = personService;
        }

        [Authorize(Roles = "manager")]
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomer();
            return Ok(customers);
        }
        [Authorize(Roles = "manager")]
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer([FromRoute]int customerId)
        {
            var customer = await _customerService.GetCustomer(customerId);
            return Ok(customer);
        }

        [Authorize(Roles = "manager")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserRequestModel userRequestModel)
        {
                var response =await _personService.CreateCustomer(userRequestModel);
                if (response.Status == true)
                {
                    return Ok(response.Message);
                }
                return BadRequest(response.Message);
            
        }
        [Authorize(Roles = "manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, [FromBody]UserRequestModel userRequestModel)
        {
            var response = await _customerService.UpdateCustomer(id, userRequestModel);
            return Ok(response);
        }
        [Authorize(Roles = "manager")]
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int customerId)
        {
            var response = await _customerService.DeleteCustomer(customerId);
            return Ok(response);
        }
        [Authorize(Roles = "manager,salesperson")]
        [HttpGet("{customerId}/orders")]
        public async Task<IActionResult> GetCustomerOrders([FromRoute] int customerId)
        {
            var orders = await _customerService.GetCustomerOrders(customerId);
            return Ok(orders);
        }



    }
}