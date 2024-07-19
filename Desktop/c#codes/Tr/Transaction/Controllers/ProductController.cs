using Microsoft.AspNetCore.Mvc;
using Transaction.Interfaces.Services;
using Transaction.RequestModel;

namespace Transaction.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }
        public IActionResult Index()
        {
            var Products = _productService.GetAllProductResponse();
            return View(Products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductRequestModel productRequestModel)
        {
            var Products = _productService.AddProduct(productRequestModel);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var Product = _productService.GetProductById(id);
            return View(Product);
        }
        public IActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteProduct(int id)
        {
            var Product = _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var product = _productService.GetProductById(id);

            return View(product);
        }
        [HttpPost]
        public IActionResult Update(int id, ProductRequestModel productRequestModel)
        {
            _productService.UpdateProduct(id,productRequestModel);
            return RedirectToAction("Index");
        }
 
    }
}