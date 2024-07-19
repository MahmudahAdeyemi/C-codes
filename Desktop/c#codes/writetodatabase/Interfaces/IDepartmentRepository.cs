public interface IDepartmentRepository
{
    bool AddDepartment(string name, string description);
    bool Updatedepartment(int id,string name);
    bool DeleteDepartment(int id);
    Department GetDepartmentById(int id);
    List<Department> GetAllDepartments();
}