namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            
            Console.WriteLine("Pick your gender: ");
            Console.WriteLine("\t1. Male");
            Console.WriteLine("\t2. Female");
            int option = int.Parse(Console.ReadLine());

            Gender gender = (Gender) option;

            Console.WriteLine($"You are a {gender}");
        }
    }
}