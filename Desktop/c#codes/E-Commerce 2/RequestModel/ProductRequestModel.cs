namespace E_Commerce_2.RequestModel
{
    public class ProductRequestModel
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string Category { get; set; }
    }
}
