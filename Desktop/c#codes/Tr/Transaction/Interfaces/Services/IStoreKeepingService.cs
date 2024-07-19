using Transaction.Entities;
using Transaction.RequestModel;
using Transaction.ResponseModel;

namespace Transaction.Interfaces.Services
{
    public interface IStoreKeepingService
    {
        public BaseResponse AddGoodsToStore(PurchaceRequestModel purchaceRequestModel);
        StoreItemsResponseModel GetAllStoreItems();
        public BaseResponse ReleaseGoodsToShop(GoodReleasedRequestModel goodReleasedRequestModel);
        public BaseResponse UpdatePurchasedItems(int id, UpdatePurchaceItemRequestModel updatePurchaceItem);
        // public BaseResponse UpdateReleasdItems(int id, UpdateGoodReleasedItemsRequestModel updateGoodReleasedItems);
        // public BaseResponse DeletePurchasedGood(int id);
        // public BaseResponse DeleteReleasedGood(int id);
        // public PurchaceResponseModel GetAllPurchaces();
        
        // public GoodReleaseResponseModel GetAllGoodsReleased();
        BaseResponse ReturnGoodsToStore(GoodReleasedRequestModel goodReleasedRequestModel);
        public PurchacesResponseModel GetPurchacesByMonth(Month month);
        // public GoodReleaseResponseModel GetGoodReleasedByMonth(int month);
    }
}