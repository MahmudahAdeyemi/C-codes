
    public class Employee
    {
    public int Id {get;set;}
        public string Fname{get;set;}
        public string LName {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public int PositionId {get;set;}
        public int DepartmentId{get;set;}
    public Employee(string fname, string lName, string email, int positionId, int departmentId)
    {
        Fname = fname;
        LName = lName;
        Email = email;
        Password = GeneratePassword(fname,lName);
        PositionId = positionId;
        DepartmentId = departmentId;
    }

    public static string GeneratePassword(string fName,string lName)
    {
        Random random = new Random();
        string password = $"{fName[1]}{lName[0]}{random.Next(100,999)}{fName[0]}{random.Next(100,999)}";
        return password;
    }



    
        
    }
