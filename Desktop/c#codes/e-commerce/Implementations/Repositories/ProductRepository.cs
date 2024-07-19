using e_commerce.Context;
using e_commerce.Entities;
using e_commerce.Interfaces.Repositories;

namespace e_commerce.Implementations.Repositories
{
    

    public class ProductRepository : IProductRepository
    {
        private readonly e_commerceContext _e_commerceContext;
        public ProductRepository(e_commerceContext e_CommerceContext)
        {
            _e_commerceContext = e_CommerceContext;
        }
        public Product AddProduct(Product product)
        {
            _e_commerceContext.Add(product);
            _e_commerceContext.SaveChanges();
            return product;
        }
        public Product UpdateProduct(Product product)
        {
            _e_commerceContext.Update(product);
            _e_commerceContext.SaveChanges();
            return product;
        }
    }
}