using Transaction.DTO;
namespace Transaction.ResponseModel
{
    public class PurchasesResponseModel : BaseResponse
    {
        public List<PurchaceDTO> Data {get; set;} = new List<PurchaceDTO>();
    }
}