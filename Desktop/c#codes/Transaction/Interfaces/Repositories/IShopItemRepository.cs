using Transaction.Entities;

namespace Transaction.Interfaces.Repositories
{
    public interface IShopItemsRepository
    {
        void DeleteShopItem(ShopItems shopItems);
        void AddShopItems(ShopItems shopItems);
        void DeleteShopItems(ShopItems storeItem);
        List<ShopItems> GetAllShopItems();
        ShopItems GetShopItemsById(int id);
        bool IfExit(ShopItems ShopItems);
        ShopItems UpdateShopItems(ShopItems ShopItems);
        ShopItems GetShopItemsByName(string name);
    }
}