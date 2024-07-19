namespace Method
{
    class Menu
    {
       Customer_Manager customer_Manager = new Customer_Manager();

        public void My_menu()
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine("\nEnter 1 for registration of  customer\nEnter 2 for witraw\nEnter 3 to deposit\nEnter 4 to transfer");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                    customer_Manager.Register_Customer();
                    break;
                    case 2:
                    customer_Manager.Withraw();
                    break;
                    case 3:
                    customer_Manager.Deposit();
                    break;
                    case 4:
                    customer_Manager.Transfer();
                    break;
                    default:
                    check = false;
                    break;
                }

            }
        }
    }
}