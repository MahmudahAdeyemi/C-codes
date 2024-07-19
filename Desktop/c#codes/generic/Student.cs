namespace Method
{
    class Student : Person
    {
        public Student(string firstName, string lastName, string studentId) : base(firstName, lastName)
        {
            StudentId = studentId;
        }

        public string StudentId{get; set;}

    }
}