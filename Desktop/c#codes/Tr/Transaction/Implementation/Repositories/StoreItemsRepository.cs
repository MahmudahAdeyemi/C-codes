using Transaction.Entities;
using Transaction.Interfaces.Repositories;

namespace Transaction.Implementation.Repositories
{
    public class StoreItemsRepository : IStoreItemsRepository
    {
        private readonly TransactionContext _transactionContext;

        public StoreItemsRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public void AddStoreItems(StoreItems storeItems)
        {
            _transactionContext.StoreItems.Add(storeItems);
            _transactionContext.SaveChanges();
        }
        public void DeleteStoreItems(StoreItems storeItem)
        {
            _transactionContext.StoreItems.Remove(storeItem);
            _transactionContext.SaveChanges();
        }
        public StoreItems GetStoreItemsById(int id)
        {
            StoreItems storeItems = _transactionContext.StoreItems.Single(x => x.Id == id);
            return storeItems;
        }
        public StoreItems UpdateStoreItems(StoreItems StoreItems)
        {
            _transactionContext.StoreItems.Update(StoreItems);
            _transactionContext.SaveChanges();
            return StoreItems;
        }
        public List<StoreItems> GetAllStoreItems()
        {
            var storeItemss = _transactionContext.StoreItems.ToList();
            return storeItemss;
        }
        public bool IfExit(StoreItems StoreItems)
        {
            var c = _transactionContext.StoreItems.Contains(StoreItems);
            if (c == true)
            {
                return false;
            }
            return true;
        }
        public StoreItems GetStoreItemsByName(string name)
        {
            StoreItems storeItems = _transactionContext.StoreItems.Single(x => x.Name == name);
            return storeItems;
        }
    }
}