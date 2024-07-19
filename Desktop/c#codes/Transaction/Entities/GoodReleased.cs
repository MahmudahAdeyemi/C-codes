namespace Transaction.Entities
{
    public class GoodReleased
    {
        public int Id{get; set;}
        public DateTime DateReleased{get; set;} = DateTime.Now;
        public List<GoodReleasedProduct> GoodReleasedProducts{get; set;} = new List<GoodReleasedProduct>();
    }
}