using System.Collections;
ArrayList mylist = new ArrayList();
mylist.Add(5);
mylist.Add("read");
mylist.Add('c');
foreach (var arr in mylist)
{
    int a = (int)arr;

    Console.WriteLine(arr);
}
for(int i =0; i < 3; i ++)
{
    Console.Write("Enter a number: ");
    var m = Console.ReadLine();
    mylist.Add(m);
}
