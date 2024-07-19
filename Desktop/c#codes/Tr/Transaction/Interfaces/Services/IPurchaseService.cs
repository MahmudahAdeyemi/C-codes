using Transaction.ResponseModel;

namespace Transaction.Interfaces.Services
{
    public interface IPurchaseService
    {
        PurchasesResponseModel GetAllPurchase();
        PurchaceResponseModel GetPurchaseById(int id);
    }

}