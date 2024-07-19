using MySql.Data.MySqlClient;
public class EmployeeReposiotry : IEmployeeRepository
{
    MySqlConnection _connection;
    List<Employee> employeeslist = new List<Employee>();
    List<EmployerDetails> employerDetailslist = new List<EmployerDetails>();

    public EmployeeReposiotry(MySqlConnection connection)
    {
        _connection = connection;
    }
    public bool AddEmployee(Employee employee)
    {
        try
        {
            _connection.Open();

            string sqlQuery = "Insert into Employer(FName,LName,Email,Password,DepartmentId,PositionId) values ('" + employee.Fname + "', '" + employee.LName + "','" + employee.Email + "','" + employee.Password + "','" + employee.DepartmentId + "','" + employee.PositionId + "')";


            MySqlCommand command = new MySqlCommand(sqlQuery, _connection);
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine($"{employee.Fname} created successfully");
                _connection.Close();
                return true;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }

        _connection.Close();
        Console.WriteLine($"Operation not Successful");
        return false;
    }
    public bool UpdateEmployeeDepartment(int departmentId, string name)
    {
        try
        {
            _connection.Open();
            string query = "Update Employer Set DepartmentId = '" + departmentId + "'Where FName ='" + name + "' ";
            MySqlCommand command = new MySqlCommand(query, _connection);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("It has been updated");
                _connection.Close();
                return true;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }

        _connection.Close();
        Console.WriteLine("Operation not sucessful");
        return false;
    }
    public bool UpdateEmployeePosition(int positionId, string name)
    {
        try
        {
            _connection.Open();
            string query = "Update Employer Set PositionId = '" + positionId + "'Where FName ='" + name + "' ";
            MySqlCommand command = new MySqlCommand(query, _connection);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("It has been updated");
                _connection.Close();
                return true;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }

        _connection.Close();
        Console.WriteLine("Operation not sucessful");
        return false;
    }
    public bool UpdateEmployeeEmail(string email, string name)
    {
        try
        {
            _connection.Open();
            string query = "Update Employer Set Email = '" + email + "'Where FName ='" + name + "' ";
            MySqlCommand command = new MySqlCommand(query, _connection);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("It has been updated");
                _connection.Close();
                return true;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }

        _connection.Close();
        Console.WriteLine("Operation not sucessful");
        return false;
    }
    public bool DeleteEmployee(int id)
    {
        try
        {
            _connection.Open();
            string query = "Delete from Employer where id = '" + id + "'";
            MySqlCommand command = new MySqlCommand(query, _connection);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("It has been deleted");
                _connection.Close();
                return true;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        _connection.Close();
        Console.WriteLine("Operation not sucessful.");
        return false;
    }
    public Employee GetEmployeeById(int id)
    {
        Employee employee = null;
        try
        {
            _connection.Open();
            string query = "Select * from Employer where id = '" + id + "'";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string FName = reader.GetString(1);
                string LName = reader.GetString(2);
                string Email = reader.GetString(3);
                int departmentId = reader.GetInt32(5);
                int positionId = reader.GetInt32(6);
                employee = new Employee(FName,LName,Email,positionId,departmentId);
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return employee;
    }
    public List<Employee> GetAllEmployees()
     {
         try
         {
             _connection.Open();
             string query = "Select *  from Employer";
             MySqlCommand command = new MySqlCommand (query,_connection);
             MySqlDataReader reader = command.ExecuteReader();
             while (reader.Read())
            {
                string FName = reader.GetString(1);
                string LName = reader.GetString(2);
                string Email = reader.GetString(3);
                string Password = reader.GetString(4);
                int departmentId = reader.GetInt32(5);
                int positionId = reader.GetInt32(6);
                Employee employee = new Employee(FName,LName,Email,positionId,departmentId);
                employeeslist.Add(employee);
             }
         }
         catch (MySqlException ex)
         {
             Console.WriteLine(ex.Message);
         }
         return employeeslist;
        
     }
    public List<EmployerDetails> GetAllEmployerDetails()
    {
         try
         {
             _connection.Open();
             string query = "select employer.FName as firstname, employer.LName as lastname, departments.Name as Department, positions.Name as Position, positions.Salary as Salary from employer  inner join positions on employer.PositionId = positions.Id  inner join departments on employer.DepartmentId = departments.Id";
             MySqlCommand command = new MySqlCommand (query, _connection);
             MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string FName = reader.GetString(0);
                string LName = reader.GetString(1);
                string Department = reader.GetString(2);
                string Position = reader.GetString(3);
                double salary = reader.GetDouble(4);
                EmployerDetails employerDetails = new EmployerDetails(FName,LName,Department,Position,salary);
                employerDetailslist.Add(employerDetails);

                
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
         return employerDetailslist;       
    }
    public Employee GetEmployeeByEmail(string email, string password)
    {
        Employee employee = null;
        try
        {
            _connection.Open();
            string query = "Select * from Employer where email = '" + email + "' and password = '"+password+"'";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string FName = reader.GetString(1);
                string LName = reader.GetString(2);
                string Email = reader.GetString(3);
                int departmentId = reader.GetInt32(5);
                int positionId = reader.GetInt32(6);
                
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
            reader.Close();
            _connection.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        _connection.Close();
        return employee;
    }
    public void UpdatePassword(string email,string password,string newpassword)
    {
        var res = GetEmployeeByEmail(email,password);
        
        if (res == null)
        {
            Console.WriteLine("invalid email or password.");
        }
        else
        {
            _connection.Open();
            string query = "Update Employer Set Password = '" + newpassword + "'Where Email ='" + email + "' ";
            MySqlCommand command = new MySqlCommand(query, _connection);
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("It has been changed.");     
            _connection.Close();
        }
    }
}