public class StudentRepository
{
    EfCoreProjectContext _efCoreProjectContext;
    public StudentRepository(EfCoreProjectContext efCoreProjectContext)
    {
        _efCoreProjectContext = efCoreProjectContext;
    }
    public void AddStudent(Student student)
    {
        DepartmentRepostory departmentRepostory = new DepartmentRepostory(_efCoreProjectContext);
        var d = departmentRepostory.GetAllDepartment();
        foreach (var item in d)
        {
            Console.WriteLine($"{item.Id}   {item.Name}");
        }
        
        _efCoreProjectContext.Students.Add(student);
        _efCoreProjectContext.SaveChanges();
    }
    public void UpdateStudentsFirstname(string firstname, string surname)
    {
        Student student = _efCoreProjectContext.Students.SingleOrDefault(x => x.FName == firstname && x.LName == surname);
        student.FName = firstname;
        _efCoreProjectContext.Students.Update(student);
        _efCoreProjectContext.SaveChanges();
        Console.WriteLine("Student updated.");
    }
    public void UpdateStudentsSurname(string firstname,string surname)
    {
        Student student = _efCoreProjectContext.Students.SingleOrDefault(x => x.FName == firstname && x.LName == surname);
        student.LName = surname;
        _efCoreProjectContext.Students.Update(student);
        _efCoreProjectContext.SaveChanges();
        Console.WriteLine("Student updated.");
    }
    public void DeleteStudent(int id)
    {
        Student student = _efCoreProjectContext.Students.SingleOrDefault(x => x.Id == id);
        _efCoreProjectContext.Students.Remove(student);
        _efCoreProjectContext.SaveChanges();
    }
    public List<Student> GetStudentByDepartmentId()
    {
        DepartmentRepostory departmentRepostory = new DepartmentRepostory(_efCoreProjectContext);
        departmentRepostory.GetAllDepartment();
        Console.Write("Enter the id of the departmenn=t:  ");
        int departmentId = int.Parse(Console.ReadLine());
        List<Student> student = _efCoreProjectContext.Students.Where(x => x.DepartmentId == departmentId).ToList();
        return student;
    }
    public Student GetStudentById(int id)
    {
        Student student = _efCoreProjectContext.Students.SingleOrDefault(x => x.Id == id);
        return student;
    }
    public List<Student> GetAllStudents()
    {
        List<Student> students = _efCoreProjectContext.Students.ToList();
        return students;
    }
}
