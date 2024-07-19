using file.Entities;

namespace file.Interfaces.Repositoritories
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        public void Delete(int customerId);
        List<Customer>? GetAllCustomers();
        Customer? GetCustomer(int id);
    
    }
}