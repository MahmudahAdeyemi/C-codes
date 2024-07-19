int a = 2;
int b= 7;
int c = 24;
int d = 29;
int e = 135;
bool f = (a>b);
if (f)
{
    bool g = (a > c);
    if (g)
    {
        bool h = (a > d);
        if (h)
        {
            bool i =(a > e);
            if (i)
            {
                Console.WriteLine(a+ " is the greatest number.");
            }
        }
    }
}

bool j = (b>a);
if (j)
{
    bool k = (b > c);
    if (k)
    {
        bool l = (b > d);
        if (l)
        {
            bool m =(b > e);
            if (m)
            {
                Console.WriteLine(b+ " is the greatest number.");
            }
        }
    }
}

bool n = (c>a);
if (n)
{
    bool o = (c > b);
    if (o)
    {
        bool p = (c > d);
        if (p)
        {
            bool q =(c > e);
            if (q)
            {
                Console.WriteLine(c+ " is the greatest number.");
            }
        }
    }
}

bool r = (d>a);
if (r)
{
    bool s = (d > b);
    if (s)
    {
        bool t = (d > c);
        if (t)
        {
            bool u =(d > e);
            if (u)
            {
                Console.WriteLine(d+ " is the greatest number.");
            }
        }
    }
}

bool v = (e>a);
if (v)
{
    bool w = (e > b);
    if (w)
    {
        bool x = (e > d);
        if (x)
        {
            bool y =(e > c);
            if (y)
            {
                Console.WriteLine(e+ " is the greatest number.");
            }
        }
    }
}