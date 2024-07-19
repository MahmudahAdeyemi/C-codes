int count = 0;
Console.Write ("Enter array length: ");
int length = Int32.Parse (Console.ReadLine ());
Console.Write("Enter the sequence: ");
int sequence = int.Parse(Console.ReadLine());
int[] arr = new int[length];
for (int i = 0; i < arr.Length; i++) 
{
	Console.Write ("Enter {0} element: ", i);
	arr [i] = Int32.Parse (Console.ReadLine ());
}
for (int i = 0; i < arr.Length - 1; i++) 
{
    if (arr[i] == sequence) 
    {
    count ++ ;
    }
}