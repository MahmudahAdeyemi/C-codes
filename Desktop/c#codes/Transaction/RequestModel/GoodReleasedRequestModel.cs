namespace Transaction.RequestModel
{
    public class GoodReleasedRequestModel
    {
        public List<int> ProductIds{get; set;} = new List<int>();
        public List<decimal> Quantities{get; set;} = new List<decimal>();
    }
}