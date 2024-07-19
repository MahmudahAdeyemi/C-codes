namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            Console.Write("Enter three numbers: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            GetMax(a,b);
            GetMax(a,b,c);
        }
        static void GetMax(int a,int b)
        {
            Console.WriteLine(Math.Max(a,b));
        }
        static void GetMax(int a, int b, int c)
        {
            if (a > b  && a > c ) Console.WriteLine(a);
            if (b > a && b > c) Console.WriteLine(b);
            if (c > a && c > b) Console.WriteLine(c);
        }
    }
}