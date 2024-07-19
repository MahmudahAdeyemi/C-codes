Console.Write("Enter a number: ");
int n = int.Parse(Console.ReadLine());
int a= 1;
while(a <= 12)
{
    Console.Write (" {0} * {1} = {2}\n ", n, a, n * a);
    a++;
}