namespace StockManagement.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserEmail { get; set;}
        public string UserName { get; set;}
        public string Password { get; set;}
        public string Token {get; set;}
        public RoleDTO Role {get; set;}
    }
}