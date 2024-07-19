int num1 = 0;
int num2 = 1;
int sum = 0;
int count =0 ;
Console.Write("Enter a number");
int n = int.Parse(Console.ReadLine());
    
Console.WriteLine(num1);
    
while(count <=(n-2))
{
    sum = num1 + num2;
    Console.WriteLine(num2);
    num1 = num2;
    num2 = sum;
    
    count++;
}
