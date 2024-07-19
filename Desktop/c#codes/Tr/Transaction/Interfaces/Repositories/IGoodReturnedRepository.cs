using Transaction.Entities;

namespace Transaction.Interfaces.Repositories
{
    public interface IGoodReturnedRepository
    {
        GoodsReturned AddGoodsReturned(GoodsReturned GoodsReturned);
        GoodsReturned DeleteGoodsReturned(int id);
        List<GoodsReturned> GetAllGoodsReturned();
        GoodsReturned GetGoodsReturnedById(int id);
        bool IfExit(GoodsReturned GoodsReturned);
        GoodsReturned UpdateGoodsReturned(GoodsReturned GoodsReturned);
    }
}