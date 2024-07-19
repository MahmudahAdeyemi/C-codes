public class Department
{

    public int Id{get; set;}
    public string Name{get; set;}
    public List<Student> Students{get; set;} = new List<Student>();
    public List<DepartmentCourse> DepartmentCourses {get; set;} = new List<DepartmentCourse>();
    public Department( string name)
    {
        Name = name;
    }
}