Console.Write("Enter a number: ");
int n = int.Parse(Console.ReadLine());
int sum = 0;
for (int i = 1; i <= n; i++)
{
    sum += i;
    Console.WriteLine("The sum of the number is " +sum);
}
int counter = 1;
int add = 0;
while(counter <= n)
{
add += counter;
counter ++ ;
Console.WriteLine("The sum is "+add);
}