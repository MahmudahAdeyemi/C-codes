namespace  Method
{
    public   class Program
    {
        
        
        static void Main(string[] args)
        {
            
            Menu menu = new Menu();;
            menu.Customer_Reader();
            menu.Manager_Reader();
            menu.Stock_Reader();
            Console.WriteLine("Welcome to JUSTRITE SUPERSTORE");
            Console.WriteLine("Enter 0 to exit");
            menu.My_menu();
            Console.WriteLine("Thanks for Patronage");
            menu.Writer ();
            // menu.Reader();
            // string stockInStringFormat = "tea 50 milo 10";
            // var splitted = stockInStringFormat.Split(' ');
            // //Stock stock = new Stock(splitted)
            // string nameOfGood = splitted[0];
            // int price = int.Parse(splitted[1]);
            // string brand = splitted[2];
            // int quantity = int.Parse(splitted[3]);
            // Stock stock = new Stock(nameOfGood,price,brand,quantity);

        }



        
    }
}