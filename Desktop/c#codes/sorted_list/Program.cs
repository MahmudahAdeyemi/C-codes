using System.Collections;
SortedList mylist = new SortedList();
for(int i = 0; i < 4; i ++)
{
    Console.Write("Enter the id: ");
    string m = Console.ReadLine();
    Console.Write("Enter score: ");
    int k = int.Parse(Console.ReadLine());
    mylist.Add(m,k);
}
foreach(DictionaryEntry arr in mylist)
{
    Console.WriteLine(arr.Key + " " + arr.Value);
}