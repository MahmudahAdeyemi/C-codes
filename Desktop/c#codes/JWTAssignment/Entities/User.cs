namespace JWTAssignment.Entities
{
    public class User
    {
        public int Id{get; set;} = GenerateUniqueOrderNo();
        public string UserName {get; set;}
        public string Email {get; set;}
        public string PasswordHash {get;set;}
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();

        private static int GenerateUniqueOrderNo(){

            var rand = new Random();
            return rand.Next(1, int.MaxValue);

        }
    }
}
    