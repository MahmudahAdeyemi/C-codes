namespace Transaction.Entities
{
    public class ValidClosingStock
    {
        public int Id{get; set;}
        public DateTime Date{get; set;} = DateTime.Now;
        public decimal TotalCash {get; set;}
        public decimal NegativeDifference{get; set;}
        public decimal PositiveDiiference{get; set;}
        public List<ValidClosingStockProduct> ValidClosingStockProducts{get; set;} = new List<ValidClosingStockProduct>();
    }
}