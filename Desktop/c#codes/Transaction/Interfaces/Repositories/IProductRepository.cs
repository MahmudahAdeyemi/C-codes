using Transaction.Entities;

namespace Transaction.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> GetAllProduct();
        Product GetProductById(int id);
        Product UpdateProduct(Product product);
        bool IfExit (Product product);
    }
}