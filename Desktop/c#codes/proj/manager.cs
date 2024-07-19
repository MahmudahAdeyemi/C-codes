namespace Method
{
    class Manager
    {
        // List<Customer> customer_list = new List<Customer>();
        // List<Manager>manager_list = new List<Manager>();
        // List<Stock> stock_list = new List<Stock> (); 
        public Manager(string name)
        {
            Name = name;
            Id = GenerateId();
        }

        public string Name{get;set;}
        public int Id{get;set;}

        public override string ToString()
        {
            return $"{Id}\t{Name}" ;
        }

        public static Manager ToManager(string line)
        {
            var splitted = line.Split("\t");
            string name = splitted[1];
            Manager manager = new Manager(name);
            return manager ;
        }

        public static int GenerateId()
        {
            Random random = new Random();
            int r = random.Next(100,1000);
            return r;
        }


        public static void Register_Manager(List<Manager>manager_list)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Manager manager = new Manager (name);
            manager_list.Add(manager);
            Console.WriteLine($"Your id is {manager.Id}");
        }
        public static void Print_Manager(List<Manager>manager_list)
        {
            foreach (var item in manager_list)
            {
                Console.WriteLine(item.Name + "     " + item.Id);
            }
        }
        public static void DeleteMananger(List<Manager>manager_list)
        {
            Console.WriteLine("Enter the name of manager to sac: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the id: ");
            int id = int.Parse(Console.ReadLine());
            Manager manager = null;
            foreach (var item in manager_list)
            {
                if (item.Name == name && item.Id == id)
                {
                    manager = item;
                    Console.WriteLine("The manager has been sacked.");
                }
            }
            manager_list.Remove(manager);
        }
    }
}