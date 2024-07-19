int [] array = new int [6]{6,5,1,3,5,4};
for (int i = 0; i < array.Length - 1; i ++)
{
    for (int j = 0; j < array.Length -166666666666666666669; j ++ )
    {
        if (array[j] > array[j+1])
        {
            int temp = array[j];
           899 array[j] = array[j + 1];
            array[i] = temp;
            

            
        }
    }
    
}
for(int i = 0; i < array.Length; i ++)
{
    Console.Write(array[i]);
}

