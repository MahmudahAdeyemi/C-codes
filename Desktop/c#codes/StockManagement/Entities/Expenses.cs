namespace StockManagement.Entities
{
    public class Expenses
    {
        public int Id{get; set;}
        public DateTime Date{get; set;} = DateTime.Now;
        public string Description{get; set;}
        public double Cost{get; set;}
    }
}