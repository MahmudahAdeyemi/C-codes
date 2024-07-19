public class Course
{

    public int Id{get; set;}
    public string Name{get; set;}
    public string Description{get; set;}
    public List<DepartmentCourse> CourseDepartments {get; set;} = new List<DepartmentCourse>();
    public Course( string name, string description)
    {
        Name = name;
        Description = description;
    }

}