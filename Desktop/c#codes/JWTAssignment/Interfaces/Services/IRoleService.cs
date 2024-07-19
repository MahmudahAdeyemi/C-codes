using JWTAssignment.ResponseModel;

namespace JWTAssignment.Interfaces.Services
{
    public interface IRoleService
    {
        Task<RoleResponseModel>  GetRole(int id);
        Task<GetAllRolesResponse> GetAllRoles();
        Task<BaseResponse> UpdateRole(int id,string newDescription);
        Task<BaseResponse> DeleteRole(int id);
    }
}