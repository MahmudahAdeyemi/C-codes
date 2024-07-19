using file.Entities;

namespace file.Interfaces.Repositoritories
{
    public interface IProductRepository
    {
         void Add(Product product);
        public void Delete(int productId);
        List<Product>? GetAllProducts();
        Product GetProduct(int id);
        Product GetProductByName(string name);
    }
}