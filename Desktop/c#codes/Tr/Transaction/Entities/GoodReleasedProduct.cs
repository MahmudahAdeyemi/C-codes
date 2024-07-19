namespace Transaction.Entities
{
    public class GoodReleasedProduct
    {
        public int Id{get; set;}
        public Product Product{get; set;}
        public int ProductId{get; set;}
        public GoodReleased GoodReleased{get; set;}
        public int GoodReleasedId{get; set;}
        public decimal Quantity{get; set;}
    }
}