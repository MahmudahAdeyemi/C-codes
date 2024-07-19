using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using file.Entities;
using file.Interfaces.Repositoritories;

namespace file.Implementation.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string filePath;
        public CustomerRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public void Add(Customer customer)
        {
            List<Customer> customers = GetAllCustomers();
            customers.Add(customer);
            SaveCustomers(customers);
        }

        private void SaveCustomers(List<Customer> customers)
        {
            var options =  new JsonSerializerOptions{
                WriteIndented = true


            };
            string json = 
             JsonSerializer.Serialize(customers, options);
            File.WriteAllText(filePath, json);
        }

        public void Delete(int customerId)
        {
            List<Customer>? customers = GetAllCustomers();
            customers?.RemoveAll(c => c.Id == customerId);
            if(customers != null){
            SaveCustomers(customers);
            }
        }
        public List<Customer>? GetAllCustomers()
        {
            if (!File.Exists(filePath))
            return new List<Customer>();


            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Customer>>(json);
        }
        public Customer? GetCustomer(int id)
        {
            return GetAllCustomers()?.SingleOrDefault(x => x.Id == id);
        }
    }
}