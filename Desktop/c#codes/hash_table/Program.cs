using System.Collections;
Hashtable myhash = new Hashtable();
myhash.Add("mahmudah",8);
for (int i =0; i < 3; i ++)
{
    Console.Write("Enter student id");
    string m = Console.ReadLine();
    Console.Write("Enter student score: ");
    int sc = int.Parse(Console.ReadLine());
    myhash.Add(m,sc);
}

// foreach(DictionaryEntry arr in myhash)
// {
//     Console.WriteLine(arr.Key + " " + arr.Value);
// }
Console.WriteLine(myhash["mahmudah"]);
