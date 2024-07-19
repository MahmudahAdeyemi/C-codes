namespace Method
{
    class Staff
    {
        public Staff(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id_no =Generateidno();
        }

        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Id_no{get;set;}

        public string Generateidno()
        {
            return $"Admin{ Guid.NewGuid().ToString().Substring(0,5)}";
        }
        
    }
}