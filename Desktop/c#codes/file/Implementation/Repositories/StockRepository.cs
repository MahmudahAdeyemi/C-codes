using System.Text.Json;
using file.Entities;
using file.Interfaces.Repositoritories;

namespace file.Implementation.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly string filePath;
        public StockRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public void Add(Stock stock)
        {
            List<Stock> stocks = GetAllStocks();
            stocks.Add(stock);
            SaveStocks(stocks);
        }

        private void SaveStocks(List<Stock> stocks)
        {
            var options =  new JsonSerializerOptions{
                WriteIndented = true


            };
            string json = 
             JsonSerializer.Serialize(stocks, options);
            File.WriteAllText(filePath, json);
        }

         public void Delete(int stockId)
        {
            List<Stock> stocks = GetAllStocks();
            stocks.RemoveAll(c => c.Id == stockId);
            SaveStocks(stocks);
        }
        public List<Stock>? GetAllStocks()
        {
            if (!File.Exists(filePath))
            return new List<Stock>();


            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Stock>>(json);
        }
        public Stock GetStock(int id)
        {
            return GetAllStocks().SingleOrDefault(x => x.Id == id);
        }

        
    }
}