namespace Transaction.Entities
{
    public class OpeningStock
    {
        public int Id{get; set;}
        public DateTime Date{get; set;}
        public List<OpeningStockProduct> OpeningStockProducts{get; set;} = new List<OpeningStockProduct>();
    }
}