using JWTAssignment.DTOs;

namespace JWTAssignment.ResponseModel
{
    public class GetOrderResponse : BaseResponse
    {
        public OrderDTO Data{get; set;}
    }
}
    