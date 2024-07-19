namespace file.Entities
{
    public class Order
    {
        public int Id{get; private set;} = GenerateUniqueOrderNo();
        public DateTime Date{get; private set;} = DateTime.Now;
        public int CustomerId{get;set;}
        private List<OrderItem> _orderItems{get; set;} = new List<OrderItem>();
        public IReadOnlyList<OrderItem> OrderItems => _orderItems;
        public OrderStatus Status {get; private set;} = OrderStatus.NotPaid;

        public void AddItem(OrderItem item){
            if(_orderItems.Any(p=>p.ProductId == item.ProductId))
            {
                var product = new Product();
                product.QuantityAvailable += item.Quantity;
            }
            //    throw new Exception($"An item with the product id {item.ProductId} already exists");
            _orderItems.Add(item);
        }

        public void Paid(){
            if(Status == OrderStatus.Paid)
              throw new Exception ("This order has been paid for");
            if(Status == OrderStatus.Cancelled)
              throw new Exception ("This order has been cancelled for");

            Status = OrderStatus.Paid;
        }
        public void Cancel(){

            Status = OrderStatus.Cancelled;
        }

        private static int GenerateUniqueOrderNo(){

            var rand = new Random();
            return rand.Next(1, int.MaxValue);

        }
    }

    public enum OrderStatus{
        NotPaid,
        Paid,
        Cancelled
    }
}