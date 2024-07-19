namespace Method
{
    class Teacher : Person
    {
        public Teacher(string firstName, string lastName, string teacherId) : base(firstName, lastName)
        {
            TeacherId = teacherId;
        }

        public string TeacherId{get; set;}

    }
}