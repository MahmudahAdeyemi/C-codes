using Transaction.Entities;

namespace Transaction.RequestModel
{
    public class SalesRequestModel
    {
        public List<int> ProductId{get; set;} = new List<int>();
        public List<decimal> ProductQuantity{get; set;} = new List<decimal>();
        public PaymentStatus PaymentStatus { get; set; }
    }
}