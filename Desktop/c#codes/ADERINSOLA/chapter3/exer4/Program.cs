int a = 98575665;
int b = a /100;
int c = b % 10;
bool d = (c == 7);
if (d)
{
    Console.WriteLine("The third to the last number in "+a+" is 7." );
}
else
{
    Console.WriteLine("The third to the last digit in "+a+"is not eqaul to 7");
}