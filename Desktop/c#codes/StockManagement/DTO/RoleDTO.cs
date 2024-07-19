namespace StockManagement.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}