using StockManagement.Context;
using StockManagement.Entities;
using StockManagement.Interfaces.Repositories;

namespace StockManagement.Implementations.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ContextClass _contextClass;
        public AdminRepository(ContextClass contextClass)
        {
            _contextClass = contextClass;
        }
        public void ChangePassword(Admin admin)
        {
            _contextClass.Update(admin);
            _contextClass.SaveChanges();
        }
        public Admin GetAdminById(int id)
        {
            Admin admin = _contextClass.Admin.Single(x => x.Id == id);
            return admin;
        }
    }
}