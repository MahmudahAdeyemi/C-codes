namespace Transaction.Entities
{
    public class Purchace
    {
        public int Id{get; set;}
        public DateTime Date{get; set;} = DateTime.Now;
        public string PurchaceReferenceNumber{get; set;}
        public decimal TotalPrice{get; set;}
        public List<ProductPurchace> ProductPurchaces{get; set;} = new  List<ProductPurchace>();
    }
}