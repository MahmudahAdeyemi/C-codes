Console.Write("Enter N: (1<K<N) ");
int n = Int32.Parse(Console.ReadLine());
Console.Write("Enter K: (1<K<N) ");
int k = Int32.Parse(Console.ReadLine());
    
for (int i = n - 1; i > 0; i--)
{
    n *= i;
}
    
for (int i = k - 1; i > 0; i--)
{
    k *= i;
}
    
n /= k;    
Console.WriteLine("Result is {0}", n);