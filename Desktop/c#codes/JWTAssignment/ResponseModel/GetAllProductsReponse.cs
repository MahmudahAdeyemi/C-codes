using JWTAssignment.DTOs;

namespace JWTAssignment.ResponseModel
{
    public class GetAllProductsReponse
    {
        public List<ProductDTO> Data{get; set;} = [];
    }
}