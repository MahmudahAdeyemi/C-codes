namespace LINQDemo
{
    class Student
    {
        public int ID {get;set;}

        public string FirstName {get;set;}
        public string LastName{get;set;}
        public int Weight{get;set;}
        public int NoOfDaysPresent{get;set;}
        public int Age{get;set;}
        public string Gender {get;set;}


        public List<string> Courses = new List<string>();
    }
}