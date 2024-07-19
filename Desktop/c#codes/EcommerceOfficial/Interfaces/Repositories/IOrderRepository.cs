using EcommerceOfficial.Entities;

namespace EcommerceOfficial.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
    }
}