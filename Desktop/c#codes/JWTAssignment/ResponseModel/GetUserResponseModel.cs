using JWTAssignment.DTOs;

namespace JWTAssignment.ResponseModel
{
    public class GetUserResponseModel : BaseResponse
    {
        public UserDTO? Data {get;set;}
    }
}