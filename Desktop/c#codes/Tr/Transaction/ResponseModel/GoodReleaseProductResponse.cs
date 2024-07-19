using Transaction.DTO;
namespace Transaction.ResponseModel
{
    public class GoodReleasedsResponse : BaseResponse
    {
        public List<GoodRealeasedDTO> Data{get; set;} = new List<GoodRealeasedDTO>();
    }
}