namespace Transaction.Entities
{
    public class GoodsReturned
    {
        public int Id{get; set;}
        public DateTime DateReleased{get; set;} = DateTime.Now;
        public List<GoodsReturnedProduct> GoodsReturnedProducts{get; set;} = new List<GoodsReturnedProduct>();
    }
}