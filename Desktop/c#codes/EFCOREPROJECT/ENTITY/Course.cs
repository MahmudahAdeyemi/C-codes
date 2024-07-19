public class Course
{

    public int Id{get; set;}
    public string Name{get; set;}
    public string Description{get; set;}
    public List<DepartmentCourse> CourseDepartments {get; set;} = new List<DepartmentCourse>();
    public Course(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

}