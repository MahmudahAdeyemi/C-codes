int[ , ] array = new int[2,3]{{1,2,3},
                             {2,4,5}
                             };
for (int row = 0; row < array.GetLength(0); row ++)
{
    for (int col = 0; col < array.GetLength(1); col ++ )
    {
        Console.Write(array[row,col]);
    }
    Console.WriteLine();
}