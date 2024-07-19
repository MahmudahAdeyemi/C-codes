namespace LinqExample
{
    public class Course
    {
        public Course(string name,int studentId)
        {
            Name = name;
            StudentId = studentId;
        }


        public string Name{get; set;}
        public int StudentId {get;set;}
    }
}