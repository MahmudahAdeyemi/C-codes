namespace Transaction.Entities
{
    public class ProductPurchace
    {
        public int Id{get; set;}
        public int ProductId{get; set;}
        public int PurchaceId{get; set;}
        public decimal Quantity{get; set;}
        public decimal PurchacedPrice{get; set;}
        public Product Product{get; set;}
        public Purchace Purchace {get; set;}
    }
}   