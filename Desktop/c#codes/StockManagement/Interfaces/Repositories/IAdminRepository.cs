using StockManagement.Entities;

namespace StockManagement.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        void ChangePassword(Admin admin);
        Admin GetAdminById(int id);
    }
}