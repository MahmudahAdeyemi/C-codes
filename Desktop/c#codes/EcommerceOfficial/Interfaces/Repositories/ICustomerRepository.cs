using EcommerceOfficial.Entities;

namespace EcommerceOfficial.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task AddCustomer(Customer customer);
        Task<Customer> GetCustomerByUserId(string id);
    }
}