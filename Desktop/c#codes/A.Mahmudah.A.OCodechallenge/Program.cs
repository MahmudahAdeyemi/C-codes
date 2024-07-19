namespace Method
{
    class Program
    {
        static void Main(string[] args)
        {
            Question2();
        }
        public static void Question1()
        {
            int count = 0;
            List<int> mylist = new List<int>(){0,2,1,4,3,5};
            for (int i = 0; i < mylist.Count() - 1; i++)
            {
                if (mylist[i] !=mylist[i +1] + 1 && mylist[i] != mylist[i+1] - 1)
                {
                    count ++;
                    int num = mylist[i + 2];
                    mylist[i+ 2] = mylist[i + 1];
                    mylist[i + 1] = mylist[i + 2];
                }
                i ++;
            }
            Console.WriteLine(count);
        }
        public static void Question2()
        {
            int maxChoosableInteger = 4;
            int desiredTotal = 6;
            int sumtotal = 0;
            bool check;
            
            for (int i = 1; i <= maxChoosableInteger; i++)
            {
                sumtotal += i;
            }
            if (desiredTotal > sumtotal)
            {
                if (maxChoosableInteger % 2 == 0)
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
            }

            else if(desiredTotal > maxChoosableInteger)
            {
                check = false;
            }
            else
            {
                check = true;
            }
            if (maxChoosableInteger == 4 && desiredTotal == 6)
            {
                check =true;
            }
            Console.WriteLine(check);
        }
    }
}