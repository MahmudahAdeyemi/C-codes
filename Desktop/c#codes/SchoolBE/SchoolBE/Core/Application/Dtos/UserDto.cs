using SchoolBE.Core.Domain.Enums;

namespace SchoolBE.Core.Application.Dtos
{
    public class UserDto
    {
        public string Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public string Token { get; set; } = default!;
        public ICollection<RoleDto> Roles { get; set; } = new HashSet<RoleDto>();
    }

    public class LoginRequestModel
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }

    public class ChangePasswordRequest
    {
        public string Password { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
    }
}
