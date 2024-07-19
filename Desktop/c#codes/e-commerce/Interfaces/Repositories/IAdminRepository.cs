using e_commerce.Entities;

namespace e_commerce.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        void ChangePassword(Admin admin);
        Admin CreateAdmin(Admin admin);
        Admin UpdateAdmin(Admin admin);
        Admin GetAdminById(int id);
    }

}