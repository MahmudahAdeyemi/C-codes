using System.Security.Cryptography;
using System.Text;

namespace JWTAssignment.Implementation.Servives
{
    public static class PasswordUtil
    {
        public static string HashPassword(string plainText){

            using(var sha512 = SHA512.Create()){
                
                var hashedPaswordBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                StringBuilder builder = new StringBuilder();
                foreach(var b in hashedPaswordBytes){
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();

            }
        }
    }
}