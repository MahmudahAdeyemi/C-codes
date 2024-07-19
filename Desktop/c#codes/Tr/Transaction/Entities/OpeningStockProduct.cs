namespace Transaction.Entities
{
    public class OpeningStockProduct
    {
        public int Id{get; set;}
        public Product Product{get; set;}
        public int ProductId{get; set;}
        public OpeningStock OpeningStock{get; set;}
        public int OpeningStockId{get; set;}
        public decimal Quantity{get; set;}
    }
}