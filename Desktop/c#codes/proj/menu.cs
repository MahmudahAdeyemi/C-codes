namespace  Method
{
    public  class Menu
    {
        
        List<Customer> customer_list = new List<Customer>();
        List<Manager>manager_list = new List<Manager>();
        List<Stock> stock_list = new List<Stock> (); 

        // public static void Test(List<Customer> customer_list, List<Manager> manager_list, List<Stock> stock_list)
        // {
            // foreach (var item in customer_list)
            // {
            //     Console.WriteLine($"{item.Name} {item.ID}");
            // }
            // foreach (var item in manager_list)
            // {
            //     Console.WriteLine($"{item.Name} {item.Id}");
            // }
            // foreach (var item in stock_list)
            // {
            //     Console.WriteLine($"{item.Name_of_good} {item.Brand}");
            // }
        // }
        public void Stock_Reader()
        {
            StreamReader reader = new StreamReader("stock.txt");
            using (reader)
            {
                var line = File.ReadAllLines("stock.txt");
                foreach (var item in line)
                {
                    Stock new_item = Stock.ToStock(item);
                    stock_list.Add(new_item);
                }
                foreach (var item in stock_list)
                {
                    Console.WriteLine($"{item.Name_of_good} {item.Brand}");
                }
                
            }
        }

        public void Customer_Reader()
        {
            StreamReader reader = new StreamReader("customers.txt");
            using (reader)
            {
                var line = File.ReadAllLines("customers.txt");
                foreach (var item in line)
                {
                    Customer new_item = Customer.ToCustomer(item);
                    customer_list.Add(new_item);
                }
                foreach (var item in customer_list)
                {
                    Console.WriteLine($"{item.Name} {item.ID}");
                }

            }
        }
        public void Manager_Reader()
        {
            StreamReader reader = new StreamReader("manager.txt");
            using (reader)
            {
                var line = File.ReadAllLines("manager.txt");
                foreach (var item in line)
                {
                    Manager new_item = Manager.ToManager(item); 
                    manager_list.Add(new_item);
                }
                foreach (var item in manager_list)
                {
                    Console.WriteLine($"{item.Name} {item.Id}");
                }
            }
        }

        public void Writer()
        {
            StreamWriter customer = new StreamWriter("customers.txt");
            using (customer)
            {
                foreach (var item in customer_list)
                {
                    customer.WriteLine(item);
                }
            }
            StreamWriter manager = new StreamWriter("manager.txt");
            using(manager)
            {
                foreach (var item in manager_list)
                {
                    manager.WriteLine(item);
                }
            }
            
            StreamWriter stock = new StreamWriter("stock.txt");
            using(stock)
            {
                foreach(var item in stock_list)
                {
                    stock.WriteLine(item);
                }
            }
        }
        public void My_menu()
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine("\nEnter 1 for manager registration\nEnter 2 for good adding\nEnter 3 for listing managers\nEnter 4 for updating\nEnter 5 for printing stock\nEnter 6 for registering customer\nEnter 7 for buying\nEnter 8 for printing customer\nEnter 9 to sac a manger.");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                    Manager.Register_Manager(manager_list);
                    break;
                    case 2:
                    Stock.Add_Stock(manager_list,stock_list);
                    break;
                    case 3:
                    Manager.Print_Manager(manager_list);
                    break;
                    case 4:
                    Stock.Update(manager_list,stock_list);
                    break;
                    case 5:
                    Stock.Print_Stock(stock_list);
                    break;
                    case 6:
                    Customer.Register_Customer(customer_list);
                    break;
                    case 7:
                    Customer.Buy_Goods(customer_list,stock_list);
                    break;
                    case 8:
                    Customer.Print_Customer(customer_list);
                    break;
                    case 9:
                    Manager.DeleteMananger(manager_list);
                    break;
                    default:
                    check = false;
                    break;
                }

            }
        }
    }
}