namespace Method
{
    class Stock
    {

        // List<Customer> customer_list = new List<Customer>();
        // List<Manager>manager_list = new List<Manager>();
        // List<Stock> stock_list = new List<Stock> (); 
        public Stock(string name_of_good, int unit_price, string brand, int quantity)
        {
            Name_of_good = name_of_good;
            Unit_price = unit_price;
            Brand = brand;
            Quantity = quantity;
        }

        public string Name_of_good { get; set; }
        public int Unit_price { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }



        public override string ToString()
        {
            return $"{Name_of_good}\t{Unit_price}\t{Brand}\t{Quantity}";
        }

        public static Stock ToStock(string line)
        {

            var splitted = line.Split("\t");
            //Stock stock = new Stock(splitted)
            string nameOfGood = splitted[0];
            int price = int.Parse(splitted[1]);
            string brand = splitted[2];
            int quantity = int.Parse(splitted[3]);
            Stock stock = new Stock(nameOfGood, price, brand, quantity);
            return stock;
        }
        public static void Add_Stock(List<Manager> manager_list, List<Stock> stock_list)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter you id: ");
            int id = int.Parse(Console.ReadLine());
            bool check = false;
            foreach (var item in manager_list)
            {
                if (item.Name == name && item.Id == id)
                {
                    check = true;
                    break;
                }
                else
                {
                    Console.WriteLine("You are not registered.");
                }
            }
            if (check == true)
            {
                Console.Write("Enter the name of the good: ");
                string good = Console.ReadLine();
                Console.Write("Enter the unit price: ");
                int price = int.Parse(Console.ReadLine());
                Console.Write("Enter the brand");
                string brand = Console.ReadLine();
                Console.Write("Enter the quantity: ");
                int quantiy = int.Parse(Console.ReadLine());
                Stock stock = new Stock(good, price, brand, quantiy);
                stock_list.Add(stock);

            }
            else
            {
                Console.WriteLine("You are not registered");
            }
        }

        public static void Update(List<Manager> manager_list, List<Stock> stock_list)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your id: ");
            int id = int.Parse(Console.ReadLine());
            Manager manager = new Manager(name);
            foreach (var item in manager_list)
            {
                if (item.Name == name)
                {
                    if (item.Id == id)
                    {
                        Console.Write("Enter name of good: ");
                        string nameOfGood = Console.ReadLine();
                        foreach (var ite in stock_list)
                        {
                            if (ite.Name_of_good.Equals(nameOfGood))
                            {
                                Console.WriteLine("Enter the brand");
                                string brand = Console.ReadLine();

                                if (ite.Brand == brand)
                                {
                                    Console.WriteLine("\nEnter 1 to update quantity\nEnter 2 to update price");
                                    int answer = int.Parse(Console.ReadLine());
                                    if (answer == 1)
                                    {
                                        Console.Write("Enter the additional quantity: ");
                                        int quanty = int.Parse(Console.ReadLine());
                                        ite.Quantity = ite.Quantity + quanty;
                                        break;
                                    }
                                    if (answer == 2)
                                    {
                                        Console.Write("Enter the new price: ");
                                        int newprice = int.Parse(Console.ReadLine());
                                        ite.Unit_price = newprice;
                                        break;
                                    }
    
                                }
                            }
                            else Console.WriteLine("Good not in stock");
                        }


                    }
                }
                else
                {
                    Console.WriteLine("You are not a registered manager.");
                }



            }
        }


        public static void Print_Stock(List<Stock> stock_list)
        {
            foreach (var item in stock_list)
            {
                Console.WriteLine(item.Name_of_good + "\t" + item.Brand + "\t" + item.Quantity + "\t" + item.Unit_price);
            }
        }
    }
}