namespace Deligate_Class
{
    class Student
    {
        public string FirstName{get; set;}
        public string LastName{get;set;}
        public int Age{get;set;}
        public Gender Gender {get; set;}


        public Student(string firstname,string lastname,int age,Gender gender)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age; 
            Gender = gender;
        }
        
    }
    
    
}