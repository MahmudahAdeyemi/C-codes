using System.Collections;
bool check = false;
Hashtable myhashtable = new Hashtable();
int [] arr = new int[] {1,2,3,1};
foreach(var item in arr)
{
    if (myhashtable.ContainsKey(item))
    {
        myhashtable[item] = (int)myhashtable[item] + 1;

    }
    else
    {
        myhashtable[item] = 1;
    }
}
foreach(DictionaryEntry itens in myhashtable)
{
    // Console.WriteLine($"{itens.Key}   {itens.Value}");
    if ((int)itens.Value > 1)
    {
        check = true;
        break;
    }
}
Console.WriteLine(check);