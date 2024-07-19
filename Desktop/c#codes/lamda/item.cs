namespace lamda
{
    class Item
    {
        public string Name{get;set;}
        public int Quantity{get;set;}
        public int UnitPrice{get;set;}
        public int TotalPrice{get;set;}

        public Item (string name,int quantity,int unitPrice)
        {
            Name =name;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = quantity * unitPrice;
        }

        public override string ToString()
        {
            var mystring = "Name : "+ Name +"\nQuantity : " + Quantity +"\nUnitprice : " + UnitPrice+"\nTotalprice : "+TotalPrice+ "\n";
            return mystring;
        }
    }
}