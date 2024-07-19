using e_commerce.Entities;

namespace e_commerce.Interfaces.Repositories
{
    public interface ICustomerRepostory
    {
        Customer AddCustomer(Customer customer);
        Customer BlockCustomer(int id);
        Customer UpdateCustomer(Customer customer);
    }
}