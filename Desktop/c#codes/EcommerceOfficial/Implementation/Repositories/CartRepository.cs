using EcommerceOfficial.Data;
using EcommerceOfficial.Entities;
using EcommerceOfficial.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EcommerceOfficial.Implementation.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCart(Cart cart)
        {
            _context.Add(cart);
            _context.SaveChanges();
        }
        public async Task<List<Cart>> GetCarts()
        {
            return _context.Carts.ToList();
        }
        public async Task<Cart> CheckProductCarts(Expression<Func<Cart,bool>> expression)
        {
            return await _context.Carts.FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Cart>> CheckOutCarts(Expression<Func<Cart, bool>> expression)
        {
            return await _context.Carts.Where(expression).ToListAsync();
        }
        public async Task<Cart> GetCustomerByCartId(string id)
        {
            return _context.Carts.SingleOrDefault(x => x.CustomerId == id);
        }
    }
}
