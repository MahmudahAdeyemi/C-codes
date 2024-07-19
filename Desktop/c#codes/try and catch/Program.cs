// int y=10;
// int x =0;
// int z = y/x;
// Console.WriteLine(z);
// int[]arr = new int[4];
// arr[5] = 4;
// Console.WriteLine(arr[5]);
// try
// {
//     int y =10;
//     int x = 0;
//     int z = y/x;
//     Console.WriteLine(z);
// }
// catch(DataMisalignedException e)
// {
//     Console.WriteLine(e);
// }
// catch(Exception e)
// {
//  Console.WriteLine(e);
// }
// try
// {
//     int[]arr = new int[4];
//     arr[2] = 4;
//     Console.WriteLine(arr[7]);
// }
// catch(IndexOutOfRangeException e)
// {
//     Console.WriteLine(e);;
// }
// finally
// { 
//     Console.WriteLine("Enter 1 to go  back to the menu");
// }

namespace Method
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PrintEvenNumber(6);
            }
            catch(OddNumberException e)
            {
                Console.WriteLine(e.Message);
            }



        }

        public static void PrintEvenNumber(int num)
        {
            if (num % 2 != 0)
            {
                throw new OddNumberException("You have supplied an odd number");
            }

            Console.WriteLine("The even number is " + num);
        }


    }


    public class InvalidException : Exception
    {
        public InvalidException(string message) : base(message)
        {

        }
    }

    public class OddNumberException : Exception
    {
        public OddNumberException(string message) : base(message)
        {

        }
    }
}