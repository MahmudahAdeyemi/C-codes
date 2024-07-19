namespace QueueExample
{
    public class OnQueue<T>where T : BaseClass
    {
        public List<T> list{get; set;} = new();


        public void Enqueue(T Queue)
        {
            list.Add(Queue);   
        }
        public void Dequeue()
        {
            list.Remove(list[0]);
        }
        public int Count()
        {
            return list.Count;
        }
        public void Clear()
        {
            list.Clear();
        }

    }

}       