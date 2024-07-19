namespace Transaction.DTO
{
    public class ProductPurchaceDTO
    {
         public int ProductId{get; set;}
        public int PurchaceId{get; set;}
        public int Quantity{get; set;}
        public decimal PurchacedPrice{get; set;}
        public decimal TotalPrice{get; set;}
    }
}