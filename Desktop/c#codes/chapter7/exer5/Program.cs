Console.Write("Enter lenght of array: ");
int len = int.Parse(Console.ReadLine());
int[]array = new int[len];
for (int i = 0; i < len; i ++)
{
    Console.Write("Enter the number: ");
    array[i ] = int .Parse(Console.ReadLine());
}
for (int i = 0;i< len -2; i ++)
{
        if(array[i] +1 == (array[i +1] ))
        {
           if(array[i+1] + 1 == array[i + 2])
           {
                Console.WriteLine(array[i] + " "+ array[i+1] +" " + array[i +2]);
           }
        }
}