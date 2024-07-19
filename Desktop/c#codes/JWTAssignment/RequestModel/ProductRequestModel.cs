namespace JWTAssignment.RequestModel
{
    public class ProductRequestModel
    {
        public string Name {get; set;}
        public double QuantityAvailable {get; set;}
        public string Description {get; set;}
        public string UnitOfMeasurement{get; set;}
        public double CostPrice{get; set;}
        public double SellingPrice {get; set;}
    }
}