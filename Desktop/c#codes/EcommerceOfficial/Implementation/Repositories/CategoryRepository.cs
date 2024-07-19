using EcommerceOfficial.Data;
using EcommerceOfficial.Entities;
using EcommerceOfficial.Interfaces.Repositories;

namespace EcommerceOfficial.Implementation.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public async Task <Category> GetCategory(string id)
        {
            return _context.Categories.SingleOrDefault(x => x.Id == id);
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
        public async Task<Category> GetCategoryByName(string name)
        {
            return _context.Categories.SingleOrDefault(x => x.Name == name);
        }
        public async Task<List<Product>> GetProducts(string id)
        {
            var category =await GetCategory(id);
            return category.Products;

        }
        public async Task DeleteProduct(string id)
        {
            var category =await GetCategory(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
        public async Task<List<Product>> GetProductsCategory(string id )
        {
            return _context.Products.Where(x => x.CategoryId == id).ToList();
        }
    }
}
