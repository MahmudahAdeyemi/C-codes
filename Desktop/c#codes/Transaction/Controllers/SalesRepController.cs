using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Transaction.Interfaces.Services;
using Transaction.RequestModel;
using Transaction.ResponseModel;

namespace Transaction.Controllers
{
    public class SalesRepController : Controller
    {
        private readonly ISalesRepService _salesRepService;
        private readonly IProductService _productService;
        private readonly IStoreKeepingService _storeKeepingService;
        private readonly ISalesService _salesService;
        private readonly IShopItemService _shopItemService;
        public SalesRepController(ISalesRepService salesRepService, IProductService productService, IStoreKeepingService storeKeepingService, ISalesService salesService, IShopItemService shopItemService)
        {
            _salesRepService = salesRepService;
            _productService = productService;
            _storeKeepingService = storeKeepingService;
            _salesService = salesService;
            _shopItemService = shopItemService;
        }

        public IActionResult Index()
        {
            var salesReps = _salesRepService.GetAllSalesResponse();
            return View(salesReps);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SalesRepRequestModel salesRepRequestModel)
        {
            var salesReps = _salesRepService.AddSalesRep(salesRepRequestModel);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var salesRep = _salesRepService.GetSalesRepById(id);
            return View(salesRep);
        }
        public IActionResult Delete(int id)
        {
            var salesRep = _salesRepService.GetSalesRepById(id);
            return View(salesRep);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAction(int id)
        {
            var salesRep = _salesRepService.DeleteSalesRep(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var salesRep = _salesRepService.GetSalesRepById(id);
            return View(salesRep);
        }
        [HttpPost]
        public IActionResult Update(int id, SalesRepRequestModel salesRepRequestModel)
        {
            _salesRepService.UpdateSalesRep(id,salesRepRequestModel);
            return RedirectToAction("Index");
        }
        // public IActionResult NoOfProduct()
        // {
        //     return View();
        // }
        // [HttpPost]
        // public IActionResult NoOfProduct (int id, GetNoOfProductToBeAdded getNoOfProductToBeAdded)
        // {
        //     TempData["Id"] = id;
        //     TempData["NoOfProducts"] = getNoOfProductToBeAdded.NumberToBeAdded;
        //     return RedirectToAction("AddSales");
        // }
        [HttpGet]
        public IActionResult AddSales()
        {
            TempData["NoOfProducts"] = _shopItemService.GetAllStoreItems().Data.Count();
            var products = _productService.GetAllProductResponse();
            ViewData["products"] = new SelectList(products.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddSales(int id, SalesRequestModel salesRequestModel)
        {
            decimal t =   _salesService.AddSales(salesRequestModel,id).Data.AmountLeft;
            TempData["TotalPrice"] = t.ToString();
            return RedirectToAction("TotalPrice");
        }
        [HttpGet]
        public IActionResult TotalPrice(TotalPriceResponse model)
        {
            var total = decimal.Parse(TempData["TotalPrice"].ToString());
            model.TotalPrice = total;
            return View(model);
        }
        [HttpGet]
        public IActionResult InputCash(int id)
        {
            TempData["Id"] = id;
            return View();
        }
        [HttpPost]
        public IActionResult InputCash(InputClosingRequestModel inputClosingRequestModel)
        {
            _salesService.InputClosingstockForTheDay(inputClosingRequestModel.TotalCash,int.Parse(TempData["Id"].ToString()));
            return RedirectToAction("Index");
        }
        
    }
}