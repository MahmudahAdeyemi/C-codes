public class Admin
{
    public int Id{get; set;}
    public string FName{get; set;}
    public string LName{get; set;}
    public int Age{get; set;}
    public string Email{get; set;}
    public string Password{get; set;}

    public Admin( string fName, string lName, int age, string email, string password)
    {
        FName = fName;
        LName = lName;
        Age = age;
        Email = email;
        Password = password;
    }
}