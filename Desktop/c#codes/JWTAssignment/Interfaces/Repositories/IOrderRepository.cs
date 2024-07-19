using JWTAssignment.Entities;

namespace JWTAssignment.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order entity);
        Task<ICollection<Order>> GetAllAsync();
        Order Update(Order entity);
        Task<Order> Delete(int id);
        Task<Order> GetOrderById(int id);
    }
}
    