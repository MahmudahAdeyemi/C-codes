using Microsoft.EntityFrameworkCore;
using MVC.ENTITIES;
using MVC.INTERFACE;

namespace MVC.REPOSITORIES;
public class DepartmentRepostory : IDepartmentRepository
{
    MVCContext _efCoreProjectContext;
    public DepartmentRepostory(MVCContext efCoreProjectContext)
    {
        _efCoreProjectContext = efCoreProjectContext;
    }
    public void AddDepartment(Department department)
    {
        _efCoreProjectContext.Add(department);
        _efCoreProjectContext.SaveChanges();
    }
    public List<Department> GetAllDepartment()
    {
        var departments = _efCoreProjectContext.Departments.ToList();
        return departments;
    }
    public void DeleteDepartment(int id)
    {
        Department department = _efCoreProjectContext.Departments.SingleOrDefault(x => x.Id == id);
        _efCoreProjectContext.Departments.Remove(department);
        _efCoreProjectContext.SaveChanges();
    }
    public Department GetDepartmentById(int id)
    {
        Department department = _efCoreProjectContext.Departments.Include(x => x.Students).SingleOrDefault(x => x.Id == id);
        return department;
    }
    public Department UpdateDepartment(int id, Department department1)
    {

        Department department = _efCoreProjectContext.Departments.SingleOrDefault(x => x.Id == id);
        department.Name = department1.Name;
        _efCoreProjectContext.Departments.Update(department);
        _efCoreProjectContext.SaveChanges();
        return department1;
    }
}