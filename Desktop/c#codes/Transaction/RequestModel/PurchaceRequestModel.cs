namespace Transaction.RequestModel
{
    public class PurchaceRequestModel
    {
        public List<int> ProductIds{get; set;} = new List<int>();
        public List<decimal> Quantities{get; set;} = new List<decimal>();
        public List<decimal> PurchacedPrice{get; set;} = new List<decimal>();
    }
}