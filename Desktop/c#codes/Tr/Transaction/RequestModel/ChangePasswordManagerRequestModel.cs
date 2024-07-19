namespace Transaction.RequestModel
{
    public class ChangePasswordRequestModel
    {
        public string? PreviousPassword {get; set;}
        public string? NewPassword {get; set;}
        public string? ConfirmNewPassword {get; set;}
    }
}