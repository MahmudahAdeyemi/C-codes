namespace file.Entities
{
    public class Product
    {
        public int Id{get; private set;} = GenerateUniqueOrderNo();
        public string Name {get; set;}
        public double QuantityAvailable {get; set;}
        public string Description {get; set;}
        public bool IsDeleted {get; set;}
        public Measurement UnitOfMeasurement{get; set;}
        public double CostPrice {get; set;}
        public double SellingPrice {get; set;}
        private static int GenerateUniqueOrderNo(){

            var rand = new Random();
            return rand.Next(1, int.MaxValue);

        }

    }
        
    public enum Measurement{
        Kg,
        Litre
    }
}