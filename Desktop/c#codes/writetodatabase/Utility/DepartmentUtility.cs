using MySql.Data.MySqlClient;
public class DeaprtmentUtility
{
    static string connectionString = "server=localhost;user=root;database=employee;port=3306;password=m@hmud@h2009";
    static MySqlConnection _connection = new MySqlConnection(connectionString);
    static DepartmentReposiotry departmentReposiotry = new DepartmentReposiotry(_connection);
    public static bool CreateDepartment()
    {
        Console.Write("Enter the name of the Deaprtment");
        string name = Console.ReadLine();
        Console.Write("Enter the description of the Deaprtment");
        string description = Console.ReadLine();
        var response = departmentReposiotry.AddDepartment(name, description);
        return response;

    }
    public static bool ChangeDepartment()
    {
        Console.Write("Enter the new name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the id: ");
        int id = int.Parse(Console.ReadLine());
        var response = departmentReposiotry.Updatedepartment(id,name);
        return response;
    }
    public static bool DeleteDepartment()
    {
        Console.WriteLine("Enter the id: ");
        int id = int.Parse(Console.ReadLine()); 
        var response = departmentReposiotry.DeleteDepartment(id);
        return response;   
    }
    public static void GetDepartments()
    {
        var response = departmentReposiotry.GetAllDepartments();
        foreach (var item in response)
        {
            Console.WriteLine($"{item.Id}       {item.Name}        {item.Description}");
        }
    
    }
    public static void GetDepartmentById()
    {
        Console.Write("Enter the id: ");
        int id = int.Parse(Console.ReadLine());
        var response = departmentReposiotry.GetDepartmentById(id);
        Console.WriteLine($"{response.Id}        {response.Name}       {response.Description}");
    }

    public static void GetAllDepartmentDetails()
    {
        PositionUtility.GetPosition();
        Console.Write("Enter the id you want: ");
        int id = int.Parse(Console.ReadLine());
        var response = departmentReposiotry.GetAllDepartmentDetails(id);
        foreach (var item in response)
        {
            Console.WriteLine($"{item.Firstname}        {item.Lastname}        {item.Position}");
        }
    }
    
}