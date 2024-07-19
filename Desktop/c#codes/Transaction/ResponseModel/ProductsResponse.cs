using Transaction.DTO;

namespace Transaction.ResponseModel
{
    public class ProductsResponse : BaseResponse
    {
        public List<ProductDTO> Data{get; set;} = new List<ProductDTO>();
    }
}