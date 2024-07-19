public class DepartmentUtility
{
    EfCoreProjectContext _efCoreProjectContext ;
    public DepartmentUtility(EfCoreProjectContext efCoreProjectContext1)
    {
        _efCoreProjectContext = efCoreProjectContext1;
    }
    public void AddDepartment()
    {
        
        Console.Write("Enter the name of the course: ");
        string name = Console.ReadLine();
        Department department = new Department(name);
        DepartmentRepostory departmentRepostory = new DepartmentRepostory(_efCoreProjectContext);
        departmentRepostory .AddDepartment(department);
    }
    public void GetAllDepartment()
    {
        DepartmentRepostory departmentRepostory = new DepartmentRepostory(_efCoreProjectContext);
        var x = departmentRepostory.GetAllDepartment();
        foreach (var item in x)
        {
            Console.WriteLine($"{item.Id}       {item.Name}");
        }
    }
    public void DeleteDepartment()
    {
        Console.Write("Enter the id of the department you want: ");
        int id = int.Parse(Console.ReadLine());
        DepartmentRepostory departmentRepostory = new DepartmentRepostory(_efCoreProjectContext);
        departmentRepostory.DeleteDepartment(id);
    }
    public void GetDepartmentById()
    {
        Console.Write("Enter the id of the department you want: ");
        int id = int.Parse(Console.ReadLine());
        DepartmentRepostory departmentRepostory = new DepartmentRepostory(_efCoreProjectContext);
        var c = departmentRepostory.GetDepartmentById(id);
        Console.WriteLine($"{c.Id}      {c.Name}");
    }
    public void UpdateDepartment()
    {
        DepartmentRepostory departmentRepostory = new DepartmentRepostory(_efCoreProjectContext);
        Console.Write("Enter the id of the department you want to update:  ");
        int id = int .Parse(Console.ReadLine());
        Console.Write("Enter the newname of the department: ");
        string name  = Console.ReadLine();
        departmentRepostory.UpdateDepartment(id,name);
    }
}