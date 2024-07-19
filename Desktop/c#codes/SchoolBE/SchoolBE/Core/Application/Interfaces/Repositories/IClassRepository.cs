using SchoolBE.Core.Domain.Entities;

namespace SchoolBE.Core.Application.Interfaces.Repositories
{
    public interface IClassRepository
    {
        Task<Class> CreateAsync(Class entity);
        Class Update(Class entity);
        Task<Class> GetAsync(string name);
        Task<ICollection<Class>> GetAllAsync();
        Task<bool> ExistAsync(string name);
    }
}
