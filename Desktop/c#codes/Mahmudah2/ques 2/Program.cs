int num = 7;
int count = 0 ;

int [] factor = new int [num];
int [] arr = new int [num];
string factors = "";
for (int i = 1; i <= num; i ++ )
{
arr[i - 1] = i;
}
for(int i = 0; i < num -1 ; i ++)
{
    if (num % arr[i] == 0)
    {
        count ++;
        factor[count] = arr[i];
    }
}
Console.WriteLine(factors);
//for (int i = 0; i < count ; i ++)
// for(int i = 0; i < count; i ++)
// {
//     Console.Write(factor[i] + " ");
// }
//int int_factors = int.Parse(factors);
int sum = 0;
// for (int i = 0; i < factors.Length; i ++ )
for (int i = 0 ; i < factor.Length; i ++)
{
    sum += factor[i];
    // Console.Write(sum);

}
// int sum = factor.Sum();
//Console.WriteLine(sum);
if (sum == num)
{
    Console.WriteLine("True");
}
else
{
    Console.WriteLine("False");
}