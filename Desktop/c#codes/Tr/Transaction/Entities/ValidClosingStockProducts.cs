namespace Transaction.Entities
{
    public class ValidClosingStockProduct
    {
        public int Id{get; set;}
        public ValidClosingStock ValidClosingStock {get; set;}
        public int ValidClosingStockId {get; set;}
        public Product Product {get; set;}
        public int ProductId{get; set;}
        public decimal Quantities{get; set;}
    }
}