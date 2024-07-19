using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using file.Entities;
using file.Implementation.Repositories;
using file.Interfaces.Repositoritories;
using file.Interfaces.Services;

namespace file.Implementation.Services
{
    public class AuthService : IAuthService
    {
        public readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository ){
            _userRepository = userRepository;
        }
        

        public bool Login(string userName, string pasword){

            var user = _userRepository.GetAllUsers().FirstOrDefault(x => x.UserName == userName);
            // auth logic
            var hash =  PasswordUtil.HashPassword(pasword); //SHA512.Create().ComputeHash()
            if(user != null && user.PasswordHash == hash){

                AuthenticatedUser.SetAuthUser(user.UserName, user.UserRole);
                return true;

            }

            return false;

        }

        public void Logout(){
            AuthenticatedUser.Clear();
        }

    }

    public static class AuthenticatedUser{

        public static string? UserName {get;private set;}
        public static User.Role? Role {get; private set;}

        public static void SetAuthUser(string userName, User.Role role){
            UserName = userName;
            Role = role;
        }

        public static void Clear(){
            UserName = null;
            Role = null;
        }

    }
}