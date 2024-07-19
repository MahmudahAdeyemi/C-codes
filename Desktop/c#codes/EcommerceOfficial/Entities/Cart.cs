namespace EcommerceOfficial.Entities
{
    public class Cart : BaseEntity
    {
        public int Quantity { get; set; }
        public string? OrderId { get; set; }
        public string ProductId { get; set; }
        public bool IsCheckedOut { get; set; }
        
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
    }
}
