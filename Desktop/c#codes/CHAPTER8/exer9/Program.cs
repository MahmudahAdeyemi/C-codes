namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {

        }
        static void Descend()
        {
            Console.Write("Enter lenght of array: ");
            int lenght = int.Parse(Console.ReadLine());
            int[]arr = new int[lenght];
            int [] descend = new int [lenght];
            for(int i = 0; i > lenght; i ++)
            {
                if(arr[i] > arr[lenght- i - 1])
                {
                    
                }
            }
        }
    }
}