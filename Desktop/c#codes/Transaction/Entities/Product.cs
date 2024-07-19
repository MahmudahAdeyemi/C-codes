namespace Transaction.Entities
{
    public class Product
    {
        public int Id{get; set;}
        public string? Name{get; set;}
        public string? Description{get; set;}
        public string? UnitOfMeasurement{get; set;}
        public decimal UnitPrice{get; set;}
        public string? Category{get; set;}
        public decimal? CategoryQuantity{get; set;}
        public decimal? CategoryPrice{get; set;}
        public List<ProductPurchace> ProductPurchaces {get; set;} = new List<ProductPurchace>();
    }
}