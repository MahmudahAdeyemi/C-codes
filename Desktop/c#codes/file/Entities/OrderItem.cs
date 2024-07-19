namespace file.Entities
{
    public class OrderItem
    {
        public int Id{get; private set;} = GenerateUniqueOrderNo();
        public int ProductId{get; set;}
        public double Quantity {get; set;}
        public double UnitPrice {get; set;}
        public double Vat {get; set;} =5.00;
        public double TotalVat => UnitPrice * Vat/100D * Quantity;
        
        public double TotalPrice => Quantity * UnitPrice + TotalVat;

        private static int GenerateUniqueOrderNo(){

            var rand = new Random();
            return rand.Next(1, int.MaxValue);

        }
    }
}