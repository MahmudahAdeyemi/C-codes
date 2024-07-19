namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            Sum();
        }
        static void Sum()
            {
                Console.Write("Enter the lenght of array: ");
                int lenght = int.Parse(Console.ReadLine());
                int [] arr = new int[lenght];
                Console.Write("Enter the lenght of array: ");
                int len =int.Parse(Console.ReadLine());
                int [] array = new int[lenght];
                
                if (lenght == len)  
                {
                    
                    for(int i =0;i<lenght;i ++)
                    {
                        Console.Write("Enter the number on the fist array: ");
                        arr[i] = int.Parse(Console.ReadLine());
                        Console.Write("Enter the number on the fist array: ");
                        array[i] = int.Parse(Console.ReadLine());
                    }
                    for (int i =0; i < lenght; i ++)
                    {
                        
                        int sum = (arr[i] + array[i]);
                        Console.Write(sum +" ");
                    }
                
                    }
                else
                {
                    Console.WriteLine("You can not continue with this program");
                }
                
               
            }
    }
}