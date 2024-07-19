class FileReader
{
    static void Main()
    {
        StreamReader reader = new StreamReader("sample.txt");
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                Console.WriteLine($" {line}");
                line = reader.ReadLine();
            }
        }
    }
}
// class FileWriter
// {
//     static void Main()
//     {
//         List<int>consumer_list= new List<int>(){1,4,3,5,64,5,3};
//         StreamWriter writer = new StreamWriter("numbers.txt");
//         using (writer)
//         {
//             foreach (var item in consumer_list)
//             {
//                 writer.WriteLine(item);
//             }
//         }
//     }
// }

//Console.Error.WriteLine(@"Mahmudah");
// .WriteLine("usageText");
// var destPath = "words_bck.txt";

// var sourcePath = "words.txt";

// File.Copy(destPath, sourcePath);

// Console.WriteLine("file copied");
//Console.WriteLine(destPath);
// var sourcePath = "words.txt";
// var destPath = "data.txt";

// File.Move(sourcePath, destPath);

// Console.WriteLine("file moved");
// var path = "words2.txt";

// if (File.Exists(path))
// {
//     Console.WriteLine("the file exists");
// } else {

//     Console.WriteLine("the file does not exist");
// }
// var path = "words2.txt";

// File.Delete(path);

// Console.WriteLine("file deleted");
// var path = "words_bck.txt";

// DateTime dt = File.GetCreationTime(path);

// Console.WriteLine($"Creation time: {dt}");
// var path = "words_bck.txt";

// DateTime dt = File.GetLastWriteTime(path);

// Console.WriteLine($"Last write time: {dt}");
// var path = "words.txt";

// var lines = File.ReadLines(path);

// foreach (var line in lines)
// {
//     Console.WriteLine(line);
// }
// var path = "words.txt";

// string readText = File.ReadAllText(path);
// Console.WriteLine(readText);
// var path = "words.txt";

// string data = "sky\ncloud\nfalcon\nowl\ncrane";
// File.WriteAllText(path, data);

// Console.WriteLine("data written");
// using System.Text;

// var path = "words.txt";

// string[] data = { "sky", "cloud", "falcon", "hawk" };
// File.WriteAllLines(path, data, Encoding.UTF8);

// Console.WriteLine("data written"); 
// var path = "words.txt";

// using StreamWriter sw = File.AppendText(path);

// sw.WriteLine("sky");
// sw.WriteLine("lake");
// var path = "words.txt";
// var contents = "armour\nsword\narrow\nmike\n";

// File.AppendAllText(path, contents);
// var path = "words.txt";
// var data = new List<string> {"brown", "blue", "khaki"};

// File.AppendAllLines(path, data);