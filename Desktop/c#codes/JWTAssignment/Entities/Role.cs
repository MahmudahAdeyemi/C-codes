namespace JWTAssignment.Entities
{
    public class Role
    {
        public int Id { get; set; } = GenerateUniqueOrderNo();
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
        private static int GenerateUniqueOrderNo(){

            var rand = new Random();
            return rand.Next(1, int.MaxValue);

        }
    }
}
    