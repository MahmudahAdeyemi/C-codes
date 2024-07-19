namespace file.RequestModel
{
    public class OrderRequestModel
    {
        public List<UnitOrder> Orders{get;set;} = new List<UnitOrder>();
    }
    public class UnitOrder
    {
        public string Product{get; set;}
        public double Quantity {get; set;}
    }
}