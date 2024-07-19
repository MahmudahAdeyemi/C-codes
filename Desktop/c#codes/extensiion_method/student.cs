namespace ExtensionMethod
{
    class Student
    {
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void PrintFirstName()
        {
            Console.WriteLine(this.FirstName);
        }
        
    }
}