using System.Text.Json;
using file.Entities;
using file.Interfaces.Repositoritories;

namespace file.Implementation.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string filePath;
        public ProductRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public void Add(Product product)
        {
            List<Product> products = GetAllProducts();
            products.Add(product);
            SaveProducts(products);
        }
        

        private void SaveProducts(List<Product> products)
        {
            var options =  new JsonSerializerOptions{
                WriteIndented = true


            };
            string json = 
             JsonSerializer.Serialize(products, options);
            File.WriteAllText(filePath, json);
        }
        
         public void Delete(int productId)
        {
            List<Product> products = GetAllProducts();
            products.RemoveAll(c => c.Id == productId);
            SaveProducts(products);
        }
        public List<Product>? GetAllProducts()
        {
            if (!File.Exists(filePath))
            return new List<Product>();


            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Product>>(json);
        }
        public Product GetProduct(int id)
        {
            return GetAllProducts().SingleOrDefault(x => x.Id == id && x.IsDeleted == false);
        }
        public Product GetProductByName(string name)
        {
            return GetAllProducts().SingleOrDefault(x => x.Name == name && x.IsDeleted == false);
        }

    }
}