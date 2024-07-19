namespace JWTAssignment.Entities
{
    public class Customer
    {
        public int Id{get; private set;} = GenerateUniqueOrderNo();
        public string Name{get; set;}
        public string Email{get; set;}
        public string Address{get; set;}
        public int UserId {get; set;}

        private static int GenerateUniqueOrderNo(){

            var rand = new Random();
            return rand.Next(1, int.MaxValue);
        }
    }
}