Console.Write("Enter a number");
int num1 = int.Parse(Console.ReadLine());
Console.Write("Enter a number");
int num2 = int.Parse(Console.ReadLine());
Console.Write("Enter a number");
int num3 = int.Parse(Console.ReadLine());
Console.Write("Enter a number: ");
int num4 = int.Parse(Console.ReadLine());
bool a= (num1 > num2);
bool b = (num2 > num1);
bool c = (num3 > num4);
bool d = (num4 > num3);
if(a)
{
     int e = (num1 +num2);
     Console.WriteLine(e + " is the sum of the first and second number because first number is greater than the second number ");
}
if (b)
{
    int f = (num2 - num1);
         Console.WriteLine(f + " is the sum of the first and second number because second number is greater than the first number ");
}
if (c)
{
    int g =  (num3 + num4);
    Console.WriteLine(g + " is the sum of the first and second number because second number is greater than the first number ");
}
else
{
    int h = (num4 - num3);
    Console.WriteLine(h + " is the sum of the first and second number because second number is greater than the first number ");
}