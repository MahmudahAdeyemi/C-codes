namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            Neighbour();
        }
        static void Neighbour()
        {
            Console.Write("Enter length of array: ");
            int lenght = int.Parse(Console.ReadLine());
            int [] arr = new int [lenght];
            for (int i = 0;i < lenght;i ++ )
            {
                Console.Write("Enter number: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            for(int i = 0;i < (lenght - 2);i ++)
            {
                if (arr[i] > arr[i + 1] && arr[i] > arr[i + 2] )
                {
                    Console.WriteLine(arr[i]);
                    break;
                }
                else
                {
                    Console.WriteLine("-1");
                }

            }
            
        }
    }
}    