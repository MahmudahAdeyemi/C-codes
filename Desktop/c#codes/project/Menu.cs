namespace  Method
{
    public  class Menu
    {
        
        List<GoodAdding> bookAddings = new List<GoodAdding>();
        List<string> list_name = new List<string>();
        List<Customer> buying = new List<Customer>();
        List<string>customer_name = new List<string>();
        public void My_menu()
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine("\nEnter 1 for manager registration\nEnter 2 for good adding\nEnter 3 for listing managers\nEnter 4 for updating\nEnter 5 for printing stock\nEnter 6 for registering customer\nEnter 7 for buying\nEnter 8 for printing customer\n");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                    GoodAdding.Register_Manager(list_name);
                    break;
                    case 2:
                    GoodAdding.Add_Stock(bookAddings,list_name);
                    break;
                    case 3:
                    GoodAdding.Print_Manager(list_name);
                    break;
                    case 4:
                    GoodAdding.Update(bookAddings,list_name);
                    break;
                    case 5:
                    GoodAdding.Print_Stock(bookAddings);
                    break;
                    case 6:
                    Customer.Register_Customer(customer_name);
                    break;
                    case 7:
                    Customer.Buy_Goods(buying,customer_name,bookAddings);
                    break;
                    case 8:
                    Customer.Print_Customer(customer_name);
                    break;
                    default:
                    check = false;
                    break;
                }

            }
        }
    }
}