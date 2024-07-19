using e_commerce.Entities;

namespace e_commerce.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Order AddOrder(Order order);
    }
}