using Microsoft.EntityFrameworkCore;
using Transaction.Entities;
using Transaction.Interfaces.Repositories;

namespace Transaction.Implementation.Repositories
{
    public class GoodReturnedRepository : IGoodReturnedRepository
    {
        private readonly TransactionContext _transactionContext;

        public GoodReturnedRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public GoodsReturned AddGoodsReturned(GoodsReturned GoodsReturned)
        {
            _transactionContext.Add(GoodsReturned);
            _transactionContext.SaveChanges();
            return GoodsReturned;
        }
        public GoodsReturned DeleteGoodsReturned(int id)
        {
            GoodsReturned GoodsReturned = _transactionContext.GoodsReturneds.Single(x => x.Id == id);
            _transactionContext.GoodsReturneds.Remove(GoodsReturned);
            _transactionContext.SaveChanges();
            return GoodsReturned;
        }
        public GoodsReturned GetGoodsReturnedById(int id)
        {
            GoodsReturned GoodsReturned = _transactionContext.GoodsReturneds.Include(x => x.GoodsReturnedProducts).ThenInclude(x => x.Product).Single(x => x.Id == id);
            return GoodsReturned;
        }
        public GoodsReturned UpdateGoodsReturned(GoodsReturned GoodsReturned)
        {
            _transactionContext.GoodsReturneds.Update(GoodsReturned);
            _transactionContext.SaveChanges();
            return GoodsReturned;
        }
        public List<GoodsReturned> GetAllGoodsReturned()
        {
            var GoodsReturneds = _transactionContext.GoodsReturneds.Include(x => x.GoodsReturnedProducts).ThenInclude(x => x.Product).ToList();
            return GoodsReturneds;
        }
        public bool IfExit(GoodsReturned GoodsReturned)
        {
            var c = _transactionContext.GoodsReturneds.Contains(GoodsReturned);
            if (c == true)
            {
                return false;
            }
            return true;
        }


    }
}