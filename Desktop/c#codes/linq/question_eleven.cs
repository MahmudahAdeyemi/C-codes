namespace LINQDemo
{
    public static class Eleven
    {
        public static void Answer(List<int> myList, int num)
        {
            var order = myList.OrderByDescending(s => s).ToList();
            var takind = order.Take(num).ToList();
            foreach (var item in takind)
            {
                Console.WriteLine(item);
            }

        }

        public static List<string> Twelve(string sentence)
        {
            var x = sentence.Split(' ').ToList();
            var gh = x.Where(a => a.All(c => c >= 65 && c <= 91)).ToList();
            return gh;

        }

        public static string Thirteen(List<string> mystring)
        {
            // var word = mystring.Aggregate((s1,s2) => s1 + ", "+ s2).ToString();
            // return word;
            string word = "";
            for (int i = 0; i < mystring.Count(); i++)
            {
                if (i != mystring.Count() - 1)
                {
                    word = word + mystring[i] + ", ";
                }
                else
                {
                    word = word + mystring[i];
                }

            }
            return word;

        }

        public static void Extensions()
        {
            List<FileSpliter>file_split = new List<FileSpliter>();
            List<string> file = new List<string>(){"aaa.frx","bbb.txt","xyz.dbf","abc.pdf","aaaa.pdf","xyz.frt","abc.xml","ccc.txt","zzz.txt"};
            foreach (var item in file)
            {
                var new_split =item.Split('.').ToList();
                string element1 = new_split[0];
                string element2 = new_split[1];
                FileSpliter mysplit = new FileSpliter(element1, element2);
                file_split.Add(mysplit);
            }
            var r = file_split.GroupBy(s => s.Extensions);
            foreach (var item in r)
            {
                Console.WriteLine($"{item.Key}  {item.Count()}");
            }
        }
    }
}