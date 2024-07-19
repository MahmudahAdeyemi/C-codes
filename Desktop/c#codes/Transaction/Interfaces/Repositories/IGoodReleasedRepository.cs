using Transaction.Entities;

namespace Transaction.Interfaces.Repositories
{
    public interface IGoodRealesdRepository
    {
        GoodReleased AddGoodReleased(GoodReleased GoodReleased);
        GoodReleased DeleteGoodReleased(int id);
        List<GoodReleased> GetAllGoodReleased();
        GoodReleased GetGoodReleasedById(int id);
        bool IfExit(GoodReleased GoodReleased);
        GoodReleased UpdateGoodReleased(GoodReleased GoodReleased);
    }
}