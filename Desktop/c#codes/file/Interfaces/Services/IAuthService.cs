namespace file.Interfaces.Services
{
    public interface IAuthService
    {
        bool Login(string userName, string pasword);
    }
}