namespace Transaction.Entities
{
    public class Sales
    {
        public int Id{get; set;}
        public SalesRep SalesRep{get; set;}
        public int SalesRepId{get; set;}
        public DateTime TimeOfTransaction{get; set;} = DateTime.Now;
        public List<SalesProduct>SalesProducts {get; set;} = new List<SalesProduct>();
        public decimal TotalPrice{get; set;}
        public PaymentStatus PaymentStatus {get; set;}
    }
}