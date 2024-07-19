using JWTAssignment.DTOs;

namespace JWTAssignment.ResponseModel
{
    public class GetAllOrdersResponse : BaseResponse
    {
        public List<OrderDTO> Data{get; set;} = [];
    }
}