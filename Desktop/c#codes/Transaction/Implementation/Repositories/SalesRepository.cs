using Microsoft.EntityFrameworkCore;
using Transaction.Entities;
using Transaction.Interfaces.Repositories;

namespace Transaction.Implementation.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly TransactionContext _transactionContext;

        public SalesRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public Sales AddSales(Sales Sales)
        {
            _transactionContext.Add(Sales);
            _transactionContext.SaveChanges();
            return Sales;
        }
        public Sales DeleteSales(int id)
        {
            Sales Sales = _transactionContext.Sales.Single(x => x.Id == id);
            _transactionContext.Sales.Remove(Sales);
            _transactionContext.SaveChanges();
            return Sales;
        }
        public Sales GetSalesById(int id)
        {
            Sales Sales = _transactionContext.Sales.Include(x => x.SalesProducts).ThenInclude(x => x.Product).Single(x => x.Id == id);
            return Sales;
        }
        public Sales UpdateSales(Sales Sales)
        {
            _transactionContext.Sales.Update(Sales);
            _transactionContext.SaveChanges();
            return Sales;
        }
        public List<Sales> GetAllSales()
        {
            var Sales = _transactionContext.Sales.Include(x => x.SalesProducts).ThenInclude(x => x.Product).ToList();
            return Sales;
        }
        public bool IfExit(Sales Sales)
        {
            var c = _transactionContext.Sales.Contains(Sales);
            if (c == true)
            {
                return false;
            }
            return true;
        }

    }
}