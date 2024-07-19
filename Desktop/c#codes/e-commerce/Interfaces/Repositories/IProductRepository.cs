using e_commerce.Entities;

namespace e_commerce.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
    }
}