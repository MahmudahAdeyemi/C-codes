public class Program{

    public static void Main(string [] args){

        Console.WriteLine("Hello programming");
        SayHello();
        Weldone();
        int sum = Example2.Add(10,30);
        Console.WriteLine($"The addtion of a and b is {sum}");
        int subtract = Example3.subtract(40,10);
        Console.WriteLine($"The difference between a and b is {subtract}");

    }

    public static void SayHello(){

        Console.WriteLine("Your are welcome");


    }
    public static void Weldone(){

        Console.WriteLine("weldone");
    }

}