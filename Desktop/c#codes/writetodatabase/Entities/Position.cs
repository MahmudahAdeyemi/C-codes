 public class Position
    {

        
        public int Id{get;set;}
        public string Name{get;set;}
        public double Salary{get;set;}
        public Position(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }
    }