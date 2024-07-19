using Transaction.Entities;

namespace Transaction.Interfaces.Repositories
{
    public interface ICashRepository
    {
        Cash AddCash(Cash Cash);
        List<Cash> GetAllCash();
        void UpdateCash(Cash Cash);
    }
}