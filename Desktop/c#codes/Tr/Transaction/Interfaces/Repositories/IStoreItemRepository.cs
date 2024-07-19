using Transaction.Entities;

namespace Transaction.Interfaces.Repositories
{
    public interface IStoreItemsRepository
    {
        void AddStoreItems(StoreItems storeItems);
        void DeleteStoreItems(StoreItems storeItem);
        List<StoreItems> GetAllStoreItems();
        StoreItems GetStoreItemsById(int id);
        bool IfExit(StoreItems StoreItems);
        StoreItems UpdateStoreItems(StoreItems StoreItems);
        StoreItems GetStoreItemsByName(string name);
    }
}