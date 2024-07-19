namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            Adding();

        }
        static void Adding()
        {
            Console.Write("Enter lenght of array: ");
            int len = int.Parse(Console.ReadLine());
            int[]arr = new int [len];
            int [] new_arr = new int [len];
            for(int i = 0; i< len; i ++)
            {
                Console.Write("Enter the element: ");
                arr[i] = int .Parse (Console.ReadLine());

            }
            int min = arr.Min();
            Console.WriteLine("The min value is "+min);
            int count = 0;
            //string adding = "";
            for (int i = 0; i < len - 1; i ++)
            {
                if ( arr[i] < arr[i + 1]  )
                {
                    new_arr[count] += arr[i]; 
                    count ++;
                }
                //else //count = 0;

                
            }
            for (int i = 0; i < count; i ++)
            {
                Console.Write(new_arr[i]);
            }
        }
    }
}
