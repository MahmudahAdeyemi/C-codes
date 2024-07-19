public class CourseUtility
{
    EfCoreProjectContext _efCoreProjectContext ;
    public CourseUtility(EfCoreProjectContext efCoreProjectContext1)
    {
        _efCoreProjectContext = efCoreProjectContext1;
    }
    public void AddCourse()
    {
        
        Console.WriteLine("Enter course name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the description: ");
        string description = Console.ReadLine();
        Course course = new Course(name, description);
        CourseRepository courseRepository = new CourseRepository(_efCoreProjectContext);
        courseRepository.AddCourse(course);
    }
    public void GetCourseById()
    {
        CourseRepository courseRepository = new CourseRepository(_efCoreProjectContext);
        var c= courseRepository.GetCourseById();
        Console.WriteLine($"{c.Id}      {c.Name}        {c.Description}");
    }
    public void UpdateCourseName()
    {
        
        Console.Write("Enter the name of the course: ");
        string name = Console.ReadLine();
        CourseRepository courseRepository = new CourseRepository(_efCoreProjectContext);
        courseRepository.UpdateCourseName(name);
    }
    public void GetAllCourses()
    {
        CourseRepository courseRepository = new CourseRepository(_efCoreProjectContext);
        var c = courseRepository.GetAllCourses();
        foreach (var item in c)
        {
            Console.WriteLine($"{item.Id}       {item.Name}        {item.Description}");
        }
    }
    public void DeleteCourse()
    {
        CourseRepository courseRepository = new CourseRepository(_efCoreProjectContext);
        Console.Write("Enter the id of the course you want to delete: ");
        int id = int .Parse(Console.ReadLine());
        courseRepository.DeleteCourse(id);
    }
    public void GetCoursesbyDepartmentId()
    {
        CourseRepository courseRepository = new CourseRepository(_efCoreProjectContext);
        Console.Write("Enter the id of the course you want to delete: ");
        int id = int .Parse(Console.ReadLine());
        var c = courseRepository.GetCoursesbyDepartmentId(id);
        foreach (var item in c)
        {
            Console.WriteLine($"{item.Id}       {item.Name}        {item.Description}");
        }
    }
}