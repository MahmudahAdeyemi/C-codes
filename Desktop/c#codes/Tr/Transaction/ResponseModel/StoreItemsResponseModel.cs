using Transaction.DTO;

namespace Transaction.ResponseModel
{
    public class StoreItemsResponseModel : BaseResponse
    {
        public List<StoreItemDTO> Datas {get; set;} = new List<StoreItemDTO>();
    }
}