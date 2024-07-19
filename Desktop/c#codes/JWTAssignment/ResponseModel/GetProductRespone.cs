using JWTAssignment.DTOs;

namespace JWTAssignment.ResponseModel
{
    public class GetProductRespone : BaseResponse
    {
        public ProductDTO Data{get; set;}
    }
}