using EcommerceOfficial.Interfaces.Services;
using EcommerceOfficial.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceOfficial.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductRequestModel productRequestModel)
        {
            var Products =await _productService.AddProduct(productRequestModel);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> AddToCart(string productId)
        {
            var response =await _productService.AddToCart(productId);
            if (!response.Status)
            {
                return RedirectToAction("Login", "User");
            }
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult> Details(string productid)
        {
            var Product =await _productService.GetProduct(productid);
            return View(Product);
        }
        public async Task<IActionResult> Update(string productId)
        {
            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string productId, ProductRequestModel model)
        {
            await _productService.UpdateProduct(productId, model);
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult >Index()
        {
            var Products = await _productService.GetAllProducts();
            return View(Products);
        }
        public async Task<IActionResult> GetAllProducts()
        {
            var Products = await _productService.GetAllProducts();
            return View(Products);
        }
        public async Task<IActionResult > Seaech(RoleRequestModel model)
        {
            var Products = await _productService.Search(model);
            return View(Products);
        }

    }
}
