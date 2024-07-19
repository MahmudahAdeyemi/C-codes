namespace Method
{
    public class Menu
    {
        List<Registered> mylist = new List<Registered>();
        public void Mymenu()
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine("\nEnter 1 for registerind. \nEnter 2 for check administration. \nEnter 3 for adminitration");
                int option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    Registered.Register(mylist);
                    break;
                    default:
                    check = false;
                    break;
                }
            }
        }
    }
}