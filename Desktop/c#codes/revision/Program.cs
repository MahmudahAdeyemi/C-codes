namespace Method
{
    class Program
    {
        delegate void SimpleArithmetic(double num1, double num2);
        static void Main(string[]args)
        {
            //SimpleArithmetic simpleArithmetic = new SimpleArithmetic(Addition);
            // SimpleArithmetic simpleArithmetic = Addition;
            // simpleArithmetic += Subtractrion;
            // simpleArithmetic(4, 8);
            
            Console.Write("Enter the total number yo want to calculate: ");
            int num = int.Parse(Console.ReadLine());
            int [] array = Collector(num);
            Console.WriteLine("The average is "+ Average(array));

        }
        
        // public static string Addition(double a, double b)
        // {
        //     Console.WriteLine(a+b);
        //     return "";
        // }
        // public static string Subtractrion(double a, double b)
        // {
        //     Console.WriteLine(a-b);
        //     return " ";
        // }
        public static int[] Collector(int num)
        {
            int [] array = new int[num];
            for (int i = 0; i < num; i ++)
            {
                Console.Write("Enter the num: ");
                array[i] = int.Parse( Console.ReadLine());
            }
            return array;
        }
        public static double Average(int[] array) => array.Average();
        public void SayHello()
        {
            Console.WriteLine("It is nice to meet you");
        }
        public void SayHello(int c)
        {
            Console.WriteLine("It is nice to meet you");
        }
    }

     class MahmudasClass
    {
        int[] resp = Program.Collector(3);
    }

}