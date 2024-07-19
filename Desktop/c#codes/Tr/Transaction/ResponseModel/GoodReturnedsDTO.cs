using Transaction.DTO;

namespace Transaction.ResponseModel;

public class GoodReturnedResponseModel : BaseResponse
{
    public GoodReturnedDTO Data{get; set;} = new GoodReturnedDTO();
}