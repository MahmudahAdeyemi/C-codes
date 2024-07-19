using StockManagement.Entities;

namespace StockManagement.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Role GetRoleById(int id);
    }
}