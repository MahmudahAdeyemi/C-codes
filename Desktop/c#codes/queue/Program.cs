using System.Collections;
Queue myqueue = new Queue();
for (int i = 0; i < 4; i ++)
{
    Console.Write("Enter the number: ");
    int m = int.Parse(Console.ReadLine());
    myqueue.Enqueue(m);
}
for(int i = 0; i < 4; i ++)
{
    int n =(int) myqueue.Dequeue();
    Console.Write(n);
}