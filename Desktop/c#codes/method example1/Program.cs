namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            Console.Write("Enter the operation you want to perform");
            string operation = (Console.ReadLine());
            Console.Write("Enter two numbers: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if(operation == "addition")
            {
                Addition( a, b);
            }
            if(operation == "subtraction")
            {
                Subtraction(a,b);
            }
            if (operation == "division")
            {
                Division(a,b);
            }
            if(operation == "modulos")
            {
                Modulos(a,b);
            }
            if (operation == "multiplication")
            {
                Multiplication(a,b);
            }


        }
    static void Addition(int a,int b)
    {
        Console.Write("Enter two numbers: ");
        //int a = int.Parse(Console.ReadLine());
        //int b = int.Parse(Console.ReadLine());
        int c = a + b;
        Console.WriteLine("The sum of the number is " + c);
    }
    static void Subtraction(int a,int b)
    {
        Console.Write("Enter two numbers: ");
        //int a = int.Parse(Console.ReadLine());
        //int b = int.Parse(Console.ReadLine());
        if (b > a)
        {
            int c = b - a;
            Console.WriteLine("The difference between the two numbers is "+c);
        }
        else
        {
            int c = a - b;
            Console.WriteLine("The difference between the two numbers is"+c);
        }
    }
    static void Division(int a,int b)
    {
        Console.Write("Enter two number: ");
        //int a = int.Parse(Console.ReadLine());
        //int b = int.Parse(Console.ReadLine());
        if (a > b)
        {
            int c= a/b;
            Console.WriteLine("The division of the two numbers is "+c);
        }
        else
        {
            Console.WriteLine("The division of the two numbers is"+b/a);
        }

    }
    static void Modulos(int a, int b)
    {
        
        if(a > b)
        {
            Console.WriteLine("The modulos of the two numbers is"+a%b);
        }
        else
        {
            Console.WriteLine("The modulos of the two number is "+b%a);
        }
    }
    static void Multiplication(int a, int b)
    {
        Console.Write("Enter two numbers: ");
        //int a = int.Parse(Console.ReadLine());
        //int b = int.Parse(Console.ReadLine());
        Console.WriteLine("The multiplication of the two numbers is "+a*b);
    }    
    }

}