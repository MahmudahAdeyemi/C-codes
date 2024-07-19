using MVC.ENTITIES;

namespace MVC.INTERFACE;
public interface IDepartmentRepository
{
    void AddDepartment(Department department);
    void DeleteDepartment(int id);
    List<Department> GetAllDepartment();
    Department GetDepartmentById(int id);
    Department UpdateDepartment(int id, Department department);
}
