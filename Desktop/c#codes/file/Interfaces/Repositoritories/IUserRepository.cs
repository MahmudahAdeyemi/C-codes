using file.Entities;

namespace file.Interfaces.Repositoritories
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User>? GetAllUsers();
        void Delete(int customerId);
    }
}