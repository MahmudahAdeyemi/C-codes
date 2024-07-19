using MySql.Data.MySqlClient;

public class DepartmentReposiotry : IDepartmentRepository
{
    MySqlConnection _connection;
    List<Department>departmentslist = new List<Department>();
    List<DepartmentDetails>departmentDetails = new List<DepartmentDetails>();
    public DepartmentReposiotry(MySqlConnection connection)
    {
        _connection = connection;
    }
    public bool AddDepartment(string name, string description)
    {
        try
        {
             _connection.Open();

        string sqlQuery = "Insert into Departments(name, description) values ('"+ name +"', '"+ description +"')";

        MySqlCommand command = new MySqlCommand(sqlQuery , _connection);
        int rowsAffected = command.ExecuteNonQuery();

            if(rowsAffected > 0)
            {
             Console.WriteLine($"{name} created successfully");
            _connection.Close();
            return true;
            }
        }
        catch(MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
       
        _connection.Close();
        Console.WriteLine($"Operation not Successful");
        return false;
    }

     public bool Updatedepartment(int id, string name)
     {
        try
        {
            _connection.Open();
            string query = "Update Departments Set name = '"+name+"'Where id ='"+id+"' ";
            MySqlCommand command = new MySqlCommand(query,_connection);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("It has been updated");
                _connection.Close();
                return true;
            }
        }
        catch(MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }

        _connection.Close();
        Console.WriteLine("Operation not sucessful");
        return false;
     }

     public bool DeleteDepartment(int id)
     {
        try
        {
            _connection.Open();
            string query = "Delete from Departments where id = '"+id+"'";
            MySqlCommand command = new MySqlCommand(query,_connection);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("It has been deleted");
                _connection.Close();
                return true;
            }
        }
        catch(MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        _connection.Close();
        Console.WriteLine("Operation not sucessful.");
        return false;
     }

    
     public List<Department> GetAllDepartments()
     {
         try
         {
             _connection.Open();
             string query = "Select *  from Departments";
             MySqlCommand command = new MySqlCommand (query,_connection);
             MySqlDataReader reader = command.ExecuteReader();
             while (reader.Read())
             {
                 int id = reader.GetInt32(0);
                 string name = reader.GetString(1);
                 string description = reader.GetString(2);
                 Department department = new Department(id, name, description);
                departmentslist.Add(department);
             }
             _connection.Close();
             reader.Close();
         }
         catch (MySqlException ex)
         {
             Console.WriteLine(ex.Message);
         }
         return departmentslist;
        
     }
      public Department GetDepartmentById(int id)
     {
         Department department = null;
        try
        {
            _connection.Open();
            string query = "Select * from Departments where id = '"+id+"'";
            MySqlCommand command = new MySqlCommand(query,_connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 int newid = reader.GetInt32(0);
                 string name = reader.GetString(1);
                 string description = reader.GetString(2);
                 department = new Department(newid, name, description);
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return department;


     }

     public List<DepartmentDetails> GetAllDepartmentDetails(int id)
    {
         try
         {
             _connection.Open();
             string query = "select employer.FName, employer.LName, positions.Name, positions.Salary from employer  inner join positions on employer.PositionId = positions.Id where employer.Id = '" + id + "'";
             MySqlCommand command = new MySqlCommand (query, _connection);
             MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string FName = reader.GetString(0);
                string LName = reader.GetString(1);
                string Department = reader.GetString(2);
                DepartmentDetails deparftmentDetails = new DepartmentDetails(FName,LName,Department);
                departmentDetails.Add(deparftmentDetails);

                _connection.Close();
            }
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }  
         _connection.Close();    
         return departmentDetails; 
    }

    

}