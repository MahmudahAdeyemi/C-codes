namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            Console.WriteLine("Welcome to GTbank");
            Console.Write("Enter the operation you want to perform: ");
            string operation = Console.ReadLine();
            double balance = 50000;
            if (operation == "Withraw")
            {
                Withraw(balance);
            }
            
            
        }
        static void Withraw (double balance)
        {
            
            Console.Write("Enter the amount you want to withraw: ");
            int amount =  int.Parse(Console.ReadLine());
            double new_amount = Convert.ToDouble(amount);
            //Console.WriteLine(new_amount);
            double charges = (0.002 * new_amount);
            double second_amount  = (0.002 * new_amount + (new_amount));
            Console.WriteLine(charges);
            if(charges > 2000)
            {
                charges = 2000;
            }
            double withraw = (balance - second_amount);
            Console.WriteLine("You have sucessfully withrawn " + amount+ " and your account balance is " + withraw);

        }
        static void Transfer()
        {
            Console.Write("Enter the amount you want to transfer: ");
            
        }
    }
}