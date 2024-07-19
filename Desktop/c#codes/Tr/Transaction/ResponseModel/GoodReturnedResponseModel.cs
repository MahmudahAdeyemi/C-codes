using Transaction.DTO;

namespace Transaction.ResponseModel
{
    public class GoodReturnedsResponseModel : BaseResponse
    {
        public List<GoodReturnedDTO> Data{get; set;} = new List<GoodReturnedDTO>();
    }
}