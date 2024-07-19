using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Transaction.Interfaces.Services;
using Transaction.RequestModel;

namespace Transaction.Controllers
{
    public class StoreItemController : Controller
    {
        private readonly IStoreKeepingService _storeKeepingService;
        private readonly IProductService _productService;

        public StoreItemController(IStoreKeepingService storeKeepingService, IProductService productService)
        {
            _storeKeepingService = storeKeepingService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var managers = _storeKeepingService.GetAllStoreItems();
            return View(managers);
        }
        [HttpGet]
        public IActionResult NoOfProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NoOfProduct(GetNoOfProductToBeAdded getNoOfProductToBeAdded)
        {
            TempData["NoOfProducts"] = getNoOfProductToBeAdded.NumberToBeAdded;
            return RedirectToAction("Create");
        }
        [HttpGet]
        public IActionResult Create()
        {
            var products = _productService.GetAllProductResponse();
            ViewData["products"] = new SelectList(products.Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(PurchaceRequestModel purchaceRequestModel)
        {
            _storeKeepingService.AddGoodsToStore(purchaceRequestModel);
            return RedirectToAction("Index");
        }
        public IActionResult NoOfProducttoBeRealesed()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NoOfProducttoBeRealesed(GetNoOfProductToBeAdded getNoOfProductToBeAdded)
        {
            TempData["NoOfProducts"] = getNoOfProductToBeAdded.NumberToBeAdded;
            return RedirectToAction("GoodToBeReleased");
        }
        [HttpGet]
        public IActionResult GoodToBeReleased()
        {
            var products = _productService.GetAllProductResponse();
            ViewData["products"] = new SelectList(products.Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult GoodToBeReleased(GoodReleasedRequestModel goodReleasedProductRequestModel)
        {
            _storeKeepingService.ReleaseGoodsToShop(goodReleasedProductRequestModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult NoOfProducttoBeReturned()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NoOfProducttoBeReturned(GetNoOfProductToBeAdded getNoOfProductToBeAdded)
        {
            TempData["NoOfProducts"] = getNoOfProductToBeAdded.NumberToBeAdded;
            return RedirectToAction("GoodToBeReturned");
        }
        [HttpGet]
        public IActionResult GoodToBeReturned()
        {
            var products = _productService.GetAllProductResponse();
            ViewData["products"] = new SelectList(products.Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult GoodToBeReturned(GoodReleasedRequestModel goodReleasedProductRequestModel)
        {
            _storeKeepingService.ReturnGoodsToStore(goodReleasedProductRequestModel);
            return RedirectToAction("Index");
        }
    }
}