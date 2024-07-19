Console.Write("Enter lenght of arr: ");
int len = int.Parse(Console.ReadLine());
int [] arr = new int[len];
int count = 0;
//char zero = '0';
string new_arr = " ";
for(int i = 0; i < len; i ++)
{
    Console.Write("Enter element: ");
    arr[i] = int .Parse(Console.ReadLine());
}
for(int i = 0; i < len; i ++)
{
    if(arr[i] == 0)
    {
        count ++;
    }
}
for (int i = 0; i < len; i ++)
{
    
    if (arr[i] == 0)
    {
        arr[i] = 00;
        
    }
}
for (int i = 0; i < len; i ++)
{
    Console.Write(arr[i]);
}