using System.Collections.Generic;
namespace Method
{
    public class Customer
    {
        public Customer(string account_number,string firstName, string secondName, string lastName, int pin, string address)
        {
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            Pin = pin;
            Address = address;
            AccountNumber = account_number;
            AccountBalance = 0;
        }

        public string FirstName{get;set;}
        public string SecondName{get;set;}
        public string LastName{get;set;}
        public int Pin {get;private set;}
        public string Address{get;set;}
        public string AccountNumber{get;set;}
        public int AccountBalance{get;set;}


        //  public string GenerateAccount()
        // {
        //     Random rand = new Random();
        //     string f= (rand.Next(10000,60000)).ToString();
        //     string ff = (rand.Next(60000,99999)).ToString();
        //     string account_number = f + ff;
        //     return account_number;
        // }
       
    }
}