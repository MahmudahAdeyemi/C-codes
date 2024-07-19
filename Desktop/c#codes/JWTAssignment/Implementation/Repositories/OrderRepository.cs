using JWTAssignment.Context;
using JWTAssignment.Entities;
using JWTAssignment.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JWTAssignment.Implementation.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ContextClass _context;

        public OrderRepository(ContextClass context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(Order entity)
        {
            await _context.Set<Order>().AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }


        public async Task<ICollection<Order>> GetAllAsync()
        {
            return await _context.Set<Order>().ToListAsync();
        }

        public Order Update(Order entity)
        {
            var user = _context.Set<Order>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task<Order> GetOrderById(int id)
        {
            var order = await _context.Set<Order>().FirstAsync(x => x.Id == id);
            return order;
        }
        public async Task<Order> Delete(int id)
        {
            var entity =await _context.Set<Order>().FirstAsync(x => x.Id == id);
            var user = _context.Set<Order>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}