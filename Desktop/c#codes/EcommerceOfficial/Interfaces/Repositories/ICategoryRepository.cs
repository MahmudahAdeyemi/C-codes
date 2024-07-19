using EcommerceOfficial.Entities;

namespace EcommerceOfficial.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task AddCategory(Category category);
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategory(string id);
        Task<Category> GetCategoryByName(string name);
        Task<List<Product>> GetProducts(string id);
        Task DeleteProduct(string id);
        Task<List<Product>> GetProductsCategory(string id);
    }
}