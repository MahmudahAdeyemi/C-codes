namespace JWTAssignment.RequestModel
{
    public class CreateOrderRequestModel
    {
        public List<UnitOrderRequest> Datas {get; set;}
    }

    public class UnitOrderRequest
    {
        public string Name {get; set;}
        public int Quantity {get; set;}
    }
}