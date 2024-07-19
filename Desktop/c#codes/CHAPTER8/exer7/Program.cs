namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            Array();
        }
        static void Array()
        {
            int [] arr = new int [3]{2,3,4};
            int []array = new int [3];
            int lenght = arr.Length;
            for(int i = 0;i<lenght;i++ )
            {
                array[i] = arr[lenght -i - 1];
                Console.Write(array[i]);
            }
            
        }
    }
}
