using MySql.Data.MySqlClient;

public class PositionReposiotry : IPositionRepository
{
    MySqlConnection _connection;
    List<Position>positionslist = new List<Position>();
    List<PositionDetails>positionDetails = new List<PositionDetails>();
    public PositionReposiotry(MySqlConnection connection)
    {
        _connection = connection;
    }
    public bool AddPosition(string name, int salary)
    {
        try
        {
             _connection.Open();

        string sqlQuery = "Insert into Positions(name, salary) values ('"+ name +"', '"+ salary +"')";

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

    public bool UpdatePositionName(int id, string name)
     {
        try
        {
            _connection.Open();
            string query = "Update Positions Set name = '"+name+"'Where id ='"+id+"' ";
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

    public bool UpdatePositionSalary(int id, int salary)
     {
        try
        {
            _connection.Open();
            string query = "Update Positions Set salary = '"+salary+"'Where id ='"+id+"' ";
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

     public bool DeletePosition(int id)
     {
        try
        {
            _connection.Open();
            string query = "Delete from Positions where id = '"+id+"'";
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

     public Position GetPositionById(int id)
     {
         Position position = null;
        try
        {
            _connection.Open();
            string query = "Select * from Positions where id = '"+id+"'";
            MySqlCommand command = new MySqlCommand(query,_connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 int newid = reader.GetInt32(0);
                 string name = reader.GetString(1);
                 double salary = reader.GetDouble(2);
                 position = new Position(newid, name, salary);
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return position;


     }

    public List<Position> GetAllPositions()
    {
        try
        {
            _connection.Open();
            string query = "Select *  from Positions";
            MySqlCommand command = new MySqlCommand (query,_connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                double salary = reader.GetDouble(2);
                Position position = new Position(id, name, salary);
                positionslist.Add(position);
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return positionslist;
        
    }

        public List<PositionDetails> GetAllPositionDetails(int id)
    {
         try
        {
             _connection.Open();
             string query = "select employer.FName as firstname, employer.LName as lastname, departments.Name as Department from employer inner join departments on employer.DepartmentId = departments.Id where employer.Id = '"+id+"'";
             MySqlCommand command = new MySqlCommand (query, _connection);
             MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string FName = reader.GetString(0);
                string LName = reader.GetString(1);
                string Department = reader.GetString(2);
                PositionDetails PositionDetails = new PositionDetails(FName,LName,Department);
                positionDetails.Add(PositionDetails);
            }
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        _connection.Close();
        return positionDetails;       
    }

}