using Transaction.Entities;

namespace Transaction.Interfaces.Repositories
{
    public interface IPurchaseRepository
    {
        Purchace AddPurchace(Purchace purchace);
        Purchace DeletePurchace(int id);
        List<Purchace> GetAllPurchace();
        Purchace GetPurchaceById(int id);
        bool IfExit(Purchace purchace);
        Purchace UpdatePurchace(Purchace purchace);
    }
}