using Microsoft.AspNetCore.Mvc;
using Transaction.Interfaces.Services;

namespace Transaction.Controllers
{
    public class ShopItemController : Controller
    {
        private readonly IShopItemService _shopItemService;
        public ShopItemController(IShopItemService shopItemService)
        {
            _shopItemService = shopItemService;
        }
        public IActionResult Index()
        {
            var managers =_shopItemService.GetAllStoreItems();
            return View(managers);
        }
    }
}