public class DepartmentCourse
{
    public DepartmentCourse(int departmentId, int courseId)
    {
        DepartmentId = departmentId;
        CourseId = courseId;
    }

    public int Id{get; set;}
    public int DepartmentId{get; set;}
    public int CourseId{get; set;}
    public Department Department{get; set;}
    public Course Course{get; set;}
}