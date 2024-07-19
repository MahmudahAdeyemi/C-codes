namespace JWTAssignment.DTOs
{
    public class OrderDTO
    {
        public int Id{get; set;}
        public DateTime Date{get; set;} 
        public string CustomerName {get; set;}
        public List<UnitOrder> Orders {get; set;} = [];
    }
    
    public class UnitOrder
    {
        public string Product{get; set;}
        public double Quantity {get; set;}
    }
}