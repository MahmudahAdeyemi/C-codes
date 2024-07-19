Console.Write("Enter the lenght of the number: ");
int lenght = int.Parse (Console.ReadLine());
int[]array = new int[lenght];
for(int i = 0; i < lenght; i ++)
{
    Console.Write("Enter the number: ");
    array[i] = int.Parse(Console.ReadLine());
}
for (int i = 0; i < lenght ; i ++)
{
    if (array[i] % 2 == 0)
    {
        Console.Write(array[i]);
    }
}