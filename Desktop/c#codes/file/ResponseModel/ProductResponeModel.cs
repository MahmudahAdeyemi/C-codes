using file.DTOs;

namespace file.ResponseModel
{
    public class ProductResponseModel : BaseResponse
    {
        public ProductDTO Data {get; set;}
    }
}