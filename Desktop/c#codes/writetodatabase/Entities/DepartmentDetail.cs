public class DepartmentDetails
{


    public string Firstname{get;set;}
    public string Lastname{get;set;}
    public string Position{get;set;}
        public DepartmentDetails(string firstname, string lastname, string position)
    {
        Firstname = firstname;
        Lastname = lastname;
        Position = position;
    }
}