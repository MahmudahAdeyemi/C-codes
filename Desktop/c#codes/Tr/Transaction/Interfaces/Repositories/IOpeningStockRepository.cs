using Transaction.Entities;

namespace Transaction.Interfaces.Repositories
{
    public interface IOpeningStockRepository
    {
        OpeningStock AddOpeningStock(OpeningStock OpeningStock);
        void DeleteOpeningStock(OpeningStock OpeningStock);
        List<OpeningStock> GetAllOpeningStock();
    }
}