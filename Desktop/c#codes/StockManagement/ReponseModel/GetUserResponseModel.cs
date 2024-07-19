using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.ReponseModel
{
    public class GetUserResponseModel : BaseResponse
    {
        public UserDTO Data {get; set;}
    }
}