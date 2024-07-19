using e_commerce.Context;
using e_commerce.Entities;
using e_commerce.Interfaces.Repositories;

namespace e_commerce.Implementations.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private readonly e_commerceContext _e_commerceContext;
        public OrderRepository(e_commerceContext e_CommerceContext)
        {
            _e_commerceContext = e_CommerceContext;
        }
        public Order AddOrder(Order order)
        {
            _e_commerceContext.Add(order);
            _e_commerceContext.SaveChanges();
            return order;
        }
    }
}