int n = int.Parse(Console.ReadLine());
for (int i =1; i <= n; i++)
{
    int space = n-i ;
    for (int j = 1; j <= space/2 ; j++)
    {
        Console.Write(" ");
    }
    
        for(int l = 0; l<i ; l ++)
        {
            Console.Write("*");
        }
Console.WriteLine();
    
}