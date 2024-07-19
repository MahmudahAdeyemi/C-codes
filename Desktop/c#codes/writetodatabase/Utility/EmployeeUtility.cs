using MySql.Data.MySqlClient;
public class EmployeeUtility
{
    static string connectionString = "server=localhost;user=root;database=employee;port=3306;password=m@hmud@h2009";
    static MySqlConnection _connection = new MySqlConnection(connectionString);
    static EmployeeReposiotry employeeReposiotry = new EmployeeReposiotry(_connection);



    public static bool CreateEmployee()
    {
        Console.Write("Enter your Firstname: ");
        string fname = Console.ReadLine();
        Console.Write("Enter your lastname: ");
        string lName = Console.ReadLine();
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();
        Console.WriteLine("These are the departments we have: ");
        DeaprtmentUtility.GetDepartments();
        Console.Write("Enter the id of the department you want: ");
        int departmentId = int.Parse(Console.ReadLine());
        Console.WriteLine("These are the positions we have: ");
        PositionUtility.GetPosition();
        Console.Write("Enter the id of the position you want: ");
        int positionId = int.Parse(Console.ReadLine());

        Employee employee = new Employee(fname, lName,email, positionId,departmentId);


        var response = employeeReposiotry.AddEmployee(employee);
        return response;

    }

          public static bool ChangeEmployeeDepartment()
    {
        Console.Write("Enter your first name: ");
        string name = Console.ReadLine();
        Console.WriteLine("These are the departments we have: ");
        DeaprtmentUtility.GetDepartments();
        Console.Write("Enter the id of the new department you want: ");
        int departmentId = int.Parse(Console.ReadLine());
        var response = employeeReposiotry.UpdateEmployeeDepartment(departmentId,name);
        return response;
    }

     public static bool ChangeEmployeePosition()
    {
        Console.Write("Enter your first name: ");
        string name = Console.ReadLine();
        Console.WriteLine("These are the Positions we have: ");
        PositionUtility.GetPosition();
        Console.Write("Enter the id of the new Position you want: ");
        int PositionId = int.Parse(Console.ReadLine());
        var response = employeeReposiotry.UpdateEmployeePosition(PositionId,name);
        return response;
    }
    

      public static bool ChangeEmployeeEmail()
    {
        Console.Write("Enter your first name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the new email: ");
        string email = Console.ReadLine();
        var response = employeeReposiotry.UpdateEmployeeEmail(email,name);
        return response;
    }

    public static bool DeleteEmployee()
    {
        Console.WriteLine("Enter the id: ");
        int id = int.Parse(Console.ReadLine()); 
        var response = employeeReposiotry.DeleteEmployee(id);
        return response;   
    }

        public static void GetEmployeeById()
    {
        Console.Write("Enter the id: ");
        int id = int.Parse(Console.ReadLine());
        var response = employeeReposiotry.GetEmployeeById(id);
        Console.WriteLine($"{response.Fname}       {response.LName}        {response.Email}        {response.Password}        {response.DepartmentId}        {response.PositionId}");
    }

    public static void GetAllEmployees()
    {
        var response = employeeReposiotry.GetAllEmployees();
        foreach (var item in response)
        {
            Console.WriteLine($"{item.Id}       {item.Fname}        {item.LName}        {item.Email}        {item.Password}     {item.PositionId}        {item.DepartmentId}");
        }
    
    }

    public static void GetAllEmployerDetails()
    {
        var response = employeeReposiotry.GetAllEmployerDetails();
        foreach (var item in response)
        {
            Console.WriteLine($"{item.Firstname}        {item.Lastname}     {item.Department}       {item.Position}     {item.Salary}");
        }
    }

    public static void UpdatePassword()
    {
        
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();
        Console.Write("Enter your former password: ");
        string password = Console.ReadLine();
        
            Console.Write("Enter new password");
            string newpassword = Console.ReadLine();
        employeeReposiotry.UpdatePassword(email,password,newpassword);
    }
}