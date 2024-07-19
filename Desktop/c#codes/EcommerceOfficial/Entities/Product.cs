namespace EcommerceOfficial.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public string CategoryId { get; set; }
        public int QuantityAvailable { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
