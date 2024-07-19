namespace e_commerce.Entities
{
    public class Product
    {
        public int Id{get; set;}
        public string Name {get; set;}
        public string? Description {get ;set;}
        public string BrandName {get; set;}
        public List<BrandProduct>BrandProducts{get ;set;}
    }
}