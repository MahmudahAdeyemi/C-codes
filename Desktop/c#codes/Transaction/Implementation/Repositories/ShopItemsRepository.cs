using Transaction.Entities;
using Transaction.Interfaces.Repositories;

namespace Transaction.Implementation.Repositories
{
    public class ShopItemsRepository : IShopItemsRepository
    {
        private readonly TransactionContext _transactionContext;

        public ShopItemsRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public void AddShopItems(ShopItems shopItems)
        {
            _transactionContext.Add(shopItems);
            _transactionContext.SaveChanges();
        }
        public void DeleteShopItems(ShopItems storeItem)
        {
            _transactionContext.ShopItems.Remove(storeItem);
            _transactionContext.SaveChanges();
        }
        public ShopItems GetShopItemsById(int id)
        {
            ShopItems shopItems = _transactionContext.ShopItems.Single(x => x.Id == id);
            return shopItems;
        }
        public ShopItems UpdateShopItems(ShopItems ShopItems)
        {
            _transactionContext.Update(ShopItems);
            _transactionContext.SaveChanges();
            return ShopItems;
        }
        public List<ShopItems> GetAllShopItems()
        {
            var shopItemss = _transactionContext.ShopItems.ToList();
            return shopItemss;
        }
        public bool IfExit(ShopItems ShopItems)
        {
            var c = _transactionContext.ShopItems.Contains(ShopItems);
            if (c == true)
            {
                return false;
            }
            return true;
        }
        public void DeleteShopItem(ShopItems shopItems)
        {
            _transactionContext.Remove(shopItems);
            _transactionContext.SaveChanges();
        }
        public ShopItems GetShopItemsByName(string name)
        {
            ShopItems shopItems = _transactionContext.ShopItems.Single(x => x.Name == name);
            return shopItems;
        }
    }
}