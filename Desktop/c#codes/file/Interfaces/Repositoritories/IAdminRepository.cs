using file.Entities;

namespace file.Interfaces.Repositoritories
{
    public interface IAdminRepository
    {
        List<Admin>? GetAllAdmins();
        void Add(Admin admin);
    }
}