using Microsoft.EntityFrameworkCore;
using Transaction.Entities;
using Transaction.Interfaces.Repositories;

namespace Transaction.Implementation.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly TransactionContext _transactionContext;

        public PurchaseRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public Purchace AddPurchace(Purchace purchace)
        {
            _transactionContext.Add(purchace);
            _transactionContext.SaveChanges();
            return purchace;
        }
        public Purchace DeletePurchace(int id)
        {
            Purchace purchace = _transactionContext.Purchaces.Single(x => x.Id == id);
            _transactionContext.Purchaces.Remove(purchace);
            _transactionContext.SaveChanges();
            return purchace;
        }
        public Purchace GetPurchaceById(int id)
        {
            Purchace purchace = _transactionContext.Purchaces.Include(x => x.ProductPurchaces).ThenInclude(x => x.Product).Single(x => x.Id == id);
            return purchace;
        }
        public Purchace UpdatePurchace(Purchace purchace)
        {
            _transactionContext.Purchaces.Update(purchace);
            _transactionContext.SaveChanges();
            return purchace;
        }
        public List<Purchace> GetAllPurchace()
        {
            var purchaces = _transactionContext.Purchaces.ToList();
            return purchaces;
        }
        public bool IfExit(Purchace purchace)
        {
            var c = _transactionContext.Purchaces.Contains(purchace);
            if (c == true)
            {
                return false;
            }
            return true;
        }

    }
}