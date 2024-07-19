using Transaction.Entities;

namespace Transaction.Interfaces.Repositories
{
    public interface IValidClosingStockRepository
    {
        void  DeleteValidClosingStock(ValidClosingStock validClosingStock);
        ValidClosingStock AddValidClosingStock(ValidClosingStock ValidClosingStock);
        List<ValidClosingStock> GetAllValidClosingStock();
    }
}