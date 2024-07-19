using MySql.Data.MySqlClient;
public class PositionUtility
{
    static string connectionString = "server=localhost;user=root;database=employee;port=3306;password=m@hmud@h2009";
    static MySqlConnection _connection = new MySqlConnection(connectionString);
    static PositionReposiotry positionReposiotry = new PositionReposiotry(_connection);
   
     public static bool CreatePosition()
    {
        Console.Write("Enter the name of the Position");
        string name = Console.ReadLine();
        Console.Write("Enter the salary of the Position");
        int salary =int.Parse(Console.ReadLine());
        var response = positionReposiotry.AddPosition(name, salary);
        return response;

    }
        public static bool ChangePositionName()
    {
        Console.Write("Enter the new name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the id: ");
        int id = int.Parse(Console.ReadLine());
        var response = positionReposiotry.UpdatePositionName(id,name);
        return response;
    }
    public static bool ChangePositionSalary()
    {
        Console.Write("Enter the new salary: ");
        int salary =int.Parse(Console.ReadLine());
        Console.Write("Enter the id: ");
        int id = int.Parse(Console.ReadLine());
        var response = positionReposiotry.UpdatePositionSalary(id,salary);
        return response;
    }
    public static bool DeletePosition()
    {
        GetPosition();
        Console.WriteLine("Enter the id: ");
        int id = int.Parse(Console.ReadLine()); 
        var response = positionReposiotry.DeletePosition(id);
        return response;   
    }

    public static void GetPositionById()
    {
        Console.Write("Enter the id: ");
        int id = int.Parse(Console.ReadLine());
        var response = positionReposiotry.GetPositionById(id);
        Console.WriteLine($"{response.Id}        {response.Name}       {response.Salary}");
    }
    public static void GetPosition()
    {
        var response = positionReposiotry.GetAllPositions();
        foreach (var item in response)
        {
            Console.WriteLine($"{item.Id}       {item.Name}        {item.Salary}");
        }
    
    }
    public static void GetAllPositionDetails()
    {
        DeaprtmentUtility.GetDepartments();
        Console.Write("Enter the id you want: ");
        int id = int.Parse(Console.ReadLine());
        var response = positionReposiotry.GetAllPositionDetails(id);
        foreach (var item in response)
        {
            Console.WriteLine($"{item.Firstname}        {item.Lastname}        {item.Department}");
        }
    }
}