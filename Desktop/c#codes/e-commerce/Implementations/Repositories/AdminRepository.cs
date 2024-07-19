using e_commerce.Context;
using e_commerce.Entities;
using e_commerce.Interfaces.Repositories;

namespace e_commerce.Implementations.Repositories
{
    
    public class AdminRepository : IAdminRepository
    {
        private readonly e_commerceContext _e_commerceContext;
        public AdminRepository(e_commerceContext e_CommerceContext)
        {
            _e_commerceContext = e_CommerceContext;
        }
        public Admin CreateAdmin(Admin admin)
        {
            _e_commerceContext.Add(admin);
            _e_commerceContext.SaveChanges();
            return (admin);
        }
        public Admin UpdateAdmin(Admin admin)
        {
            _e_commerceContext.Admins.Update(admin);
            _e_commerceContext.SaveChanges();
            return (admin);
        }
        public void ChangePassword(Admin admin)
        {
            _e_commerceContext.Update(admin);
            _e_commerceContext.SaveChanges();
        }
        public Admin GetAdminById(int id)
        {
            return ( _e_commerceContext.Admins.Single(x => x.Id == id));

        }
    }
}