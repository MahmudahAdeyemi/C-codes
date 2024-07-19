using JWTAssignment.Interfaces.Services;
using JWTAssignment.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAssignment.Controller
{
    [ApiController]
    [Route("api/products")]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute]int Id)
        {
            var poduct =  await _productService.GetProduct(Id);
            return Ok(poduct);
        }
        [Authorize(Roles = "manager")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequestModel productRequestModel)
        {
            var response = await _productService.AddProduct(productRequestModel);
            return Ok(response.Message);
        }
        [Authorize(Roles = "manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]int id, [FromBody]ProductRequestModel productRequestModel)
        {
            var Product = await _productService.UpdateProduct(id,productRequestModel);
            return Ok(Product.Message);

        }
        [Authorize(Roles = "manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int id)
        {
            var response = await _productService.DeleteProduct(id);
            return Ok(response.Message);
        }


    }
}