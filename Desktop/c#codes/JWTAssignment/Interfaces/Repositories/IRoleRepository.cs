using System.Linq.Expressions;
using JWTAssignment.Entities;

namespace JWTAssignment.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> CreateAsync(Role entity);
        Role Update(Role entity);
        Task<Role> GetAsync(string name);
        Task<ICollection<Role>> GetAllAsync();
        Task<Role> GetAsync(Expression<Func<Role, bool>> exp);
        Task<bool> ExistAsync(string name);
        Task<Role> Delete(int id);
    }
}