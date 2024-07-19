public class EmployerDetails
{
    

    public string Firstname{get;set;}
    public string Lastname{get;set;}
    public string Department{get;set;}
    public string Position {get;set;}
    public double Salary{get;set;}


    public EmployerDetails(string firstname, string lastname, string department, string position, double salary)
    {
        Firstname = firstname;
        Lastname = lastname;
        Department = department;
        Position = position;
        Salary = salary;
    }
       
}