namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            Student student = new Student("Ola", "Kola", "Stud111");
            Teacher teacher = new Teacher("Remi", "Kunle", "Teach111");

            var generic = new MyGeneric<Person>();
            generic.Print(teacher);

            
        }
    }
}