using Transaction.Entities;
using Transaction.RequestModel;
using Transaction.ResponseModel;

namespace Transaction.Interfaces.Services
{
    public interface ISalesService
    {
        DecimalResponseModel AddSales(SalesRequestModel salesRequestModel, int SalesRepId);
        DecimalResponseModel CheckAccount(DateTime Date,string FirstName,string LastName);
        SalesResponseModel GetAllPurchase();
        ShopItemResponse GetClosingSock(DateTime dateTime);
        GoodReleasedsResponse GetGoodReleasedsPerDay(DateTime Date);
        GoodReturnedsResponseModel GetGoodReturnedPerDay(DateTime Date);
        ShopItemResponse GetOpeningSock(DateTime dateTime);
        SalesResponse GetPurchaseById(int id);
        SalesResponseModel GetSalesByPaymentStatusAndDate(PaymentStatus paymentStatus, DateTime Date);
        SalesResponseModel GetSalesInADay();
        SalesResponseModel GetSalesInDay(DateTime Date);
        SalesResponseModel GetSalesInRange(DateTime InitialDate, DateTime LatstDate);
        SalesResponseModel GetSalesRepThatSoldGood(string FirstName, string LastName);
        BaseResponse InputClosingstockForTheDay(decimal TotalCash,int SalesRepId);
    }
}