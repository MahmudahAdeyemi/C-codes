using Transaction.DTO;
namespace Transaction.ResponseModel
{
    public class ShopItemResponse : BaseResponse
    {
        public List<ShopItemDTO> Data{get; set;} = new List<ShopItemDTO>();
    }
}