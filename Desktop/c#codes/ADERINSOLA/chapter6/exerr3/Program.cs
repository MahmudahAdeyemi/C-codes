 int lowest = 0;
 int highest = 0;
Console.Write("Enter numbers length: ");
int lenght = Int32.Parse(Console.ReadLine());            
for (int i = 0; i < lenght; i++)
{
    Console.Write("Enter number: ");
    int input = int.Parse(Console.ReadLine());
        if (i == 0)
        {
        lowest = highest = input;
        }
        else
        {
        if (lowest > input) 
        {
        lowest = input;
        }
        if (highest < input) 
        {
        highest = input;
        }
        }                
}
Console.WriteLine("Lowest - {0}, Highest - {1}", lowest, highest);    