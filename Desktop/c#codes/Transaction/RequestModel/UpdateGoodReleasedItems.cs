namespace Transaction.RequestModel
{
    public class UpdateGoodReleasedItemsRequestModel
    {
         public List<int> ProductId{get; set;} = new List<int>();
        public List<int> Quantity{get; set;} = new List<int>();
    }
}