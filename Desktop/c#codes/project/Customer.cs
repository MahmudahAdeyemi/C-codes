using System.Collections.Generic;
namespace Method
{
    public class Customer 
    {
        List<Customer> buying = new List<Customer>();
        List<string> customer_name = new List<string>();
        List<GoodAdding> bookAddings = new List<GoodAdding>();

        public Customer( string name, string name_of_good,int unitprice, int quantity)
        {

            Name = name;
            Name_of_good = name_of_good;
            Quantity = quantity;
            foreach (var item in bookAddings)
            {
                if (Name.Equals(item.Name))
                {
                    Unit_Price = item.Unit_price;
                }
            }
            Total_Price = Unit_Price * Quantity;
        }

        public string Name{get;set;}
        public string Name_of_good{get;set;}
        public int Quantity {get;set;}
        public int Total_Price{get;set;}
        public int Unit_Price{get;set;}

        public static void Register_Customer(List<string>list_name)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            list_name.Add(name);
        }
         public static void Print_Customer(List<string>customer_name)
        {
            foreach (var item in customer_name)
            {
                Console.WriteLine(item);
            }
        }
        
        public static void Buy_Goods(List<Customer>buying,List<string>customer_name,List<GoodAdding>bookAddings)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            if(customer_name.Contains(name))
            {
                Console.Write("Enter the name of good: ");
                string goodname = Console.ReadLine();
                foreach (var item in bookAddings)
                {
                    if (item.Name_of_good.Contains(goodname))
                    {
                        Console.Write("Enter the quantity: ");
                        int quantity = int.Parse(Console.ReadLine());
                        foreach (var quan in bookAddings)
                        {
                            if ((item.Quantity) >= quantity)
                            {
                                foreach (var total in bookAddings)
                                {
                                    int total_amount = total.Unit_price * quantity ;
                                    Console.WriteLine("The total amount of good purchased is " + total_amount);
                                    total.Quantity = total.Quantity - quantity;
                                }

                                
                            } else  Console.WriteLine("We dont have to that quantity");
                        }
                    }
                    else  Console.WriteLine("Goods not available in stock.");
                }
            }
            else Console.WriteLine("You are not registered");
        
        }
        
        

    }
}