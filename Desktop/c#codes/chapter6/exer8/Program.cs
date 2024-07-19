Console.Write("Enter N: (N >=0 ) ");
int n = Int32.Parse(Console.ReadLine());
int N = 2 * n; 
int Nplus1 = n + 1;
for (int i = N - 1; i > 0; i--)
{ 
N *= i;
}
for (int i = Nplus1 - 1; i > 0; i--)
{ 
    Nplus1 *= i;
}
for (int i = n - 1; i > 0; i--)
{ 
    n *= i;
}
Console.WriteLine("Result is {0}", N / (Nplus1 * n));