using Transaction.DTO;
namespace Transaction.ResponseModel
{
    public class PurchacesResponseModel : BaseResponse
    {
        public List<PurchaceDTO> Data{get; set;} = new List<PurchaceDTO>();
    }
}