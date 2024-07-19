namespace MahmudahCodechallenge
{
    public class SubArrays
    {
        public void Answer()
        {
            int sum = 0;
            int [] array = [1,2,1];
            var list = new List<List<int>> ();
            foreach (var item in array)
            {
                sum += item*item;
            }
            var arr = array.Distinct().ToList().Sum();
            sum += arr * arr;
            Console.WriteLine(sum);
            foreach (var item in array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    
                }
            }
            
        }
    }
}