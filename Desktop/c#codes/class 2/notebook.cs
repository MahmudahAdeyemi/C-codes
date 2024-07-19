namespace Method
{
    class Notebook : Book
    {
        private string Owner;
        private bool Isfinished;
        public Notebook(int noOfPages, string subject, string colour,string owner, bool isfinihed) : base(noOfPages, subject, colour)
        {
            Owner = owner;
            Isfinished = isfinihed;
        }
        public string GetOwner()
        {
            return Owner;
        }
        public void SetAuthor(string owner)
        {
            Owner = owner;
        }
        public bool GetIsfinished()
        {
            return Isfinished;
        }
        public void SetIsfinished(bool isfinised)
        {
            Isfinished = isfinised;
        }
        public void Print_Status()
        {
            if (Isfinished)
            {
                Console.WriteLine("The book has finished");
            }
            else
            {
                Console.WriteLine("The book has not finished.");
            }
        }
    }
}