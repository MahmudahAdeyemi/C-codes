Console.Write("Enter lenght of number: ");
int len = int.Parse(Console.ReadLine());
int[] arr = new int[len];
int temp;
for (int i = 0; i < len ; i ++)
{
    Console.Write("Enter element: ");
    arr[i] = int.Parse(Console.ReadLine());
}
for(int i = 0; i < len -1; i ++)
{
    for(int j = 0 ; j < len-1-i; j ++)
    {
        if (arr[j] > arr[j +1])
        {
            temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;

        }
    }
}
for(int i = 0; i < len -1; i ++)
{
    if(arr[i] != arr[i + 1]-1)
    {
        Console.WriteLine("The mising number is " + (arr[i] + 1));

    }
    //else Console.WriteLine("There is no missing number");
}
// foreach (var val in arr)
// {
//     Console.Write(val + " ");
// }