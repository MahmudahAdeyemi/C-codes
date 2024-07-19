using Transaction.Entities;

namespace Transaction.Interfaces.Repositories
{
    public interface ISalesRepository
    {
        Sales AddSales(Sales Sales);
        Sales DeleteSales(int id);
        List<Sales> GetAllSales();
        Sales GetSalesById(int id);
        bool IfExit(Sales Sales);
        Sales UpdateSales(Sales Sales);
    }
}