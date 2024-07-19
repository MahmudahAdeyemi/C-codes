namespace Transaction.DTO
{
    public class GoodRealeasedDTO
    {
        public int Id { get; set; }
        public DateTime DateReleased { get; set; } = DateTime.Now;
        public List<string> ProductName { get; set; } = new List<string>();
        public List<decimal> Quantity { get; set; } = new List<decimal>();
    }
}