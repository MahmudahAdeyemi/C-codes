using Transaction.Entities;

namespace Transaction.RequestModel
{
    public class PaymentStatusAndDateRequestModel
    {
        public DateTime Date {get; set;}
        public PaymentStatus paymentStatus{get; set;}
    }
}