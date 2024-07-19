public class PositionDetails
{


    public string Firstname{get;set;}
    public string Lastname{get;set;}
    public string Department{get;set;}
        public PositionDetails(string firstname, string lastname, string department)
    {
        Firstname = firstname;
        Lastname = lastname;
        Department = department;
    }
}