using rev.ENTITIES;

public class Student
{
    public Student( string fName, string lName, int age, string email, string password, int gradeId)
    {
        FName = fName;
        LName = lName;
        Age = age;
        Email = email;
        Password = password;
        gradeId = GradeId;
    }

        public int Id{get; set;}
        public string FName{get; set;}
        public string LName{get; set;}
        public int Age{get; set;}
        public string Email{get; set;}
        public string Password{get; set;}
        public int GradeId{get; set;}
        public Grade Grade{get; set;}
        public List<Studentcourse> Studentcourses {get; set;} = new List<Studentcourse>();
}