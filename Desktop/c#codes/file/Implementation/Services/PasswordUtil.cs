using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace file.Implementation.Services
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