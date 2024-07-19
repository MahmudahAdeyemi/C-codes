namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            Fact();
        }
        static void Fact()
        {
            Console.Write("Enter lenght of number: ");
            int lenght = int.Parse(Console.ReadLine());
            int []array = new int[lenght] ;
            int sum = 0;

            for (int i =0;i < lenght; i ++ )
            {
                Console.Write("Enter number: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0;i < lenght;i++)
            {
                for (int j = array[i] - 1; i > 0; i--)
                {
                    array[i] *= i;
                }
            }
            for(int i =0; i < lenght;i ++)
            {
                sum += array[i];

            }
            Console.WriteLine(sum);
        }
    }
}