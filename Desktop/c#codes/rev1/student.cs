namespace Method
{
    public class Student
    {
        public static int count = 1;
        
        List<Student> Addstudent = new List<Student>();
        public Student( string firatName, string lastNane, int age, string gender)
        {
            
            Id = count;
            FiratName = firatName;
            LastNane = lastNane;
            Age = age;
            Gender = gender;
            count++;
        }

        public int Id{get;set;}
        public string FiratName{get;set;} 
        public string LastNane{get;set;}
        public int Age{get;set;}
        public string Gender{get;set;}
        
        public static void Studentadding(List<Student> Addstudent)
        {
            Console.Write("Enter the number of student you want to register: ");
            int noofstudent = int.Parse(Console.ReadLine());
            for (int i = 0; i < noofstudent; i++)
            {
                Console.Write("Enter the student firstname: ");
                string firatName = Console.ReadLine();
                Console.Write("Enter student lastname: ");
                string lastNane = Console.ReadLine();
                Console.Write("Enter the student age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Enter the gender: ");
                string gender = Console.ReadLine();
                Student student = new Student(firatName,lastNane,age,gender.ToLower());
                Addstudent.Add(student);
                Console.WriteLine("The student is fully registered");
            }
        }
        public static void Studentpinting(List<Student> Addstudent)
        {
            foreach (var item in Addstudent)
            {
                Console.WriteLine($"{item.Id} {item.FiratName} {item.LastNane} {item.Age} {item.Gender.ToUpper()}");
            }
        }
        public static void StudentGender(List<Student>Addstudent)
        {
            Console.Write ("Enter the genger you want: ");
            string gender = Console.ReadLine().ToLower();
            foreach (var item in Addstudent)
            {
                if(item.Gender == gender)
                {
                    Console.WriteLine($"{item.FiratName} {item.LastNane}");
                }
            }
        }
    }
}