namespace file.Entities
{
    public class Stock
    {       
        public int Id{get;private set;} = GenerateUniqueOrderNo();
        public DateTime Date {get; private set;} = DateTime.Now;
        public int ProductId {get; set;}
        public int Quantity{get; set;}
        public double CostPrice{get; set;}

        private static int GenerateUniqueOrderNo(){

            var rand = new Random();
            return rand.Next(1, int.MaxValue);

        }
    }
}