namespace Transaction.Entities
{
    public class GoodsReturnedProduct
    {
        public int Id{get; set;}
        public Product Product{get; set;}
        public int ProductId{get; set;}
        public GoodsReturned GoodsReturned{get; set;}
        public int GoodsReturnedId{get; set;}
        public decimal Quantity{get; set;}
    }
}