using Microsoft.EntityFrameworkCore;
using Transaction.Entities;
using Transaction.Interfaces.Repositories;

namespace Transaction.Implementation.Repositories
{
    public class OpeningStockRepository : IOpeningStockRepository
    {
        private readonly TransactionContext _transactionContext;
        public OpeningStockRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public OpeningStock AddOpeningStock(OpeningStock OpeningStock)
        {
            _transactionContext.Add(OpeningStock);
            _transactionContext.SaveChanges();
            return OpeningStock;
        }
        public List<OpeningStock> GetAllOpeningStock()
        {
            var OpeningStocks = _transactionContext.OpeningStocks.Include(x => x.OpeningStockProducts).ThenInclude(x => x.Product).ToList();
            return OpeningStocks;
        }
        public void DeleteOpeningStock(OpeningStock OpeningStock)
        {
            _transactionContext.Remove(OpeningStock);
            _transactionContext.SaveChanges();
        }
        
    }
}