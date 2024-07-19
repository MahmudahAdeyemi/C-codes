using Microsoft.EntityFrameworkCore;
using Transaction.Entities;
using Transaction.Interfaces.Repositories;

namespace Transaction.Implementation.Repositories
{
    public class GoodRealesdRepository : IGoodRealesdRepository
    {
        private readonly TransactionContext _transactionContext;

        public GoodRealesdRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public GoodReleased AddGoodReleased(GoodReleased GoodReleased)
        {
            _transactionContext.Add(GoodReleased);
            _transactionContext.SaveChanges();
            return GoodReleased;
        }
        public GoodReleased DeleteGoodReleased(int id)
        {
            GoodReleased GoodReleased = _transactionContext.GoodReleaseds.Single(x => x.Id == id);
            _transactionContext.GoodReleaseds.Remove(GoodReleased);
            _transactionContext.SaveChanges();
            return GoodReleased;
        }
        public GoodReleased GetGoodReleasedById(int id)
        {
            GoodReleased GoodReleased = _transactionContext.GoodReleaseds.Include(x => x.GoodReleasedProducts).ThenInclude(x => x.Product).Single(x => x.Id == id);
            return GoodReleased;
        }
        public GoodReleased UpdateGoodReleased(GoodReleased GoodReleased)
        {
            _transactionContext.GoodReleaseds.Update(GoodReleased);
            _transactionContext.SaveChanges();
            return GoodReleased;
        }
        public List<GoodReleased> GetAllGoodReleased()
        {
            List<GoodReleased> GoodReleaseds =  _transactionContext.GoodReleaseds.Include(x => x.GoodReleasedProducts).ThenInclude(x => x.Product).ToList();
            return GoodReleaseds;
        }
        public bool IfExit(GoodReleased GoodReleased)
        {
            var c = _transactionContext.GoodReleaseds.Contains(GoodReleased);
            if (c == true)
            {
                return false;
            }
            return true;
        }


    }
}