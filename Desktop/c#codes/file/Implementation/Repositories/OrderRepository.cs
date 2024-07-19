using System.Text.Json;
using file.Entities;
using file.Interfaces.Repositoritories;

namespace file.Implementation.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string filePath;
        public OrderRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public void Add(Order order)
        {
            List<Order> orders = GetAllOrders();
            orders.Add(order);
            SaveOrders(orders);
        }

        private void SaveOrders(List<Order> orders)
        {
            var options =  new JsonSerializerOptions{
                WriteIndented = true


            };
            string json = 
             JsonSerializer.Serialize(orders, options);
            File.WriteAllText(filePath, json);
        }

         public void Delete(int orderId)
        {
            List<Order> orders = GetAllOrders();
            orders.RemoveAll(c => c.Id == orderId);
            SaveOrders(orders);
        }
        public List<Order>? GetAllOrders()
        {
            if (!File.Exists(filePath))
            return new List<Order>();


            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Order>>(json);
        }
        public Order GetOrder(int id)
        {
            return GetAllOrders().SingleOrDefault(x => x.Id == id);
        }
 
    }
}