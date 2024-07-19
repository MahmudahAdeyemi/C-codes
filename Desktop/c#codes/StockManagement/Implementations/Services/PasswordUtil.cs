using System.Security.Cryptography;
using System.Text;
namespace StockManagement.Implementations.Services
{
    public static class PasswordUtil
    {
        public static string HashPassword(string plainText)
        {
            var hashedPaswordBytes = SHA512.HashData(Encoding.UTF8.GetBytes(plainText));

            StringBuilder builder = new();
            foreach (var b in hashedPaswordBytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}