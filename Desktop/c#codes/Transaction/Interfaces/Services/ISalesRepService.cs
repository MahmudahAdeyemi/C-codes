using Transaction.RequestModel;
using Transaction.ResponseModel;

namespace Transaction.Interfaces.Services
{
    public interface ISalesRepService
    {
        BaseResponse AddSalesRep(SalesRepRequestModel salesRepRequestModel);
        BaseResponse DeleteSalesRep(int id);
        SalesRepResponse GetSalesRepById(int id);
        BaseResponse UpdateSalesRep(int id, SalesRepRequestModel salesRepRequestModel);
        SalesRepsResponseModel GetAllSalesResponse();
    }
}