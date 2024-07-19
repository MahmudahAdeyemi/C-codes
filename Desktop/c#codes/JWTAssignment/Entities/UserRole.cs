namespace JWTAssignment.Entities
{
    public class UserRole
    {
        public int Id { get; set; } = GenerateUniqueOrderNo();
        public int UserId { get; set; } 
        public User User { get; set; } = default!;
        public int RoleId { get; set; }
        public Role Role { get; set; } = default!;

        private static int GenerateUniqueOrderNo(){

            var rand = new Random();
            return rand.Next(1, int.MaxValue);

        }
    }
}