namespace e_commerce.Entities
{
    public class BrandProduct
    {
        public int Id {get; set;}
        public Product Product{get; set;}
        public int ProductId{get; set;}
        public Brand Brand {get; set;}
        public int BrandId{get; set;}
        public int QuantityAvailable{get; set;}
        
    }
}