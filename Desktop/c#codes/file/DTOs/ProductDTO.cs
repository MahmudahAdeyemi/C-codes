using file.Entities;

namespace file.DTOs
{
    public class ProductDTO
    {
        public int Id{get; set;}
        public string Name {get; set;}
        public double QuantityAvailable {get; set;}
        public string Description {get; set;}
        
        
        public Measurement UnitOfMeasurement{get; set;}
        public double Price {get; set;}
    }
}