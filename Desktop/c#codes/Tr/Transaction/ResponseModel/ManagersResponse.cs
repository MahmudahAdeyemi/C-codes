using Transaction.DTO;

namespace Transaction.ResponseModel
{
    public class ManagersResponse : BaseResponse
    {
        public List<ManagerDTO> Data {get; set;}
    }
}