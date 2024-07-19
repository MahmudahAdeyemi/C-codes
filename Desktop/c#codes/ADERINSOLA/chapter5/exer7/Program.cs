int a=5;
int b= 6;
int c = 7;
int d = 8;
int e = 9;
if (a > b && a> c && a >d && a > e)
{
    Console.WriteLine(a + "is the greatest number");

}
if(b > a && b > c && b > d && b <e)
{
    Console.WriteLine(b+" is the greatest number");
}

if (c>a && c>b && c>d && c> e)
{
   Console.WriteLine(c+" is the greatest number"); 
}
if (d>a && d>b && d>c && d> e)
{
    Console.WriteLine(b+" is the greatest number");
}
else
{
    Console.WriteLine(e+" is the greatest number");
}