using Transaction.DTO;

namespace Transaction.ResponseModel
{
    public class SalesResponseModel : BaseResponse
    {
        public List <SalesDTO> Data{get; set;} = new List<SalesDTO>();
    }
}