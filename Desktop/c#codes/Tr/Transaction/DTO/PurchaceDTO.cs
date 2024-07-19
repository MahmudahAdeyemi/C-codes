namespace Transaction.DTO
{
    public class PurchaceDTO
    {
        public int Id{get; set;}
        public string PurchaceReferenceNumber {get; set;}
        public DateTime Date{get; set;} = DateTime.Now;
        public List<decimal> PurchasedPrice{get; set;} = new List<decimal>();
        public List<decimal> ProductQuantity{get; set;} = new List<decimal>();
        public decimal TotalPrice{get; set;}
        public List<string> ProductName {get; set;} = new List<string>();
    }
}