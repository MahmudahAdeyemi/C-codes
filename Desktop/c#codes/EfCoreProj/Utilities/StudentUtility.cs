public class StudentUtility
{
    EfCoreProjectContext _efCoreProjectContext ;
    public StudentUtility(EfCoreProjectContext efCoreProjectContext1)
    {
        _efCoreProjectContext = efCoreProjectContext1;
    }
    public void AddStudent()
    {
        CourseRepository courseRepository = new CourseRepository(_efCoreProjectContext);
        Console.Write("Enter your firstname: ");
        string firstname = Console.ReadLine();
        Console.Write("Enter your surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();
        Console.Write("Enter the id of the department you want: ");
        int departmentId = int.Parse(Console.ReadLine());
        Student student = new Student(firstname,surname,age,email,password,departmentId);
        var c = courseRepository.GetCoursesbyDepartmentId(departmentId);
        Console.WriteLine("These are the courses you are going to do: ");
        foreach (var item in c)
        {
            Console.WriteLine($"{item.Name}");
        }
        StudentRepository studentRepository = new StudentRepository(_efCoreProjectContext);
        studentRepository.AddStudent(student);
    }
    public void UpdateStudentsFirstname()
    {
        Console.Write("Enter the previous firstname: ");
        string firstname = Console.ReadLine();
        Console.Write("Enter the previous lastname: ");
        string surname = Console.ReadLine();
        StudentRepository studentRepository = new StudentRepository(_efCoreProjectContext);
        studentRepository.UpdateStudentsFirstname(firstname,surname);
    }
    public void UpdateStudentsSurname()
    {
        Console.Write("Enter the previous firstname: ");
        string firstname = Console.ReadLine();
        Console.Write("Enter the previous lastname: ");
        string surname = Console.ReadLine();
        StudentRepository studentRepository = new StudentRepository(_efCoreProjectContext);
        studentRepository.UpdateStudentsSurname(firstname,surname);
    }
    public void DeleteStudent()
    {
        Console.Write("Enter the id: ");
        int id = int.Parse(Console.ReadLine());
        StudentRepository studentRepository = new StudentRepository(_efCoreProjectContext);
        studentRepository.DeleteStudent(id);
    }
    public void GetStudentByDepartmentId()
    {
        StudentRepository studentRepository = new StudentRepository(_efCoreProjectContext);
        var c = studentRepository.GetStudentByDepartmentId();
        foreach (var item in c)
        {
            Console.WriteLine($"{item.Id}       {item.FName}    {item.LName}        {item.Age}      {item.Email}        {item.Password}");
        }
    }
    public void GetStudentById()
    {
        Console.Write("Enter the id: ");
        int id = int.Parse(Console.ReadLine());
        StudentRepository studentRepository = new StudentRepository(_efCoreProjectContext);
        var c =  studentRepository.GetStudentById(id);
        Console.WriteLine($"{c.Id}       {c.FName}    {c.LName}        {c.Age}      {c.Email}        {c.Password}") ;
    }
    public void GetAllStudents()
    {
        StudentRepository studentRepository = new StudentRepository(_efCoreProjectContext);
        var c= studentRepository.GetAllStudents();
        foreach (var item in c)
        {
            Console.WriteLine($"{item.Id}       {item.FName}    {item.LName}        {item.Age}      {item.Email}        {item.Password}");
        }
    }
}