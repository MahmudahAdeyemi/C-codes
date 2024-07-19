using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Transaction.Entities;
using Transaction.Interfaces.Services;
using Transaction.RequestModel;
namespace Transaction.Controllers
{
    public class PurchaceController : Controller
    {
        private readonly IProductService _productService;
        private readonly IStoreKeepingService _storeKeepingService;
        private readonly IPurchaseService _purchaseservicee;
        public PurchaceController(IProductService productService, IPurchaseService purchaseservicee, IStoreKeepingService storeKeepingService)
        {
            _productService = productService;
            _purchaseservicee = purchaseservicee;
            _storeKeepingService = storeKeepingService;
        }
        public IActionResult Index()
        {
            var purchases = _purchaseservicee.GetAllPurchase();
            return View(purchases);
        }
        public IActionResult Details(int id)
        {
            var purchace = _purchaseservicee.GetPurchaseById(id);
            return View(purchace);
        }
        [HttpGet]
        public IActionResult NoOfProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NoOfProduct(int id, GetNoOfProductToBeAdded getNoOfProductToBeAdded)
        {
            TempData["NoOfProducts"] = getNoOfProductToBeAdded.NumberToBeAdded;
            TempData["Id"] = id;
            return RedirectToAction("Update");
        }
        [HttpGet]
        public IActionResult Update()
        {
            int id = int.Parse(TempData["Id"].ToString());
            var products = _productService.GetAllProductResponse();
            ViewData["products"] = new SelectList(products.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Update(UpdatePurchaceItemRequestModel updatePurchaceItemRequestModel)
        {
            int id = int.Parse(TempData["Id"].ToString());
            _storeKeepingService.UpdatePurchasedItems(id, updatePurchaceItemRequestModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetPurchaseByMonth()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetPurchaseByMonth(Month month)
        {
            TempData["month"] = month;
            return RedirectToAction("GetPurchase");
        }
        public IActionResult GetPurchase()
        {
            Month month = (Month)TempData["month"];
            var data = _storeKeepingService.GetPurchacesByMonth(month);
            return View(data);
        }

    }
}