using EcommerceOfficial.Entities;
using System.Linq.Expressions;

namespace EcommerceOfficial.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task AddCart(Cart cart);
        Task<List<Cart>> GetCarts();
        Task<Cart> CheckProductCarts(Expression<Func<Cart, bool>> expression);
        Task<IList<Cart>> CheckOutCarts(Expression<Func<Cart, bool>> expression);
        Task<Cart> GetCustomerByCartId(string id);
    }
}