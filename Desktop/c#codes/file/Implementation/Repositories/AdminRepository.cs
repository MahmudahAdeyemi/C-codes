using System.Text.Json;
using file.Entities;
using file.Interfaces.Repositoritories;

namespace file.Implementation.Repositories
{
    public class AdminRepository  : IAdminRepository
    {
        private readonly string filePath;
        public AdminRepository(string filePath)
        {
            this.filePath = filePath;
        }
        private void SaveAdmins(List<Admin> admins)
        {
            var options =  new JsonSerializerOptions{
                WriteIndented = true


            };
            string json = 
             JsonSerializer.Serialize(admins, options);
            File.WriteAllText(filePath, json);
        }
        public List<Admin>? GetAllAdmins()
        {
            if (!File.Exists(filePath))
            return new List<Admin>();


            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Admin>>(json);
        }
        public void Add(Admin admin)
        {
            List<Admin> admins = GetAllAdmins();
            admins.Add(admin);
            SaveAdmins(admins);
        }
    }
}
