class Printingletter
{
    static void Main()
    {
        Console.Write("Enter company name: ");
        string companyname = Console.ReadLine();
        Console.Write("Enter company address: ");
        string companyaddress = Console.ReadLine();
        Console.Write("Enter company phone number: ");
        string companyphonenumber = Console.ReadLine();
        Console.Write("Enter company fax number: ");
        string companyfaxnumber = Console.ReadLine();
        Console.Write("Enter company website: ");
        string companywebsite = Console.ReadLine();
        Console.Write("Enter managerfirstname: ");
        string managerfirstname = Console.ReadLine();
        Console.Write("Enter manager surname: ");
        string managersurname = Console.ReadLine();
        Console.Write("Enter manager phone number: ");
        string managerphonenumber = Console.ReadLine();
        

    Console.Write("There is a company named  \"{0}\" , is located" +
    "at  \"{1}\" .The company's phone number is  \"{2}\" and its" + 
    "fax number is  \"{3}\". You  can get more information on" + 
    "\"{4}\" .The manager's full name is  \"{5}\"  \"{6}\" and" + 
    "her phone number is  \"{7}\" .", companyname,companyaddress,companyphonenumber,companyfaxnumber,companywebsite,managerfirstname,managersurname,managerphonenumber);
    }
}