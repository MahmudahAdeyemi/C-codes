using MySql.Data.MySqlClient;



public class Program0
{
    static string connectionString = "server=localhost;user=root;database=employee;port=3306;password=m@hmud@h2009";
    static MySqlConnection _connection = new MySqlConnection(connectionString);
    static EmployeeReposiotry employeeReposiotry = new EmployeeReposiotry(_connection);
    static void Main(string[] args)
    {
        DeaprtmentUtility.GetAllDepartmentDetails();
    }
}