namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            GetOccurence();
            
        }
        static void GetOccurence()
        {
            int count = 0;
            Console.Write("Enter length of array: ");
            int lenght = int.Parse(Console.ReadLine());
            Console.Write("Enter number to check the sequence");
            int sequence = int.Parse(Console.ReadLine());
            int[]arr = new int [lenght];
            for(int i = 0;i < lenght;i ++)
            {
                Console.Write("Enter {0} element: " );
                arr[i] = Int32.Parse(Console.ReadLine());
                if(arr[i] == sequence)
                {
                    count ++ ;

                }

            }
            Console.WriteLine(count);
        }
    }
}    