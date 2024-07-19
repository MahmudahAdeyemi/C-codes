using StockManagement.Entities;

namespace StockManagement.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        Customer UpdateCustomer( Customer customer);
        List<Customer> GetAllCustomer();
        bool IfExit (Customer customer);
    }
}