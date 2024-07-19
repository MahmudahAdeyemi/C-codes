using JWTAssignment.DTOs;

namespace JWTAssignment.ResponseModel
{
    public class GetUsersResponseModel : BaseResponse
    {
        public IEnumerable<UserDTO> Data{get; set;}
    }
}