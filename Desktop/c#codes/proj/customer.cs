namespace Method
{
    class Customer
    {
        public Customer(string name,string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            ID = Manager.GenerateId();
        }
        public string Name{get;set;}
        public string PhoneNumber {get;set;}
        public int ID{get;set;}
        
        public override string ToString()
        {
            return $"{ID}\t{Name}\t{PhoneNumber}" ;
        }

        public static Customer ToCustomer(string line)
        {
            var splitted = line.Split("\t");
            string name = splitted[1];
            int id = int.Parse(splitted[0]);
            string phoneNumber = splitted[2];
            Customer customer = new Customer(name,phoneNumber);
            return customer;
        }
        public static void Register_Customer(List<Customer>customer_list)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your phone number");
            string phoneNumber = Console.ReadLine();
            Customer customer = new Customer (name,phoneNumber);
            customer_list.Add(customer);
            Console.Write("Your id is " + customer.ID);
        }



        public static void Buy_Goods(List<Customer>customer_list,List<Stock>stock_list)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();
            Customer customer = new Customer(name,phoneNumber);
            foreach (var item in customer_list)
            {
                if(item.Name == name)
                {
                    if (item.ID == id)
                    {
                        if (item.PhoneNumber == phoneNumber)
                        {
                            Console.Write("Enter the name of good: ");
                            string goodname = Console.ReadLine();
                            foreach (var ite in stock_list)
                            {
                                if (ite.Name_of_good.Equals(goodname))
                                {
                                    Console.Write("Enter the quantity: ");
                                    int quantity = int.Parse(Console.ReadLine());
                                    foreach (var quan in stock_list)
                                    {
                                        if ((ite.Quantity) >= quantity)
                                        {
                                            foreach (var total in stock_list)
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
                    }
                }
            }
            
            
        
        }



        
         public static void Print_Customer(List<Customer>customer_list)
        {
            foreach (var item in customer_list)
            {
                Console.WriteLine($"{item.Name}  {item.ID}  {item.PhoneNumber}");
            }
        }

          

    }
}
