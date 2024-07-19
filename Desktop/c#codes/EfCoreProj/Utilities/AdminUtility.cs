public class AdminUtility
{
    EfCoreProjectContext _efCoreProjectContext ;
    public AdminUtility(EfCoreProjectContext efCoreProjectContext1)
    {
        _efCoreProjectContext = efCoreProjectContext1;
    }
    public void AddAdmin()
    {
        Console.Write("Enter your firstname: ");
        string firstname = Console.ReadLine();
        Console.Write("Enter your surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();
        
        Admin admin = new Admin(firstname,surname,age,email,password);
        AdminRepository adminRepository = new AdminRepository(_efCoreProjectContext);
        adminRepository.AddAdmin(admin);
    }
    public void UpdateAdminsFirstname()
    {
        Console.Write("Enter your firstname: ");
        string firstname = Console.ReadLine();
        Console.Write("Enter your surname: ");
        string surname = Console.ReadLine();
        AdminRepository adminRepository = new AdminRepository(_efCoreProjectContext);
        adminRepository.UpdateAdminsFirstname(firstname,surname);
    }
        public void UpdateAdminsSurname()
    {
        Console.Write("Enter your firstname: ");
        string firstname = Console.ReadLine();
        Console.Write("Enter your surname: ");
        string surname = Console.ReadLine();
        AdminRepository adminRepository = new AdminRepository(_efCoreProjectContext);
        adminRepository.UpdateAdminsSurname(firstname,surname);
    }
    public void GetAllAdmin()
    {
        AdminRepository adminRepository = new AdminRepository(_efCoreProjectContext);
        var c = adminRepository.GetAllAdmin();
        foreach (var item in c)
        {
            Console.WriteLine($"{item.Id}       {item.FName}        {item.LName}        {item.Age}      {item.Email}        {item.Password}");
        }
    }
    public bool IfAdmin()
    {
        Console.Write("Enter yoyr email:  ");
        string email = Console.ReadLine();
        Console.Write("Enter your password:  ");
        string password = Console.ReadLine();
        Admin admin = _efCoreProjectContext.Admins.SingleOrDefault(x => x.Email == email && x.Password == password);
        if(admin == null)
        {
            return false;
        }
        else return true;
    }
}