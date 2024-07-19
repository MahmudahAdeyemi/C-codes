int num = 9;
int solve = num % 5;
int solved = num % 7;
bool Mycheck = (solve == 0);
bool Mychecked = (solved == 0);
if (Mycheck)
{
    Console.WriteLine(num+" is divisible by 5");
}
else
if (Mychecked)
{
    Console.WriteLine(num+" is divisible by 7");
}
else
{
    Console.WriteLine(num+" is not divisible by both 5 and 7");
}