namespace Method
{
    class Reading : Library
    {
        public string  Reader;
        
        public Reading(string title, string author, string type,string reader) : base(title, author, type)
        {
            Reader = reader;
        }
    }
}