public class AdminRepository : IAdminRepository
{
    EfCoreProjectContext _efCoreProjectContext;
    public AdminRepository(EfCoreProjectContext efCoreProjectContext1)
    {
        _efCoreProjectContext = efCoreProjectContext1;
    }
    public void AddAdmin(Admin admin)
    {

        _efCoreProjectContext.Admins.Add(admin);
        _efCoreProjectContext.SaveChanges();
    }
    public void UpdateAdminsFirstname(string firstname, string surname)
    {
        Admin admin = _efCoreProjectContext.Admins.SingleOrDefault(x => x.FName == firstname && x.LName == surname);
        admin.FName = firstname;
        _efCoreProjectContext.Admins.Update(admin);
        _efCoreProjectContext.SaveChanges();
        Console.WriteLine("Student updated.");
    }
    public void UpdateAdminsSurname(string firstname, string surname)
    {
        Admin admin = _efCoreProjectContext.Admins.SingleOrDefault(x => x.FName == firstname && x.LName == surname);
        admin.LName = surname;
        _efCoreProjectContext.Admins.Update(admin);
        _efCoreProjectContext.SaveChanges();
        Console.WriteLine("Student updated.");
    }
    public List<Admin> GetAllAdmin()
    {
        List<Admin> admin = _efCoreProjectContext.Admins.ToList();
        return admin;
    }
}