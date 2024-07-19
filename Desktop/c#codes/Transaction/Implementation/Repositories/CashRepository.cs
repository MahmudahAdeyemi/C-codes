using Microsoft.EntityFrameworkCore;
using Transaction.Entities;
using Transaction.Interfaces.Repositories;

namespace Transaction.Implementation.Repositories
{
    public class CashRepository : ICashRepository
    {
        private readonly TransactionContext _transactionContext;

        public CashRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public Cash AddCash(Cash Cash)
        {
            _transactionContext.Add(Cash);
            _transactionContext.SaveChanges();
            return Cash;
        }
        public List<Cash> GetAllCash()
        {
            var Cashs = _transactionContext.Cashes.ToList();
            return Cashs;
        }
        public void UpdateCash(Cash Cash)
        {
            _transactionContext.Update(Cash);
            _transactionContext.SaveChanges();
        }
    }
}