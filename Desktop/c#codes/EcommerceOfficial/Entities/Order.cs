namespace EcommerceOfficial.Entities
{
    public class Order : BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public string CustomerId { get; set; }
        public decimal TotalProduct { get;set; }
    }
}
