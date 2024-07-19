namespace Method
{
    public class Customer_Manager
    {
        List<Customer> mycustomer_list = new List<Customer>();
        List<Staff> mystaff_list = new List<Staff>();



        public void Register_Customer()
        {
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your surname: ");
            string secondName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter your address: ");
            string address = Console.ReadLine();
            Console.Write("Enter the pin: ");
            int pin = int.Parse(Console.ReadLine());
            Customer customer = new Customer(GenerateAccount(), firstName, secondName, lastName, pin, address);
            mycustomer_list.Add(customer);
            Console.WriteLine("Your account number is " + customer.AccountNumber);
        }

        public Customer GetCustomerByAcctNum(string account_number)
        {
            foreach (var item in mycustomer_list)
            {
                if (item.AccountNumber == account_number)
                {
                    return item;
                }
            }
            return null;
        }

        public void Withraw()
        {

            Console.Write("Enter your account number: ");
            string account_number = Console.ReadLine();
            Customer customer = GetCustomerByAcctNum(account_number);
            if(customer == null)
            {
                Console.WriteLine("Custumer not found");
                return ;
            }
            Console.Write("Enter the amount to withtraw: ");
            float amt = float.Parse(Console.ReadLine());
            double ramt = (0.02 * amt) + amt;
            Console.Write("Enter your pin: ");
            int pin = int.Parse(Console.ReadLine());
            if (customer.Pin == pin)
            {
                if (customer.AccountBalance >= ramt)
                {
                    customer.AccountBalance = customer.AccountBalance - (int)ramt;
                    Console.WriteLine("You've sucessfully witrawn" + amt + " and your account balance is " + customer.AccountBalance);

                }
                else
                {
                    Console.WriteLine("Insufficient amount");
                }
            }
            else
            {
                Console.WriteLine("invalid pin");
            }
        }
        public void Deposit()
        {
            Console.Write("Enter your account number");
            string acn = Console.ReadLine();
            Customer customer = GetCustomerByAcctNum(acn);
            Console.Write("Enter the amount to deposit: ");
            int amt = int.Parse(Console.ReadLine());
            customer.AccountBalance = customer.AccountBalance + amt;
            Console.WriteLine("Your account balance is " + customer.AccountBalance);
        }
        public void Transfer()
        {
            Console.Write("Enter your acctnum: ");
            string uracn = Console.ReadLine();
            Console.Write("Enter the accnum of the reciever: ");
            string reacn = Console.ReadLine();
            Console.Write("Enter the amount you want to transfer: ");
            int amt = int.Parse(Console.ReadLine());
            Customer customer = GetCustomerByAcctNum(uracn);
            Customer customer1 = GetCustomerByAcctNum(reacn);
            if (customer1.AccountBalance > amt)
                {
                    Console.WriteLine($"Are you sure you want to tansfer {amt} to {customer.FirstName} {customer.SecondName} {customer.LastName}");
                    customer1.AccountBalance = customer1.AccountBalance - amt;
                    customer.AccountBalance = customer.AccountBalance + amt;
                    Console.WriteLine($"You've sucessfully transfered {amt} to {customer.FirstName} {customer.SecondName} {customer.LastName}");
                }
            else
            {
                Console.WriteLine("insufficient amount");
            }
        }
        public string GenerateAccount()
        {
            Random rand = new Random();
            string f = (rand.Next(10000, 60000)).ToString();
            string ff = (rand.Next(60000, 99999)).ToString();
            string account_number = f + ff;
            return account_number;
        }

    }
}