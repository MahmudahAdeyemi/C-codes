namespace Method
{
    class MyGeneric<T> where T : Person
    {

        public void Print(T message)
        {
            Console.WriteLine(message.FirstName);
        }

      

    }
}