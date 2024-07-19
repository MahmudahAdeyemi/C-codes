using file.RequestModel;
using file.ResponseModel;

namespace file.Interfaces.Services
{
    public interface IStockService
    {
        BaseResponse AddStock(StockRequestModel stockRequestModel);
        
    }
}