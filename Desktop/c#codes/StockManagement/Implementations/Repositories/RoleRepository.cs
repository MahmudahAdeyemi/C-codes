using StockManagement.Context;
using StockManagement.Entities;

namespace StockManagement.Implementations.Repositories
{
    public class RoleRepository
    {
        private readonly ContextClass _contextClass;

        public RoleRepository(ContextClass contextClass)
        {
            _contextClass = contextClass;
        }
        public Role GetRoleById(int id)
        {
            Role role = _contextClass.Role.Single(x => x.Id == id);
            return role;
        }

    }
}