using EcommerceOfficial.Data;
using EcommerceOfficial.Entities;
using EcommerceOfficial.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcommerceOfficial.Implementation.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public async Task<Customer> GetCustomerByUserId(string id)
        {
            return  _context.Customers.SingleOrDefault(x => x.UserId == id);
        }

    }
}
