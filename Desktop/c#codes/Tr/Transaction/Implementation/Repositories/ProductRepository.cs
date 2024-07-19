using Transaction.Entities;
using Transaction.Interfaces.Repositories;

namespace Transaction.Implementation.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TransactionContext _transactionContext;

        public ProductRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public void AddProduct(Product product)
        {
            _transactionContext.Add(product);
            _transactionContext.SaveChanges();
        }
        public void DeleteProduct(Product product)
        {
            _transactionContext.Products.Remove(product);
            _transactionContext.SaveChanges();
        }
        public Product GetProductById(int id)
        {
            Product product = _transactionContext.Products.Single(x => x.Id == id);
            return product;
        }
        public Product UpdateProduct(Product product)
        {
            _transactionContext.Update(product);
            _transactionContext.SaveChanges();
            return product;
        }
        public List<Product> GetAllProduct()
        {
            var products = _transactionContext.Products.ToList();
            return products;
        }
        public bool IfExit (Product product)
        {
            var c = _transactionContext.Products.Contains(product);
            if (c == true)
            {
                return false;
            }
            return true;
        }
    }
}