namespace rev.ENTITIES
{
    public class Course
    {
        
        public int Id{get; set;}
        public string Name{get; set;}
        public string Description{get; set;}
        List<Studentcourse>studentcourses{get;set;} = new List<Studentcourse>();

    }
}