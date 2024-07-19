using System.Linq.Expressions;
using JWTAssignment.Entities;

namespace JWTAssignment.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer entity);
        Customer Update(Customer entity);
        Task<ICollection<Customer>> GetAllAsync();
        Task<bool> ExistAsync(string email);
        Task<Customer>  Delete(int UserId);
        Task<Customer> GetCustomerById(int Id);
    }
}