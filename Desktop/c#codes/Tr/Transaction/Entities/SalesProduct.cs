namespace Transaction.Entities
{
    public class SalesProduct
    {
        public int Id{get; set;}
        public Product Product {get; set;}
        public int ProductId {get; set;} 
        public Sales Sales {get; set;}
        public int SalesId{get; set;}
        public decimal ProductQuantities{get; set;}
    }
}