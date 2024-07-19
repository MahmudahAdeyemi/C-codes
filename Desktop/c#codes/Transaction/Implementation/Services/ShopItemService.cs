using Transaction.DTO;
using Transaction.Interfaces.Repositories;
using Transaction.Interfaces.Services;
using Transaction.ResponseModel;

namespace Transaction.Implementation.Services
{
    public class ShopItemService : IShopItemService
    {
        private readonly IShopItemsRepository _shopItemsRepository;

        public ShopItemService(IShopItemsRepository shopItemsRepository)
        {
            _shopItemsRepository = shopItemsRepository;
        }

        public ShopItemResponse GetAllStoreItems()
        {

            var Product = _shopItemsRepository.GetAllShopItems();
            if (Product == null)
            {
                return new ShopItemResponse
                {
                    Status = false,
                    Message = "No store item retrieved"

                };
            }
            var ProductReturned = Product.Select(sr => new ShopItemDTO
            {
                Id = sr.Id,
                Name = sr.Name,
                Quantity = Math.Round(sr.Quantity,2)
            }).ToList();

            return new ShopItemResponse
            {
                Data = ProductReturned,
                Message = "",
                Status = true
            };

        }
    }
}