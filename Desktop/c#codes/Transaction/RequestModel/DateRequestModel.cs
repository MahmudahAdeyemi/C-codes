namespace Transaction.RequestModel
{
    public class DateRequestModel
    {
        public DateTime StartingDate {get; set;} = new DateTime();
        public DateTime EndingDate{get; set;} = new DateTime();
    }
}