namespace rev.ENTITIES
{
    public class Studentcourse
    {
    

    public int Id{get; set;}
    public int StudentId{get; set;}
    public int CourseId{get; set;}
    public Student Student{get; set;}
    public Course Course{get; set;}

    public Studentcourse(int studentId, int courseId)
    {
        studentId = StudentId;
        CourseId = courseId;
    }
    }
}