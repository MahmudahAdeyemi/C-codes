namespace Transaction.RequestModel
{
    public class ProductRequestModel
    {
        public string? Name {get; set;}
        public string? Description {get; set;}
        public string? UnitOfMeasurement {get; set;}
        public string? Category{get; set;}
        public decimal? CategoryQuantity{get; set;}
        public decimal? CategoryPrice{get; set;}
        public decimal UnitPrice{get; set;}
    }
}