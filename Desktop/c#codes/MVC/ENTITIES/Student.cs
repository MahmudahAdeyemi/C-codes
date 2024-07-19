namespace MVC.ENTITIES;
    public class Student
    {

        public int Id{get; set;}
        public string FName{get; set;}
        public string LName{get; set;}
        public int Age{get; set;}
        public string Email{get; set;}
        public string Password{get; set;}
        public int DepartmentId{get; set;}
        public Department Department{get; set;}
    }
