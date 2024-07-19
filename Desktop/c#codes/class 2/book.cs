namespace Method
{


    class Book
    {
        private int NoOfPages;
        private string Subject;
        private string Colour;

        public Book (int noOfPages , string subject, string colour)
        {
            NoOfPages = noOfPages;
            Subject = subject;
            Colour = colour;
        }

        public int GetNoOfPages()
        {
            return NoOfPages;
        }
        public void SetName(int noOfPages)
        {
            NoOfPages = noOfPages;
        }
        public string GetSubject()
        {
            return Subject;
        }
        public void SetName(string subject)
        {
            Subject = subject;
        }
        public string GetColour()
        {
            return Colour;
        }
        public void SetColour(string colour)
        {
            Colour = colour;
        }
        public void Print_Details()
        {
            Console.WriteLine("This " + Colour + " " + NoOfPages + " pages notebook is for " +Subject );
            
        }
    }
}