using MVC.ENTITIES;

namespace MVC;
public interface IStudentRepository
{
    void AddStudent(Student student);
    void DeleteStudent(int id);
    List<Student> GetAllStudents();
    List<Student> GetStudentByDepartmentId();
    Student GetStudentById(int id);
    Student UpdateStudent(int id,Student student1);
}