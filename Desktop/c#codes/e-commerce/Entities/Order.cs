namespace e_commerce.Entities
{
    public class Order
    {
        public int Id{get; set;}
        public List<Product>ProductsList{get; set;}
        public int TotalPrice{get; set;}
        public int CartId {get; set;}
    }
}
