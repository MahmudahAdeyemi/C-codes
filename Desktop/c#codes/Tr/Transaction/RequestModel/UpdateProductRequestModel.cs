namespace Transaction.RequestModel
{
    public class UpdateProductRequestModel
    {
        public string? Description{get; set;}
        public decimal UnitPrice{get; set;}
        public string? Category{get; set;}
        public decimal? CategoryPrice{get; set;}
        public decimal? CategoryQuantity{get; set;}
    }
}