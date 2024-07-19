using StockManagement.Context;
using StockManagement.Entities;
using StockManagement.Interfaces.Repositories;

namespace StockManagement.Implementations.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ContextClass _contextClass;

        public CustomerRepository(ContextClass contextClass)
        {
            _contextClass = contextClass;
        }
        public Customer GetCustomerById(int id)
        {
            Customer customer = _contextClass.Customer.Single(x => x.Id == id);
            return customer;
        }
        public void AddCustomer(Customer customer)
        {
            _contextClass.Add(customer);
        }
        public Customer UpdateCustomer( Customer customer)
        {
            _contextClass.Customer.Update(customer);
            _contextClass.SaveChanges();
            return customer;
        }
        public List<Customer> GetAllCustomer()
        {
            var customers = _contextClass.Customer.ToList();
            return customers;
        }
        public bool IfExit (Customer customer)
        {
            var c = _contextClass.Customer.Contains(customer);
            if (c == true)
            {
                return false;
            }
            return true;
        }

    }
}