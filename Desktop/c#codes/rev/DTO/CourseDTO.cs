namespace rev.DTO
{
    public class CourseDTO
    {
        
        public int Id{get; set;}
        public string Name{get; set;}
        public string Description{get; set;}
        public List<string>StudentName {get; set;}= new List<string>();
    }
}