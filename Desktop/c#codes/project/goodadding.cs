using System.Collections.Generic;
namespace Method
{
    public class GoodAdding 
    {
        List<GoodAdding> bookAddings = new List<GoodAdding>();
        
        List<string> list_name = new List<string>();

        
        public GoodAdding(string name, string name_of_good, int unit_price, string id_no,int quantity)
        {
            Name = name;
            Name_of_good = name_of_good;
            Unit_price = unit_price;
            Id_no = id_no;
            Quantity = quantity;

        }

        public string Name{get;set;}
        public string Name_of_good{get;set;}
        public int Unit_price{get;set;}
        public string Id_no{get;set;}
        public int Quantity{get;set;}
        

        public static void Add_Stock(List<GoodAdding>bookAddings,List<string>list_name)
        {
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                bool check = list_name.Contains(name);
                if (check)
                {
                    Console.Write("Enter the name of the good: ");
                    string book = Console.ReadLine();
                    Console.Write("Enter the unit price: ");
                    int price = int.Parse(Console.ReadLine());
                    Console.Write("Enter id no");
                    string id_no =Console.ReadLine();
                    Console.Write("Enter the quantity: ");
                    int quantiy = int.Parse(Console.ReadLine());
                    GoodAdding bookadding = new GoodAdding(name, book, price, id_no, quantiy);
                    bookAddings.Add(bookadding);
                    // Mywork(bookAddings, list_name, name, option);


                }
                else
                {
                    Console.WriteLine("You are not registered");
                }
        }
        public static void Register_Manager(List<string>list_name)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            list_name.Add(name);
        }
        public static void Print_Manager(List<string>list_name)
        {
            foreach (var item in list_name)
            {
                Console.WriteLine(item);
            }
        }
        public static void Update(List<GoodAdding>bookAddings,List<string>list_name)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            if (list_name.Contains(name))
            {
                Console.Write("Enter name of good: ");
                string nameOfGood = Console.ReadLine();
                foreach (var item in bookAddings)
                {
                   if(item.Name_of_good.Contains(nameOfGood))
                   {
                       Console.WriteLine("Enter the idno");
                       string iDno = Console.ReadLine();
                       foreach (var id in bookAddings)
                       {
                           if (item.Id_no.Equals(iDno))
                           {
                                Console.WriteLine("\nEnter 1 to update quantity\nEnter 2 to update price");
                            int answer = int.Parse(Console.ReadLine());
                            if (answer == 1)
                            {
                                Console.Write("Enter the additional quantity: ");
                                int quanty = int.Parse(Console.ReadLine());
                                foreach (var quan in bookAddings)
                                {
                                    item.Quantity = item.Quantity + quanty;
                                }
                            }  
                            else
                            {
                                Console.Write("Enter the new price: ");
                                int newprice = int.Parse(Console.ReadLine());
                                foreach (var price in bookAddings)
                                {
                                    item.Unit_price = newprice;
                                }
                            } 
                               
                           }
                           else Console.WriteLine("Good not in stock");
                       }
                   } 
                   else Console.WriteLine("Good not in stock");  
                }
                
                
            }
            else
            {
                Console.WriteLine("You are not a registered manager");
            }
          
        }
        public static void Print_Stock(List<GoodAdding>bookAddings)
        {
            foreach (var item in bookAddings)
            {
                Console.WriteLine(item.Name_of_good+"\t"+item.Id_no+"\t"+item.Quantity+"\t"+item.Unit_price);
            }
        }

    }
    
}