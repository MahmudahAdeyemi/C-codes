﻿class Multiplication
{
    static void Main()
    {
        Console.WriteLine("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter c: ");
        double c = double.Parse(Console.ReadLine());
        if( (a < 0 && b > 0 && c>0 ) || (a > 0 && b < 0 && c < 0) || (a < 0 && b < 0 && c > 0) )
        {
            Console.WriteLine("The multiplication sign is - .");
        }
        else
        {
            Console.WriteLine("The multiplication sign is + .");
        }

    }
}