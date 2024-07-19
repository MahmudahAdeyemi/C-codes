int [] arr = new int []{1,3,2,2,5,2,3,7};
Array.Sort(arr);
bool check = true;

int b = arr.Length - 1;
for (int i = 0; i < b; i ++)
{
    if ((arr[b] - arr[i]) != 1)
    {
        
        check = false;
        if((arr[b] - arr[i]) != 0)
        {
            b --;
            check = false;
        }
        else
        {
            Console.WriteLine((arr.Length - ((i + 1) * 2) + 2 ));
            break;
        }
    }
    else
    {
        Console.WriteLine((arr.Length - ((i+1 )* 2) + 1) );
        break;
    }

}
