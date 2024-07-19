using System;
namespace Method
{
    class Program
    {
        static void Main(string[]args)
        {
            int[] myArray = {20,15,8,2,12};
            int num = myArray[0]-myArray[1];
            int [] index = new int [2];
            int i;
            int j=0;
            for(i = 0; i< myArray.Length-1; i++)
            {
                
                for(j = i+1; j < myArray.Length; j++)
                {
                    int check = myArray[i] - myArray[j];
                    if(check < num && check > 0)
                    {
                        num = check;
                        index[0]=i +1;
                        index[1]=j+1;
                    }
                }
            }
            Console.WriteLine("The customer will purchase it at year "+index[0]+" and sellat year "+index[1]);
        }
    }
}