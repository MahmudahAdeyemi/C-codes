using EcommerceOfficial.Entities;

namespace EcommerceOfficial.ResponseModel
{
    public class GetAllProductsResponseModel
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
    public class ProductDto
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

    }
}

