using System.Collections;
Stack mystack = new Stack();
mystack.Push(8);
for(int i = 0; i < 3; i ++)
{
    Console.Write("Enter the number: ");
    int m = int.Parse(Console.ReadLine());
    mystack.Push(m);
}
for(int i = 0; i < 3; i ++)
{
    int a = (int)mystack.Pop();
    Console.Write(a);
}