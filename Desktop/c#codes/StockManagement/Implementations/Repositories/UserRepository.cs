using   StockManagement.Context;
using StockManagement.Entities;
using StockManagement.Interfaces.Repositories;

namespace StockManagement.Implementations.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly ContextClass _contextClass;

        public UserRepository(ContextClass contextClass)
        {
            _contextClass = contextClass;
        }
        public User GetUserById(int id)
        {
            User user = _contextClass.User.Single(x => x.Id == id);
            return user;
        }
        public void AddUser(User user)
        {
            _contextClass.Add(user);
        }
        public User UpdateUser( User user)
        {
            _contextClass.User.Update(user);
            _contextClass.SaveChanges();
            return user;
        }
        public List<User> GetAllUser()
        {
            var users = _contextClass.User.ToList();
            return users;
        }
        public bool IfExit (User user)
        {
            var c = _contextClass.User.Contains(user);
            if (c == true)
            {
                return false;
            }
            return true;
        }







    } 
}