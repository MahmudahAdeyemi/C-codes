using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using file.Entities;
using file.Interfaces.Repositoritories;

namespace file.Implementation.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string filePath;
        public UserRepository(string filePath)
        {
            this.filePath = filePath;
        }
        private void SaveUsers(List<User> users)
        {
            var options =  new JsonSerializerOptions{
                WriteIndented = true


            };
            string json = 
             JsonSerializer.Serialize(users, options);
            File.WriteAllText(filePath, json);
        }
        public List<User>? GetAllUsers()
        {
            if (!File.Exists(filePath))
            return new List<User>();


            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<User>>(json);
        }
        public void Add(User user)
        {
            List<User> users = GetAllUsers();
            users.Add(user);
            SaveUsers(users);
        }
        public void Delete(int customerId)
        {
            List<User>? users = GetAllUsers();
            users?.RemoveAll(c => c.Id == customerId);
            if(users != null){
            SaveUsers(users);
            }
        }

    }
}