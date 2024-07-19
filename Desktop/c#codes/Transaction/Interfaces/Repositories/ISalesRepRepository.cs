using Transaction.Entities;
using Transaction.RequestModel;

namespace Transaction.Interfaces.Repositories
{
    public interface ISalesRepRepository
    {
        SalesRep GetSalesRepByName(string FirstName,string LastName);
        void AddSalesRep(SalesRep salesRep);
        SalesRep DeleteSalesRep(int id);
        List<SalesRep> GetAllSalesRep();
        SalesRep GetSalesRepById(int id);
        bool IfExit (SalesRep salesRep);
        SalesRep UpdateSalesRep( SalesRep salesRep);
    }
    
}