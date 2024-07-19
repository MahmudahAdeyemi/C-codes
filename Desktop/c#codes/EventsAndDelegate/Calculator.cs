namespace EventsAndDelegate
{
    public delegate void Add(int x, int y);
    public class Calculator
    {
        public static void Sum(int a , int b){
            Console.WriteLine(a+b);
        }
    }
}