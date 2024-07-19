using StockManagement.Entities;

namespace StockManagement.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        void AddUser(User user);
        User UpdateUser( User user);
        List<User> GetAllUser();
        bool IfExit (User user);
    }
}