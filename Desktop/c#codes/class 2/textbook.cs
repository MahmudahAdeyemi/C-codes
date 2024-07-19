namespace Method
{
    class Textbook : Book
    {
        private string Author;
        private string Publisher;
        private string Level;

        public Textbook(int noOfPages, string subject, string colour,string author,string publisher,string level) : base(noOfPages, subject, colour)
        {
            Author = author;
            Publisher = publisher;
            Level = level;

        }
        public string GetAuthor()
        {
            return Author;
        }
        public void SetAuthor(string author)
        {
            Author = author;
        }
        public string GetPublisher()
        {
            return Publisher;
        }
        public void SetPublisher(string publisher)
        {
            Publisher = publisher;
        }
        public string GetLevel()
        {
            return Level;
        }
        public void SetLevel(string level)
        {
            Level = level;
        }
        

        
    }
}