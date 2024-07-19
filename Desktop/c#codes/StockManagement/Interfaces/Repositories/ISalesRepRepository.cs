using StockManagement.Entities;

namespace StockManagement.Interfaces.Repositories
{
    public interface ISalesRepRepository
    {
        SalesRep GetSalesRepById(int id);
        void AddSalesRep(SalesRep salesRep);
        SalesRep UpdateSalesRep( SalesRep salesRep);
        List<SalesRep> GetAllSalesRep();
        bool IfExit (SalesRep salesRep);
        
    }
}