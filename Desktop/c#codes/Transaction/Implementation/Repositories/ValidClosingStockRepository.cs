using Microsoft.EntityFrameworkCore;
using Transaction.Entities;
using Transaction.Interfaces.Repositories;
namespace Transaction.Implementation.Repositories
{
    public class ValidClosingStockRepository : IValidClosingStockRepository
    {
        private readonly TransactionContext _transactionContext;
        public ValidClosingStockRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public ValidClosingStock AddValidClosingStock(ValidClosingStock ValidClosingStock)
        {
            _transactionContext.Add(ValidClosingStock);
            _transactionContext.SaveChanges();
            return ValidClosingStock;
        }
        public List<ValidClosingStock> GetAllValidClosingStock()
        {
            var ValidClosingStocks = _transactionContext.ValidClosingStocks.Include(x => x.ValidClosingStockProducts).ThenInclude(x => x.Product).ToList();
            return ValidClosingStocks;
        }
        public void  DeleteValidClosingStock(ValidClosingStock validClosingStock)
        {
            _transactionContext.Update(validClosingStock);
            _transactionContext.SaveChanges();
        }
    }
}