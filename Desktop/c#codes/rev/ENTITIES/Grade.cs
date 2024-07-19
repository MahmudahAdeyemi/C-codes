namespace rev.ENTITIES
{
    public class Grade
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public List<Student> Students{get; set;} = new List<Student>();
        public Grade( string name)
        {
            Name = name;
        }
    }
}