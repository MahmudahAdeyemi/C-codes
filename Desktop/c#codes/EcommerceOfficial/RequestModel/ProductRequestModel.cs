using EcommerceOfficial.Entities;

namespace EcommerceOfficial.RequestModel
{
    public class ProductRequestModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public string Category { get; set; }
        public string Description { get; set; } 
        public IFormFile Image { get; set; }

    }
}
