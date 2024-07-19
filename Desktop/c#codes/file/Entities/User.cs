using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace file.Entities
{
    public class User
    {
        public int Id{get; set;} = GenerateUniqueOrderNo();
        public string UserName {get; set;}
        public string PasswordHash {get;set;}

        public Role UserRole {get; set;}

        private static int GenerateUniqueOrderNo(){

            var rand = new Random();
            return rand.Next(1, int.MaxValue);

         

    }

    
        
      public enum Role{
            Admin,
            Customer
        }
    }
}