using JWTAssignment.DTOs;

namespace JWTAssignment.ResponseModel
{
    public class GetAllCustomersResponse : BaseResponse
    {
        public List<CustomerDTO> Data = [];
    }
}