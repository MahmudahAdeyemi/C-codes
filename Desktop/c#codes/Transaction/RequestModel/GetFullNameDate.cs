namespace Transaction.RequestModel
{
    public class GetFullNameDate : GetFullNameRequestModel 
    {
        public DateTime Datte{get; set;} = new DateTime();
    }
}