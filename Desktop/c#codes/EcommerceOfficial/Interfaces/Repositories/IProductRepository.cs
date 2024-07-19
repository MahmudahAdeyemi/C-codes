using EcommerceOfficial.Entities;

namespace EcommerceOfficial.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(string id);
        Task RemoveProduct(string id);
        Task<Product> GetProductByName(string name);
        Task<Product> UpdateProduct(Product product);
        Task<List<Product>> Search(string searchword);
    }
}