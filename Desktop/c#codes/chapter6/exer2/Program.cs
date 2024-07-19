int n = 50;
for (int i = 1; i <= n; i += 2)
{
    bool we  = (i %7 ==0);
    if (we)
    {
        Console.WriteLine(i + " ");
    }
    bool well = (i % 3 == 0);
    if (well)
    {
        Console.WriteLine(i + " ");
    }
}
