using e_commerce.Context;
using e_commerce.Entities;
using e_commerce.Interfaces.Repositories;

namespace e_commerce.Implementations.Repositories
{
    

    public class CustomerRepostory : ICustomerRepostory
    {
        private readonly e_commerceContext _e_commerceContext;
        public CustomerRepostory(e_commerceContext e_CommerceContext)
        {
            _e_commerceContext = e_CommerceContext;
        }
        public Customer AddCustomer(Customer customer)
        {
            _e_commerceContext.Add(customer);
            _e_commerceContext.SaveChanges();
            return customer;
        }
        public Customer UpdateCustomer(Customer customer)
        {
            _e_commerceContext.Update(customer);
            _e_commerceContext.SaveChanges();
            return customer;
        }
        public Customer BlockCustomer(int id)
        {
            var customer = _e_commerceContext.Customers.Single(x => x.Id == id);
            _e_commerceContext.Remove(customer);
            _e_commerceContext.SaveChanges();
            return customer;
        }
    }
}