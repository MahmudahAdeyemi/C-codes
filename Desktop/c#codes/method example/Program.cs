namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            Printname();


            
        }
    static void  Printname()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.Write("Enter your gender: ");
        string gender = Console.ReadLine();
        Console.WriteLine("Hello" + name+ "Welcome to CLH");
        Printnametype(name);
        Getnameprefix(name,gender);
    }
    static void Printnametype(string name)
    {
        //Console.Write("Enter your name: ");
        //string name = Console.ReadLine().ToLower();
        string res = name.Substring(0, 1);
        if(res == "a" || res == "e" || res == "i" || res == "o" || res == "u")
        {
            Console.WriteLine("Your name starts with a vowel");
        }
        

    }
    static void Printage()
    {
        Console.WriteLine("My age is 1");
    }
    static void Getnameprefix(string name, string gender)
    {
        string newname;
        if (gender == "male")
        {
            newname =$"Mr.{name}";

        }
        else
        {
            newname = $"Mrs.{name}";
        }
        Console.WriteLine(newname);
    }


    }
}