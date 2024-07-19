using System.Collections.Generic;
namespace lamda
{
    class Program
    {
        static void Main(string[] args)
        {
            List <Item> items = new List<Item>()
            {
                new Item("Bag",3,500),
                new Item("Pen",4,50),
                new Item("Book",6,650),
                new Item("Laptop",4,90000),
                new Item("Phone",5,50000)
            }; 
            PrintStudents("GOODS WITH PRICE GREATER THAN 500 ARE: ",items,item => item.Quantity > 3);
            
        }
        static bool CheckItem (Item items)
        {
            return items.UnitPrice > 500;
        }
        //static bool ItemCheck (Item item) => item.Quantity > 3;
        static void PrintStudents(string title,List<Item> items,Func<Item,bool> CheckItem )
        {
            Console.WriteLine(title);
            foreach(var item in items)
            {

                
                if(CheckItem(item))
                {
                    Console.WriteLine(item);
                }
            }
        }   
        

    }

    
    
    // Item delegate = item =>
    // {
    //     return item.TotalPrice > 1500;
    // }

    
    
}