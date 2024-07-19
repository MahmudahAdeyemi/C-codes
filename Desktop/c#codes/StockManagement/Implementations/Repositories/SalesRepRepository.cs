using StockManagement.Context;
using StockManagement.Entities;
using StockManagement.Interfaces.Repositories;

namespace StockManagement.Implementations.Repositories
{
    public class SalesRepRepository(ContextClass contextClass) : ISalesRepRepository
    {
        private readonly ContextClass _contextClass = contextClass;

        public SalesRep GetSalesRepById(int id)
        {
            SalesRep salesRep = _contextClass.SalesRep.Single(x => x.Id == id);
            return salesRep;
        }


        public void AddSalesRep(SalesRep salesRep)
        {
            _contextClass.Add(salesRep);
        }
        public SalesRep UpdateSalesRep( SalesRep salesRep)
        {
            _contextClass.SalesRep.Update(salesRep);
            _contextClass.SaveChanges();
            return salesRep;
        }
        public List<SalesRep> GetAllSalesRep()
        {
            var salesReps = _contextClass.SalesRep.ToList();
            return salesReps;
        }
        public bool IfExit (SalesRep salesRep)
        {
            var c = _contextClass.SalesRep.Contains(salesRep);
            if (c == true)
            {
                return false;
            }
            return true;
        }

    }
}