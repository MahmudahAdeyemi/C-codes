public class DepartmentRepostory
{
    EfCoreProjectContext _efCoreProjectContext ;
    CourseRepository courseRepository;
    public DepartmentRepostory(EfCoreProjectContext efCoreProjectContext)
    {
        _efCoreProjectContext = efCoreProjectContext;
    }
    public void AddDepartment(Department department)
    {
        _efCoreProjectContext.Add(department);
        _efCoreProjectContext.SaveChanges();
        Console.WriteLine("Operation sucessful.");
    }
    public List<Department> GetAllDepartment()
    {
        List<Department> departments = _efCoreProjectContext.Departments.ToList();
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
        Department department = _efCoreProjectContext.Departments.SingleOrDefault(x => x.Id == id);
        return department;
    }
    public void UpdateDepartment(int id , string name)
    {
        var x = GetAllDepartment();
        foreach (var item in x)
        {
            Console.WriteLine($"{item.Id}       {item.Name}");
        }
        
        Department department = _efCoreProjectContext.Departments.SingleOrDefault(x => x.Id == id);
        department.Name = name;
        _efCoreProjectContext.Departments.Update(department);
    }
}