int [] arr = new int[]{5};
double k = 1;
int int_k = Convert.ToInt32(k);
int [] new_arr = new int [int_k];
double average;


if (arr.Length == k)
{
    average = arr.Sum()/k;
}
else
{
    int diff = arr.Length - int_k ;
    if(diff % 2 == 0)
    {
        int div = diff / 2  ;
        for(int i = div; i < arr.Length - div; i ++)
        {
            new_arr[i - div] = arr[i];
        }
        average = new_arr.Sum() / k;

    }
    else
    {
        int div = diff / 2;
        for(int i = div - 1; i < arr.Length - div; i ++ )
        {
            new_arr[i - div - 1] = arr[i];
        }
        average = new_arr.Sum() / k;
    }
}
Console.WriteLine(average);