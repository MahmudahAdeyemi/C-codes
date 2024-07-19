namespace JWTAssignment.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ICollection<UserDTO> Users { get; set; } = new HashSet<UserDTO>();
    }

}