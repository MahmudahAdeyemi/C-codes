namespace e_commerce.Entities
{
    public class Brand
    {
        public int Id {get; set;}
        public string Name{get; set;}
        public List<BrandProduct> BrandProducts{get; set;}
    }
}