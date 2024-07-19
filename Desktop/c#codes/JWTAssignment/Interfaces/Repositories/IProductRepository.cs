using JWTAssignment.Entities;

namespace JWTAssignment.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product entity);
        Task<ICollection<Product>> GetAllAsync();
        Product Update(Product entity);
        Task<Product> Delete(int id);
        Task<Product> GetProductByName(string name);
        Task<Product> GetProductById(int Id);
    }
}