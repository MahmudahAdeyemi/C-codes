using file.DTOs;

namespace file.ResponseModel
{
    public class GetAllProductResponse : BaseResponse
    {
        public List<ProductDTO> Data {get; set;} = new List<ProductDTO>();
    }
}