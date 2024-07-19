using System.Linq.Expressions;
using JWTAssignment.Entities;

namespace JWTAssignment.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User entity);
        void Update(User entity);
        Task<User> GetAsync(string email);
        Task<User> GetAsync(Expression<Func<User, bool>> exp);
        Task<ICollection<User>> GetAllAsync();
        Task<bool> ExistAsync(string email);
        Task<User> Delete(int id);
        Task<User> DeleteByName(string userName);
    }
}