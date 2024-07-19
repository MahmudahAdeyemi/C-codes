using EcommerceOfficial.Data;
using EcommerceOfficial.Entities;
using EcommerceOfficial.Interfaces.Repositories;

namespace EcommerceOfficial.Implementation.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddOrder(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }
    }
}
