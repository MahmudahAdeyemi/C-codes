using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Transaction.Entities;
using Transaction.Interfaces.Services;
using Transaction.RequestModel;
namespace Transaction.Controllers
{
    public class SalesController : Controller
    {
        IShopItemService _shopItemService;
        private readonly ISalesRepService _salesRepService;
        private readonly IProductService _productService;
        private readonly IStoreKeepingService _storeKeepingService;
        private readonly ISalesService _salesService;

        public SalesController(IShopItemService shopItemService,ISalesRepService salesRepService, IProductService productService, IStoreKeepingService storeKeepingService, ISalesService salesService)
        {
            _shopItemService = shopItemService;
            _salesRepService = salesRepService;
            _productService = productService;
            _storeKeepingService = storeKeepingService;
            _salesService = salesService;
        }
        public IActionResult Index()
        {
            var sales = _salesService.GetAllPurchase();
            return View(sales);
        }

        public IActionResult Details(int id)
        {
            var sales = _salesService.GetPurchaseById(id);
            return View(sales);
        }
        public IActionResult GetSalesInADay()
        {
           var sales =  _salesService.GetSalesInADay();
            return View(sales);
        }
        [HttpGet]
        public IActionResult   GetSalesInDay()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetSalesInDay(DateRequestModel dateRequestModel)
        {
            TempData["StartingDate"] = dateRequestModel.StartingDate;
            TempData["EndingDate"] = dateRequestModel.EndingDate;
            return RedirectToAction("SalesToBeReturned");
        }
        public IActionResult SalesToBeReturned()
        {
            DateTime StartingDate = (DateTime)TempData["StartingDate"];
            DateTime EndingDate = (DateTime)TempData["EndingDate"];
            var sales = _salesService.GetSalesInRange(StartingDate,EndingDate);
            return View(sales);
        }
        [HttpGet]
        public IActionResult GetOpeningStock()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetOpeningStock(OneDateRequestModel dateRequestModel)
        {
            TempData["Date"] = dateRequestModel.OpeningStockDate;
            return RedirectToAction("OpeningStock");
        }
        public IActionResult OpeningStock()
        {
            DateTime Date = (DateTime)TempData["Date"];
            var sales = _salesService.GetOpeningSock(Date);
            return View(sales);
        }
        [HttpGet]
        public IActionResult GetClosingStock()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetClosingStock(OneDateRequestModel dateRequestModel)
        {
            TempData["Date"] = dateRequestModel.OpeningStockDate;
            return RedirectToAction("ClosingStock");
        }
        public IActionResult ClosingStock()
        {
            DateTime Date = (DateTime)TempData["Date"];
            var sales = _salesService.GetClosingSock(Date);
            return View(sales);
        }
        [HttpGet]
        public IActionResult GetGoodsReleased()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetGoodsReleased(OneDateRequestModel dateRequestModel)
        {
            TempData["Date"] = dateRequestModel.OpeningStockDate;
            return RedirectToAction("GoodsReleased");
        }
        public IActionResult GoodsReleased()
        {
            DateTime Date = (DateTime)TempData["Date"];
            var sales = _salesService.GetGoodReleasedsPerDay(Date);
            return View(sales);
        }
        [HttpGet]
        public IActionResult GetGoodsReturned()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetGoodsReturned(OneDateRequestModel dateRequestModel)
        {
            TempData["Date"] = dateRequestModel.OpeningStockDate;
            return RedirectToAction("GoodsReturned");
        }
        public IActionResult GoodsReturned()
        {
            DateTime Date = (DateTime)TempData["Date"];
            var sales = _salesService.GetGoodReturnedPerDay(Date);
            return View(sales);
        }
        [HttpGet]
        public IActionResult GetSalesRep()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetSalesRep(GetFullNameRequestModel getFullNameRequestModel)
        {
            TempData["FirstName"] = getFullNameRequestModel.FirstName;
            TempData["LastName"] = getFullNameRequestModel.LastName;
            return RedirectToAction("SalesRep");
        }
        public IActionResult SalesRep()
        {
            string FirstName = TempData["FirstName"].ToString();
            string LastName = TempData["LastName"].ToString();
            var sales = _salesService.GetSalesRepThatSoldGood(FirstName,LastName);
            return View(sales);
        }
        [HttpGet]
        public IActionResult GetDateandPaymentStatus()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetDateandPaymentStatus(PaymentStatusAndDateRequestModel paymentStatusAndDateRequestModel)
        {
            TempData["PaymentStatus"] = paymentStatusAndDateRequestModel.paymentStatus;
            TempData ["Date"] = paymentStatusAndDateRequestModel.Date;
            return RedirectToAction("ReturnSales");
        }
        public IActionResult ReturnSales()
        {
            PaymentStatus paymentStatus =(PaymentStatus)TempData["PaymentStatus"];
            DateTime Date = (DateTime)TempData["Date"];
            var sales = _salesService.GetSalesByPaymentStatusAndDate(paymentStatus,Date);
            return View(sales);
        }
         
        [HttpGet]
        public IActionResult GetDate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetDate(GetFullNameDate getFullNameDate)
        {
            TempData["Date"] = getFullNameDate.Datte;
            TempData["FirstName"] = getFullNameDate.FirstName;
            TempData["LastName"] = getFullNameDate.LastName;
            return RedirectToAction("AccountBalance");
        }
        public IActionResult AccountBalance()
        {
            DateTime Date = (DateTime)TempData["Date"];
            string FirstName = (string)TempData["FirstName"];
            string LastName = (string)TempData["LastName"];
            var sales = _salesService.CheckAccount(Date,FirstName,LastName);
            return View(sales);
        }

    }
}