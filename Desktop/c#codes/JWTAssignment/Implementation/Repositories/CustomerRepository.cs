using System.Linq.Expressions;
using JWTAssignment.Context;
using JWTAssignment.Entities;
using JWTAssignment.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JWTAssignment.Implementation.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ContextClass _context;

        public CustomerRepository(ContextClass context)
        {
            _context = context;
        }

        public async Task<Customer> CreateAsync(Customer entity)
        {
            await _context.Set<Customer>().AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }


        public async Task<bool> ExistAsync(string email)
        {
            return await _context.Set<Customer>().AnyAsync(x => x.Email == email);
        }

        public async Task<ICollection<Customer>> GetAllAsync()
        {
            return await _context.Set<Customer>().ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int Id)
        {
            var customer = await _context.Set<Customer>().FirstOrDefaultAsync(x => x.Id == Id);
            return customer;
        }

        public Customer Update(Customer entity)
        {
            var user = _context.Set<Customer>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task<Customer> Delete(int id)
        {
            var entity =await _context.Set<Customer>().FirstAsync(x => x.UserId == id);
            var user = _context.Set<Customer>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}