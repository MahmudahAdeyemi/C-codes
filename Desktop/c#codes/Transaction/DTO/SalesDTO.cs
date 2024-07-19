using Transaction.Entities;

namespace Transaction.DTO
{
    public class SalesDTO
    {
        public int Id{get; set;}
        public string? SalesRep{get; set;}
        public decimal TotalPrice{get; set;}
        public DateTime TimeOfTransaction{get; set;} = DateTime.Now;
        public List<string> ProductName{get; set;} = new List<string>();
        public List<decimal> ProductQuantity{get; set;} = new List<decimal>();
        public string PaymentStatus{get; set;}
    }
}