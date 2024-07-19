namespace WebAPI.Services
{
    public class IdentityService
    {
        public bool IsCredentialsValid(UserDto user)
        {
            if(user == null || !(string.Equals(user.UserName,"admin") && string.Equals(user.PassWord,"mypassword")))
            {
                return true;
            }
            else
            {
                return false;
                
            }
        }
    }
}
    