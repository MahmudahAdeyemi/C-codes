using Transaction.ResponseModel;

namespace Transaction.Interfaces.Services
{
    public interface IShopItemService
    {
        ShopItemResponse GetAllStoreItems();
    }
}