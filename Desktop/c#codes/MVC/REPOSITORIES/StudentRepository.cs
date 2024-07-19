using MVC.ENTITIES;
using MVC.REPOSITORIES;

namespace MVC;
public class StudentRepository : IStudentRepository
{
    MVCContext _efCoreProjectContext;
    public StudentRepository(MVCContext efCoreProjectContext)
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
    public Student UpdateStudent(int id,Student student1)
    {
        Student student2 = _efCoreProjectContext.Students.SingleOrDefault(x => x.Id == id);
        student2.FName = student1.FName;
        student2.LName=student1.LName;
        student2.Age = student1.Age;
        student2.Email=student1.Email;
        student2.Password=student1.Password;
        student2.DepartmentId=student1.DepartmentId;
        _efCoreProjectContext.Students.Update(student2);
        _efCoreProjectContext.SaveChanges();
        Console.WriteLine("Student updated.");
        return student1;
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
