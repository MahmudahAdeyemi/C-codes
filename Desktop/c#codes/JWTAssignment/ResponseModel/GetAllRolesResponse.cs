using JWTAssignment.DTOs;

namespace JWTAssignment.ResponseModel
{
    public class GetAllRolesResponse : BaseResponse
    {
        public List<RoleDTO> Data{get; set;} = [];
    }
}