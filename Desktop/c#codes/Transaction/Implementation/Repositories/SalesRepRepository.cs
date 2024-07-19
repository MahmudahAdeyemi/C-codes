using Transaction.Entities;
using Transaction.Interfaces.Repositories;
using Transaction.RequestModel;

namespace Transaction.Implementation.Repositories
{
    public class SalesRepRepository : ISalesRepRepository
    {
        private readonly TransactionContext _transactionContext;

        public SalesRepRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public void AddSalesRep(SalesRep salesRep)
        {
            _transactionContext.Add(salesRep);
            _transactionContext.SaveChanges();
        }
        public SalesRep DeleteSalesRep(int id)
        {
            SalesRep salesRep = _transactionContext.SalesReps.Single(x => x.Id == id);
            _transactionContext.SalesReps.Remove(salesRep);
            _transactionContext.SaveChanges();
            return salesRep;
        }
        public SalesRep GetSalesRepById(int id)
        {
            SalesRep salesRep = _transactionContext.SalesReps.Single(x => x.Id == id);
            return salesRep;
        }
        public SalesRep UpdateSalesRep( SalesRep salesRep)
        {
            _transactionContext.SalesReps.Update(salesRep);
            _transactionContext.SaveChanges();
            return salesRep;
        }
        public List<SalesRep> GetAllSalesRep()
        {
            var salesReps = _transactionContext.SalesReps.ToList();
            return salesReps;
        }
        public bool IfExit (SalesRep salesRep)
        {
            var c = _transactionContext.SalesReps.Contains(salesRep);
            if (c == true)
            {
                return false;
            }
            return true;
        }
        public SalesRep GetSalesRepByName(string FirstName,string LastName)
        {
            SalesRep salesRep = _transactionContext.SalesReps.Single(x => x.FirstName == FirstName && x.LastName == LastName);
            return salesRep;
        }
    }
}