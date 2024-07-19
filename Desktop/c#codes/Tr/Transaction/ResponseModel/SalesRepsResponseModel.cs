using Transaction.DTO;

namespace Transaction.ResponseModel
{
    public class SalesRepsResponseModel : BaseResponse
    {
        public List<SalesRepDTO> Data{get; set;} = new List<SalesRepDTO>();
    }
}