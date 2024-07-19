using SchoolBE.Core.Application.Dtos;

namespace SchoolBE.Core.Application.Interfaces.Services
{
    public interface IRoleService
    {
        Task<BaseResponse<RoleDto>> CreateAsync(RoleRequest request);
        Task<BaseResponse<RoleDto>> Update(string id, UpdateRoleRequest request);
        Task<BaseResponse<RoleDto>> GetAsync(string name);
        Task<BaseResponse<ICollection<RoleDto>>> GetAllAsync();
    }
}
