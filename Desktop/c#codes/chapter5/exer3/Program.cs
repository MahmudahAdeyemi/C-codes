int a = 2;
int b= 7;
int c = 24;
bool f = (a>b);
if (f)
{
    bool g = (a > c);
    if (g)
    {    
        Console.WriteLine(a+ " is the greatest number.");    
    }
}

bool j = (b>a);
if (j)
{
    bool k = (b > c);
    if (k)
    {
        Console.WriteLine(b+ " is the greatest number.");
    }
}

bool n = (c>a);
if (n)
{
    bool o = (c > b);
    if (o)
    {
        Console.WriteLine(c+ " is the greatest number.");
    }
}