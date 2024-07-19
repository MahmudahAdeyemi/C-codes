namespace StockManagement.RequestModels
{
    public class ChangePasswordModel
    {
        public string PreviousPassword{get; set;}
        public string NewPassword {get; set;}
        public string ConfirmNewPassword {get; set;}
    }
}