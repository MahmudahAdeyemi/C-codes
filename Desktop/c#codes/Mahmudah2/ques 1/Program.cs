bool check = true;
int [] arr = new int []{3,1,7,11};
string[]array = new string [arr.Length];
for(int i = 0; i < arr.Length; i ++)
{
    array[i] = arr[i].ToString();
}

for (int i = 0; i < arr.Length; i ++)
{
    int twice = arr[i] * 2;
    string string_twice = twice.ToString();
    if(arr.Contains(twice))
    {
       check = true; 
       break;
    }
    else
    {
        check = false;
    }
    
}
Console.WriteLine(check);