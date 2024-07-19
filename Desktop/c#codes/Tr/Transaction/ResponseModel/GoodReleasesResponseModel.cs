using Transaction.DTO;

namespace Transaction.ResponseModel
{
    public class GoodReleasesResponseModel : BaseResponse
    {
         public List<GoodRealeasedDTO> Data{get; set;} = new List<GoodRealeasedDTO>();
    }
}