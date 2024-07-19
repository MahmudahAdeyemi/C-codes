namespace Transaction.Entities
{
    public class Cash
    {
        public int Id{get; set;}
        public DateTime dateTime {get;set;}
        public decimal CashToBeSubmitted{get; set;}
        public int SalesRepId {get; set;}
    }
}